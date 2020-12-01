using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp_projects.RandomThings.Dapper
{
    public interface IUserRepository
    {
        void Create(User user);
        Task CreateAsync(User user);
        void Delete(int id);
        Task DeleteAsync(int id);
        User Get(int id);
        Task<User> GetAsync(int id);
        List<User> GetUsers();
        Task<List<User>> GetUsersAsync();
        void Update(User user);
        Task UpdateAsync(User user);
    }
}