using Project.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Dtos.Response
{
    public class GetUserDetailsResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public decimal Balance { get; set; }
        public List<Gundam> Gundams { get; set; }
    }
}
