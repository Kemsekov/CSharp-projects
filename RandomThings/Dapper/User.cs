using System.ComponentModel.DataAnnotations;

namespace CSharp_projects.RandomThings.Dapper
{
    public class User
    {
        [DataType("INT NOT NULL AUTO_INCREMENT PRIMARY KEY")]
        public int UserID{get;set;}
        public string Name{get;set;}
        public int Age{get;set;}
        public string Number{get;set;}
    }
}