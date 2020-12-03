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
using CSharp_projects.RandomThings.Dapper.SqlTools;
using System.Data;
using Dapper;
using System.Runtime.Caching;
using CSharp_projects.RandomThings.Dapper;

namespace TemporaryProj
{
    
    class TmpProj
    {
    static void Main(string[] args)
    {
        string cs = @"Server=localhost;Database=UsersDB;Uid=vlad1;Pwd=vfu149vv.;";
        using var rep = new MySqlTool<MySqlConnection>(cs,"USERS");
        
        rep.Create(new User{Name="Hoho",Number="+542",Age=15});
        rep.Create(new User{Name="I am created by cache!",Number="+228",Age=1337});
        for(int a = 5;a<10;a++){
            rep.Delete<User>(a);
        }
    }
    }
}
