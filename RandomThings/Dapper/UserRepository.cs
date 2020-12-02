using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace CSharp_projects.RandomThings.Dapper
{
    public class UserRepository : IUserRepository
    {
        string connection_string = null;
        public UserRepository(string connection_string)
        {
            this.connection_string = connection_string;
        }
        public void Create(User user)
        {
            using (IDbConnection db = new MySqlConnection(connection_string))
            {
                var sqlQuery = "INSERT INTO USERS (Name, Age) VALUES(@Name, @Age)";
                db.Execute(sqlQuery, user);
            }
        }

        public async Task CreateAsync(User user){
            using (IDbConnection db = new MySqlConnection(connection_string))
            {
                var sqlQuery = "INSERT INTO USERS (Name, Age) VALUES(@Name, @Age)";
                await db.ExecuteAsync(sqlQuery, user);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new MySqlConnection(connection_string))
            {
                var sqlQuery = $"DELETE FROM USERS WHERE Id = {id}";
                db.Execute(sqlQuery);
            }
        }
        
        public async Task DeleteAsync(int id){
            using (IDbConnection db = new MySqlConnection(connection_string))
            {
                var sqlQuery = $"DELETE FROM USERS WHERE Id = {id}";
                await db.ExecuteAsync(sqlQuery);
            }
        }
        public User Get(int id)
        {
            using (IDbConnection db = new MySqlConnection(connection_string))
            {
                return db.Query<User>($"SELECT * FROM USERS Where UserID={id}").FirstOrDefault();
            }
        }
        public async Task<User> GetAsync(int id)
        {
            using (IDbConnection db = new MySqlConnection(connection_string))
            {
                return (await db.QueryAsync<User>($"SELECT * FROM USERS Where UserID={id}"))
                .FirstOrDefault();
            }
        }
        public List<User> GetUsers()
        {
            using (IDbConnection db = new MySqlConnection(connection_string))
            {
                return db.Query<User>("SELECT * FROM USERS").ToList();
            }
        }
        public async Task<List<User>> GetUsersAsync()
        {
            using (IDbConnection db = new MySqlConnection(connection_string))
            {
                return (await db.QueryAsync<User>("SELECT * FROM USERS"))
                .ToList();
            }
        }
        public void Update(User user)
        {
            using (IDbConnection db = new MySqlConnection(connection_string)){
                var sqlQuery = 
                $"UPDATE USERS SET Name = @Name, Age = @Age, Number = @Number WHERE UserID = @UserID";
                db.Execute(sqlQuery, user);
            }
        }
        public async Task UpdateAsync(User user){
            using (IDbConnection db = new MySqlConnection(connection_string)){
                var sqlQuery = 
                $"UPDATE USERS SET Name = @Name, Age = @Age, Number = @Number WHERE UserID = @UserID";
                await db.ExecuteAsync(sqlQuery, user);
            }
        }
    }
}