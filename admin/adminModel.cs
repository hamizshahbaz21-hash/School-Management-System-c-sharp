using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SchoolManagementSystem.Models
{
    public class Admin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        
       
        public Admin()
        {
            
            Username = "";
            Password = "";
        }
    }
}