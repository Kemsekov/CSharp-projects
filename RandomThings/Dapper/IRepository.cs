using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp_projects.RandomThings.Dapper
{
    public interface IRepository<Entity>
    {
        void Create(Entity entity,string tablename = null);
        Task CreateAsync(Entity entity,string tablename = null);
        void Delete(int id, string tablename = null);
        Task DeleteAsync(int id, string tablename = null);
        Entity Get(int id, string tablename = null);
        Task<Entity> GetAsync(int id, string tablename = null);
        List<Entity> GetEntities(string tablename = null);
        Task<List<Entity>> GetEntitesAsync(string tablename = null);
        void Update(Entity entity,string tablename = null);
        Task UpdateAsync(Entity entity,string tablename = null);
        IEnumerable<Entity> Query(string sqlQuery);
        Task<IEnumerable<Entity>> QueryAsync(string sqlQuery);
    }
}