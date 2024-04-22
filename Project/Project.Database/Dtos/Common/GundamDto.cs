using Project.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Dtos.Common
{
    public class GundamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
        public string Scale { get; set; }
        public decimal Price { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Series { get; set; }
        public bool Available { get; set; }
        public UserDto User { get; set; } = null!;
    }
}
