using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

using System.Linq;

namespace CSharp_projects.RandomThings
{
    public static class HowToEntityFramework
    {
        public static void Use(){
            using(var context = new UserContext("Users")){
                var c = new User(){Name="Jhoon", SecondName="Week"};

                context.Users.Add(c);

                var user2 = context.Users.Add(new User("Nina Sex"));
                var user3 = context.Users.Add(new User("Alex Gay"));
                var user4 = context.Users.Add(new User("Who_Stole_My Wallet?"));
                var user5 = context.Users.Add(new User("Amanda Swift"));
                var user6 = context.Add(new User("WE ARE"));
                context.SaveChanges();

                var res = from element in context.Users
                          where element.Name=="Jhoon"
                          select element;
                
                
                //we got Jhoon Week user. This object equal to c
                var jhoon = res.First();

                //ok, it will create a new database if there is no one for that user
                
                jhoon.Contacts.Add(new Contact(user6,"friend"));
                jhoon.Contacts.Add(new Contact(user5,"friend"));

                //because of DbContext is into User model, we still need to update it
                jhoon.InfoContext.SaveChanges();     
            
                
                context.SaveChanges();

            }
        }
    
        public static void Delete(){
            using(var context = new UserContext("Users"))
            {
                //Constructor is not that important in this, but ID defines what
                //will be deleted
                context.Users.Remove(new User("Change Switf"){ID=5});
                context.SaveChanges();
            }
        }
    
        public static void Use2(){
            using(var context = new UserContext("Users"))
            {
                var jhoon = (from el in context.Users
                            where el.Name=="Jhoon"
                            select el).First();
                var nina = (from el in context.Users
                            where el.Name=="Nina"
                            select el).First();

                //but I would like to...
                //var contact = jhoon.Contacts.First();

                //this would create EntryEntity that linked to db and tracked by it
                //And return 
                //Console.WriteLine(contact.User.Name+" is friend of Jhoon!");

                //this would make a change in DB
                //contact.User.Name = "Nina!"; 
            
                var friend = jhoon.Contacts.First();//success

                var usr = (from user in context.Users
                            where user.ID==friend.UserID
                            select user).First();

                usr.Name="Changed!";
                jhoon.Contacts.Add(new Contact(context.Update(nina),"Lover"));
                jhoon.SaveChanges();
                context.SaveChanges();
            }
        }
    }
}