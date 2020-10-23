using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

using System.Linq;

namespace CSharp_projects.RandomThings
{
    public class UserContext : DbContext{
    public UserContext(string dbName) : base()
    {
            DbName = dbName;
            if(!Database.EnsureCreated()){
                
                Console.ForegroundColor=ConsoleColor.Green;
                System.Console.WriteLine("From UserContext:\nData base is found\nProvider name:\t"+Database.ProviderName);
                
                Console.ResetColor();
            }
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=Assets/{DbName}.db");
    
    public DbSet<User> Users{get;set;}
    public string DbName{get;}
    }
}
