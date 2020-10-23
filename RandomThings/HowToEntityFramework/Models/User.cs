using System;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace CSharp_projects.RandomThings
{
    public class User{
        public User(string FullName){
            var a = FullName.Split(" ");
            if(a.Length>=2){
            Name = a[0];
            SecondName = a[1];
            infoContext = new Lazy<UserInfoContext>(()=>{
                return new UserInfoContext(this);
            });
            }
            else{
                Name = "";
                SecondName = "";
            }
        }
        public User(){

            infoContext = new Lazy<UserInfoContext>(()=>{
                return new UserInfoContext(this);
            });
        }
        public void SaveChanges()=>InfoContext.SaveChanges();
        public int ID{get;set;}
        public string Name{get;set;}
        public string SecondName{get;set;}
        public DbSet<Contact> Contacts{get=>InfoContext.Contacts;}
        public DbSet<PlayList> PlayList{get=>InfoContext.PlayList;}
        public UserInfoContext InfoContext{get=>infoContext.Value;}
        protected Lazy<UserInfoContext> infoContext{get;set;}

    }
}