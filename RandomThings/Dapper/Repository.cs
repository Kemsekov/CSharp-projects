using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reflection;
using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using System.Text;
using System.Runtime.Caching;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_OR_PAIN_IN_MY_HEAD.Database
{
    public class Repository<Entity,DbConnection> : IRepository<Entity>,IDisposable where DbConnection : class,IDbConnection,new()
    {
        public IDbConnection db = null;
        protected bool Disposed = false;
        protected readonly Type type = typeof(Entity);
        protected string[] Properties_str = null;
        protected Dictionary<string, PropertyInfo> Properties = null;
        public string Table{get;set;}

        private Repository(){}
        public Repository(string connection_string, string table,bool createTableIfNotExist = true)
        {
            Table = table;
            if(type.GetRuntimeProperty($"ID")==null)
                throw new Exception($"There is no public \"ID\" property in {type.FullName}");
            Properties_str = (from el in type.GetRuntimeProperties()
                         select el.Name).ToArray<string>();
            Properties = typeof(Entity).GetProperties().ToDictionary(info=>info.Name,info=>info);
            db = new DbConnection();
            db.ConnectionString = connection_string;
            if(createTableIfNotExist)
                CreateTableIfNotExists();
        }
        public Repository(DbConnection db,string table = null,bool createTableIfNotExist = true){
            Table = table;
            if(type.GetRuntimeProperty($"ID")==null)
                throw new Exception($"There is no public \"ID\" property in {type.FullName}");
            Properties_str = (from el in type.GetRuntimeProperties()
                         select el.Name).ToArray<string>();
            Properties = typeof(Entity).GetProperties().ToDictionary(info=>info.Name,info=>info);
            this.db = db;
            Disposed = true;
            if(createTableIfNotExist)
                CreateTableIfNotExists();
        }
        protected virtual void CreateTableIfNotExists(){
            Func<PropertyInfo,string> ChooseDbTypeAndConstraints = (PropertyInfo t) =>{
                
                var attrib = t.GetCustomAttribute(typeof(DataTypeAttribute),true) as DataTypeAttribute;

                if(attrib!=null){
                    return attrib.CustomDataType;
                }

                switch(t.PropertyType.Name.ToUpper()){
                    case "STRING" :
                        return "TEXT";
                    case "INT" or "INT32":
                        return "INT";
                    case "BYTE[]":
                        return "BLOB";
                    case "DATETIME":
                        return "DATETIME";
                    case "FLOAT":
                        return "FLOAT(32)";
                    case "DOUBLE":
                        return "FLOAT(64)";
                }
                
                return "";
            };

            var Props = type.GetProperties();
            var builder = new StringBuilder($"CREATE TABLE IF NOT EXISTS {Table} (");
            foreach(var a in type.GetProperties())
            builder.Append($" {a.Name} {ChooseDbTypeAndConstraints(a)},");

            builder.Remove(builder.Length-1,1);
            builder.Append(")");
            db.Execute(builder.ToString());
        }
        public virtual void Create(Entity entity)
        {
            var cache = MemoryCache.Default;
            
            string sqlQuery = null;
            string chache_name = $"{type.Name}{Table}Create";

            lock(type){
                if(cache.Contains(chache_name)){
                    sqlQuery = cache.Get(chache_name) as string;
                }
                else{
                    var builder = new StringBuilder($"INSERT INTO {Table} (");

                    builder.Append(string.Join(", ",Properties_str));

                    builder.Append(") VALUES (");

                    builder.Append(" @");
                    builder.Append(string.Join(", @",Properties_str));

                    builder.Append(')');
                    
                    sqlQuery = builder.ToString();
                    
                    cache.Add(chache_name,sqlQuery,DateTime.Now.AddMinutes(5));
                }

            }

            db.Execute(sqlQuery, entity);
        }

        public virtual async Task CreateAsync(Entity entity)
        {
            await Task.Run(()=>Create(entity));
        }

        public virtual void Delete(int id)
        {

            var sqlQuery = $"DELETE FROM {Table} WHERE ID = {id}";

            db.Execute(sqlQuery);
            
        }

        public virtual async Task DeleteAsync(int id)
        {
            await Task.Run(()=>Delete(id));
        }

        public virtual Entity Get(int id)
        {
            return db.Query<Entity>($"SELECT * FROM {Table} WHERE ID={id}").FirstOrDefault();
        }

        public virtual async Task<Entity> GetAsync(int id)
        {
            return await Task.Run(()=>Get(id));
        }

        public virtual async Task<List<Entity>> GetEntitesAsync()
        {
            return await Task.Run(()=>GetEntities());
        }

        public virtual List<Entity> GetEntities()
        {
            
            return db.Query<Entity>($"SELECT * FROM {Table}").ToList();

        }

        public virtual void Update(Entity entity)
        {

            using var cache = MemoryCache.Default;

            string sqlQuery = null;
            string chache_name = $"{type.Name}_{Table}_Create";
            
            lock(type)
            if(cache.Contains(chache_name))
                sqlQuery = cache.Get(chache_name) as string;
            else{
                var builder = new StringBuilder($"UPDATE {Table} SET ");
                foreach(var a in Properties_str){
                    builder.Append($"{a} = @{a}, ");
                }
                builder.Remove(builder.Length-2,2);
                builder.Append($" WHERE ID = @ID");

                sqlQuery = builder.ToString();

                cache.Add(chache_name,sqlQuery,DateTime.Now.AddMinutes(5));
            }

            db.Execute(sqlQuery, entity); 

        }

        public virtual async Task UpdateAsync(Entity entity)
        {
            
            await Task.Run(()=>Update(entity));
        }

        public virtual void Dispose()
        {
            if(!Disposed){
                db.Dispose();
                Disposed = true;
            }
        }
    }
}

        //string cs = @"Server=localhost;Database=UsersDB;Uid=vlad1;Pwd=vfu149vv.;";
        //
        //var rep = new MySqlRepository<User>(cs,"USERS");
        //var task = rep.QueryAsync("SELECT * FROM USERS WHERE Name=\"Ira\"");
        //task.Wait();
        //var res = task.Result;
        //System.Console.WriteLine(res.FirstOrDefault().Number);