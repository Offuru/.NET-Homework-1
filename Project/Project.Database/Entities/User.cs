using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Entities
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public decimal Balance { get; set; }
        public string Email {  get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public Role Role { get; set; }
        public List<Gundam> Gundams { get; set; }
    }
}
