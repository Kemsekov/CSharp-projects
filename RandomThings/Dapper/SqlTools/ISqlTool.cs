using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp_projects.RandomThings.Dapper.SqlTools
{
    public interface ISqlTool
    {
        void Create<Entity>(Entity entity,string tablename = null);
        Task CreateAsync<Entity>(Entity entity,string tablename = null);
        void Delete<Entity>(int id, string tablename = null);
        Task DeleteAsync<Entity>(int id, string tablename = null);
        Entity Get<Entity>(int id, string tablename = null);
        Task<Entity> GetAsync<Entity>(int id, string tablename = null);
        List<Entity> GetEntities<Entity>(string tablename = null);
        Task<List<Entity>> GetEntitesAsync<Entity>(string tablename = null);
        void Update<Entity>(Entity entity,string tablename = null);
        Task UpdateAsync<Entity>(Entity entity,string tablename = null);
        IEnumerable<Entity> Query<Entity>(string sqlQuery);
        Task<IEnumerable<Entity>> QueryAsync<Entity>(string sqlQuery);
    }
}