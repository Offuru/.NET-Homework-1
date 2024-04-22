using Project.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gundam = Project.Database.Entities.Gundam;

namespace Project.Database.Repositories
{
    public class GundamsRepository : BaseRepository
    {
        public GundamsRepository(ProjectDbContext context) : base(context) { }

        public void Add(Gundam gundam)
        {
            dbContext.Gundams.Add(gundam);
            SaveChanges();
        }

        public void AddRange(List<Gundam> gundams)
        {
            dbContext.Gundams.AddRange(gundams);
            SaveChanges();
        }

        public Gundam GetById(int id)
        {
            var result = dbContext.Gundams
                .Where(g => g.Id == id)
                .Where(g => g.DateDeleted == null)
                .FirstOrDefault();

            return result;
        }

        public void DeleteGundam(Gundam gundam)
        {
            gundam.DateDeleted = DateTime.UtcNow;
            SaveChanges();
        }
    }
}
