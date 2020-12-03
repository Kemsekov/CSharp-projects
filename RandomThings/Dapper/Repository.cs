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

namespace CSharp_projects.RandomThings.Dapper
{
    public class Repository<Entity,DbConnection> : IRepository<Entity>,IDisposable where DbConnection : class,IDbConnection,new()
    {
        IDbConnection db = null;
        bool Disposed = false;
        readonly Type type = typeof(Entity);
        string connection_string = null;
        PropertyInfo IDProperty = null;
        PropertyInfo[] Properties = null;
        public string Table{get;set;}

        public Repository(string connection_string,string table = null)
        {
            Table = table;
            if(type.GetRuntimeProperty($"{type.Name}ID")!=null)
                IDProperty=type.GetRuntimeProperty($"{type.Name}ID");
            else if(type.GetRuntimeProperty("ID")!=null)
                IDProperty=type.GetRuntimeProperty("ID");
                else 
                throw new Exception($"There is no public \"{type.Name}ID\" or \"ID\" property in {type.FullName}");
            
            Properties = type.GetRuntimeProperties().ToArray();
            this.connection_string = connection_string;   
            db = new DbConnection();
            db.ConnectionString = connection_string;
        }
        public void Create(Entity entity,string tablename = null)
        {
            var cache = MemoryCache.Default;
            
            string tableName = GetOrThrowIfBothNull(tablename,Table,"Table value is null!");

            string sqlQuery = null;
            string chache_name = $"{type.Name}_{tableName}_Create";

            lock(type){
                if(cache.Contains(chache_name)){
                    sqlQuery = cache.Get(chache_name) as string;
                }
                else{
                    var builder = new StringBuilder($"INSERT INTO {tableName} (");
                    foreach(var a in Properties){
                        builder.Append($"{a.Name}, ");
                    }
                    builder.Remove(builder.Length-2,2);

                    builder.Append(") VALUES (");

                    foreach(var a in Properties){
                        builder.Append($"@{a.Name}, ");
                    }
                    builder.Remove(builder.Length-2,2);
                    builder.Append(')');

                    sqlQuery = builder.ToString();
                    
                    cache.Add(chache_name,sqlQuery,DateTime.Now.AddMinutes(5));
                }

            }

            db.Execute(sqlQuery, entity);
        }

        public async Task CreateAsync(Entity entity,string tablename = null)
        {
            await Task.Run(()=>Create(entity,tablename));
        }

        public void Delete(int id, string tablename = null)
        {

            string tableName = GetOrThrowIfBothNull(tablename,Table,"Table value is null!");

            var sqlQuery = $"DELETE FROM {tableName} WHERE {IDProperty.Name} = {id}";

            db.Execute(sqlQuery);
            
        }

        public async Task DeleteAsync(int id, string tablename = null)
        {
            await Task.Run(()=>Delete(id,tablename));
        }

        public Entity Get(int id, string tablename = null)
        {
            string tableName = GetOrThrowIfBothNull(tablename,Table,"Table value is null!");

            return db.Query<Entity>($"SELECT * FROM {tableName} WHERE {IDProperty.Name}={id}").FirstOrDefault();
        }

        public async Task<Entity> GetAsync(int id, string tablename = null)
        {
            return await Task.Run(()=>Get(id,tablename));
        }

        public async Task<List<Entity>> GetEntitesAsync(string tablename = null)
        {
            return await Task.Run(()=>GetEntities(tablename));
        }

        public List<Entity> GetEntities(string tablename = null)
        {
            
            string tableName = GetOrThrowIfBothNull(tablename,Table,"Table value is null!");

            return db.Query<Entity>($"SELECT * FROM {tableName}").ToList();

        }

        public void Update(Entity entity, string tablename = null)
        {

            using var cache = MemoryCache.Default;

            string sqlQuery = null;
            string tableName = GetOrThrowIfBothNull(tablename,Table,"Table value is null!");
            string chache_name = $"{type.Name}_{tableName}_Create";
            
            lock(type)
            if(cache.Contains(chache_name))
                sqlQuery = cache.Get(chache_name) as string;
            else{
                var builder = new StringBuilder($"UPDATE {tableName} SET ");
                foreach(var a in Properties){
                    builder.Append($"{a.Name} = @{a.Name} ");
                }

                builder.Append($"WHERE {IDProperty.Name} = @{IDProperty.Name}");

                sqlQuery = builder.ToString();

                cache.Add(chache_name,sqlQuery,DateTime.Now.AddMinutes(5));
            }

            db.Execute(sqlQuery, entity); 

        }

        public async Task UpdateAsync(Entity entity, string tablename = null)
        {
            await Task.Run(()=>Update(entity,tablename));
        }

        protected T GetOrThrowIfBothNull<T>(T t1, T t2, string exceotion_msg){
            if(t1!=null)
            return t1;
            else if(t2!=null)
            return t2;
            else throw new Exception(exceotion_msg);
        }

        public IEnumerable<Entity> Query(string sqlQuery)
        {
            return db.Query<Entity>(sqlQuery);
        }
        //<summary>
        //Process sqlQuery string directly in database. May be used to create tables, join statements, where statements, etc.. 
        //<summary>
        public async Task<IEnumerable<Entity>> QueryAsync(string sqlQuery){
            return await db.QueryAsync<Entity>(sqlQuery);
        }

        public void Dispose()
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