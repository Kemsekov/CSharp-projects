using System;
using System.Collections.Generic;
using SortLinkedList;
using TemporaryProj.ChainOfResponsability;
using System.Linq;
using TemporaryProj.Tests;
using System.IO;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSharp_projects.RandomThings;
using MySql.Data.MySqlClient;
using CSharp_projects.RandomThings.Dapper;
using System.Reflection;
using System.Data;
using Dapper;

namespace TemporaryProj
{
    
    class TmpProj
    {
    static void Main(string[] args)
    {
        string cs = @"Server=localhost;Database=UsersDB;Uid=vlad1;Pwd=vfu149vv.;";
        
        var rep = new MySqlRepository<User>(cs,"USERS");
        rep.Create(new User{Name="Volodia",Number="_234412",Age=31});
        //db.Execute("CREATE TABLE USER_1(FriendsID INT NOT NULL PRIMARY KEY, Status TEXT);");

        //var repository = new MySqlRepository<User>("");
        
    }
    }
}
