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
using CSharp_projects.RandomThings.Dapper;

namespace CSharp_projects.RandomThings.Dapper.SqlTools
{
    public class MySqlTool<DbConnection> : ISqlTool,IDisposable where DbConnection : IDbConnection,new()
    {
        IDbConnection db = null;
        bool Disposed = false;
        string ConnectionString = null;
        public string Table{get;set;}
        readonly object mutex = new object();
        public MySqlTool(string connection_string, string tablename = null)
        {
            Table = tablename;
            this.ConnectionString = connection_string;
            db = new DbConnection();
            db.ConnectionString = connection_string;
        }

        public void Create<Entity>(Entity entity, string tablename = null)
        {
            var type = typeof(Entity);
            var cache = MemoryCache.Default;
            string tableName = GetOrThrowIfBothNull(tablename,Table,"Table value is null!");
            string cache_name = $"{type.Name}{tableName}create";
            string sqlQuery = null;
            lock(mutex){
                if(cache.Contains(cache_name)){
                    sqlQuery = cache.Get(cache_name) as string;
                }
                else{
                    var builder = new StringBuilder($"INSERT INTO {tableName} (");
                    foreach(var a in type.GetProperties()){
                        builder.Append($"{a.Name}, ");
                    }
                    builder.Remove(builder.Length-2,2);

                    builder.Append(") VALUES (");

                    foreach(var a in type.GetProperties()){
                        builder.Append($"@{a.Name}, ");
                    }
                    builder.Remove(builder.Length-2,2);
                    builder.Append(')');

                    sqlQuery = builder.ToString();
                    
                    cache.Add(cache_name,sqlQuery,DateTime.Now.AddMinutes(5));
                }
            }
            db.Execute(sqlQuery, entity);
        }

        public async Task CreateAsync<Entity>(Entity entity, string tablename = null)
        {
            await Task.Run(()=>Create<Entity>(entity,tablename));
        }

        public void Delete<Entity>(int id, string tablename = null)
        {
            string tableName = GetOrThrowIfBothNull(tablename,Table,$"Table value is null!");

            var type = typeof(Entity);

            string sqlQuery = null;

            var ID = GetOrThrowIfBothNull(type.GetProperty($"{type.Name}ID"),type.GetProperty("ID"),$"There is no public \"{type.Name}ID\" or \"ID\" property in {type.FullName}");
            
            sqlQuery = $"DELETE FROM {tableName} WHERE {ID.Name} = {id}";
            
            db.Execute(sqlQuery);
        }

        public async Task DeleteAsync<Entity>(int id, string tablename = null)
        {
            await Task.Run(()=>Delete<Entity>(id,tablename));
        }

        public Entity Get<Entity>(int id, string tablename = null)
        {
            string tableName = GetOrThrowIfBothNull(tablename,Table,"Table value is null!");
            var type = typeof(Entity);
            var ID = GetOrThrowIfBothNull
            (type.GetProperty($"{type.Name}ID"),type.GetProperty("ID"),$"There is no public \"{type.Name}ID\" or \"ID\" property in {type.FullName}");
            
            return db.Query<Entity>($"SELECT * FROM {tableName} WHERE {ID.Name}={id}").FirstOrDefault();
        }

        public async Task<Entity> GetAsync<Entity>(int id, string tablename = null)
        {
            return await Task.Run(()=>Get<Entity>(id,tablename));
        }

        public async Task<List<Entity>> GetEntitesAsync<Entity>(string tablename = null)
        {
            return await Task.Run(()=>GetEntities<Entity>(tablename));
        }

        public List<Entity> GetEntities<Entity>(string tablename = null)
        {
            string tableName = GetOrThrowIfBothNull(tablename,Table,"Table value is null!");
            return db.Query<Entity>($"SELECT * FROM {tableName}").ToList();
        }

        public IEnumerable<Entity> Query<Entity>(string sqlQuery)
        {
            return db.Query<Entity>(sqlQuery);
        }

        public async Task<IEnumerable<Entity>> QueryAsync<Entity>(string sqlQuery)
        {
            return await db.QueryAsync<Entity>(sqlQuery);
        }

        public void Update<Entity>(Entity entity, string tablename = null)
        {
            var type = typeof(Entity);
            var cache = MemoryCache.Default;
            string tableName = GetOrThrowIfBothNull(tablename,Table,"Table value is null!");
            string cache_name = $"{type.Name}{tableName}update";
            string sqlQuery = null;

            var IDProperty = GetOrThrowIfBothNull
            (type.GetProperty($"{type.Name}ID"),type.GetProperty("ID"),$"There is no public \"{type.Name}ID\" or \"ID\" property in {type.FullName}");
            
            lock(type)
            if(cache.Contains(cache_name))
                sqlQuery = cache.Get(cache_name) as string;
            else{
                var builder = new StringBuilder($"UPDATE {tableName} SET ");
                foreach(var a in type.GetProperties()){
                    builder.Append($"{a.Name} = @{a.Name} ");
                }

                builder.Append($"WHERE {IDProperty.Name} = @{IDProperty.Name}");

                sqlQuery = builder.ToString();

                cache.Add(cache_name,sqlQuery,DateTime.Now.AddMinutes(5));
            }
            db.Execute(sqlQuery, entity); 
        }

        public Task UpdateAsync<Entity>(Entity entity, string tablename = null)
        {
            throw new NotImplementedException();
        }
        protected T GetOrThrowIfBothNull<T>(T t1, T t2, string exceotion_msg){
            if(t1!=null)
            return t1;
            else if(t2!=null)
            return t2;
            else throw new Exception(exceotion_msg);
        }
        public void Dispose()
        {
            if(!Disposed){
                db.Dispose();
            }
        }
    }
}