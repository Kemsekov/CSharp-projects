using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

using System.Linq;

namespace CSharp_projects.RandomThings
{
    public class Contact{
        public Contact(Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<User> user, string status = "")
        {
            this.Status = status;

            this.UserID = user.Entity.ID;
            
        }
        public Contact()
        {
        }
        public int ID{get;set;}
        public int UserID{get;set;}
        public string Status{get;set;}
        public User User{get=>user1.Value;}
        Lazy<User> user1{get;set;}
    }
}