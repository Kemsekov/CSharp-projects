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

namespace TemporaryProj
{
    
    class TmpProj
    {
    static void Main(string[] args)
    {
        string cs = @"Server=localhost;Database=UsersDB;Uid=vlad1;Pwd=vfu149vv.;";
        
        var rep = new UserRepository(cs);
        rep.Update(new User{Name="Jhoon Week",Number="+9776153544",Age=42,UserID=1});
        var usr = rep.Get(1);
        System.Console.WriteLine(usr.Name); 
    }
    }
}
