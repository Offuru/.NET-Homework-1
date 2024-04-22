using Project.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Repositories
{
    public class BaseRepository
    {
        protected ProjectDbContext dbContext {  get; set; }

        public BaseRepository(ProjectDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
