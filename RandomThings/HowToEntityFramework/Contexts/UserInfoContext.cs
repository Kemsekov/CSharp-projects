using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Linq;
using System.IO;

namespace CSharp_projects.RandomThings
{
    public class UserInfoContext : DbContext{
    
    /// <summary>
    /// if user already existing, then get UserInfoContext for this user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public UserInfoContext(User user) : base()
    {
        DbName = string.Format($"{user.Name}_{user.SecondName}_{user.ID}");


        if(!Database.EnsureCreated()){
            
            Console.ForegroundColor=ConsoleColor.Green;
            System.Console.WriteLine("From UserInfoContext:\nData base is found\nProvider name:\t"+Database.ProviderName);
            
            Console.ResetColor();
        }
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        string path = $"Assets/{DbName}.db";
        options.UseSqlite($"Data Source={path}");
    }
    
    public string DbName{get; protected set;}

    public DbSet<Contact> Contacts{get;set;}
    public DbSet<PlayList> PlayList{get;set;}
    }

}