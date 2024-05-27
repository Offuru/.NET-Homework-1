using Project.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Dtos.Request
{
    public class RegisterRequest
    {
        public string Username {  get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }

    }
}
