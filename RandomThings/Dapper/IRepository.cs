using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.NET_OR_PAIN_IN_MY_HEAD.Database
{
    public interface IRepository<Entity>
    {
        void Create(Entity entity);
        Task CreateAsync(Entity entity);
        void Delete(int id);
        Task DeleteAsync(int id);
        Entity Get(int id);
        Task<Entity> GetAsync(int id);
        List<Entity> GetEntities();
        Task<List<Entity>> GetEntitesAsync();
        void Update(Entity entity);
        Task UpdateAsync(Entity entity);
    }
}