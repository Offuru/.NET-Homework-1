﻿using Project.Database.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Entities
{
    public class Gundam : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
        public string Scale { get; set; }
        public decimal Price { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Series {  get; set; }
        public bool Available { get; set; }
        public int? AssignedUserId { get; set; }
        public User User { get; set; } = null;
    }
}
