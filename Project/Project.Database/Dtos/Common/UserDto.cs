using Project.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Dtos.Common
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public decimal Balance { get; set; }
        public Role Role { get; set; }
        public List<Gundam> Gundams { get; set; }
    }
}
