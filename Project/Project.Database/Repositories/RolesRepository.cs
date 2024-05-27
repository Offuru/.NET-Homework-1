using Microsoft.EntityFrameworkCore;
using Project.Database.Context;
using Project.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Repositories
{
    public class RolesRepository : BaseRepository
    {
        
        public RolesRepository(ProjectDbContext dbContext) : base(dbContext) { }

        public Role GetRoleById(int id)
        {
            var result = dbContext.Roles
                .Where(r => r.Id == id)
                .FirstOrDefault();

            return result;
        }
    }
}
