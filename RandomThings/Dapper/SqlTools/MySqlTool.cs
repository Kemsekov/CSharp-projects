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
    public class MySqlTool : ISqlTool
    {
        string ConnectionString = null;
        public string Table{get;set;}

        public MySqlTool(string connection_string, string tablename = null)
        {
            Table = tablename;
            this.ConnectionString = connection_string;
        }

        public void Create<Entity>(Entity entity, string tablename = null)
        {
            using var cache = MemoryCache.Default;
            throw new NotImplementedException();
        }

        public Task CreateAsync<Entity>(Entity entity, string tablename = null)
        {
            using var cache = MemoryCache.Default;
            throw new NotImplementedException();
        }

        public void Delete(int id, string tablename = null)
        {
            using var cache = MemoryCache.Default;
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id, string tablename = null)
        {
            using var cache = MemoryCache.Default;
            throw new NotImplementedException();
        }

        public Entity Get<Entity>(int id, string tablename = null)
        {
            using var cache = MemoryCache.Default;
            throw new NotImplementedException();
        }

        public Task<Entity> GetAsync<Entity>(int id, string tablename = null)
        {
            using var cache = MemoryCache.Default;
            throw new NotImplementedException();
        }

        public Task<List<Entity>> GetEntitesAsync<Entity>(string tablename = null)
        {
            using var cache = MemoryCache.Default;
            throw new NotImplementedException();
        }

        public List<Entity> GetEntities<Entity>(string tablename = null)
        {
            throw new NotImplementedException();
        }

        public List<Entity> Query<Entity>(string sqlQuery)
        {
            throw new NotImplementedException();
        }

        public Task<List<Entity>> QueryAsync<Entity>(string sqlQuery)
        {
            throw new NotImplementedException();
        }

        public void Update<Entity>(Entity entity, string tablename = null)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync<Entity>(Entity entity, string tablename = null)
        {
            throw new NotImplementedException();
        }
    }
}