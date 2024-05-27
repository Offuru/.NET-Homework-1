using Microsoft.EntityFrameworkCore;
using Project.Database.Context;
using Project.Database.Dtos.Common;
using Project.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = Project.Database.Entities.User;

namespace Project.Database.Repositories
{
    public class UsersRepository : BaseRepository
    {

        public UsersRepository(ProjectDbContext dbContext) : base(dbContext) { }

        public void Add(User user)
        {
            dbContext.Add(user);
            SaveChanges();
        }

        public void AddRange(List<User> users)
        {
            dbContext.AddRange(users);
            SaveChanges();
        }

        public User GetById(int id)
        {
            var result = dbContext.Users
                .Where(u => u.Id == id)
                .Where(u => u.DateDeleted == null)
                .Include(u => u.Gundams).ToList()
                .FirstOrDefault();

            return result;
        }

        public void DeleteUser(User user)
        {
            user.DateDeleted = DateTime.UtcNow;
            SaveChanges();
        }

        public User GetByEmail(string email)
        {
            var result = dbContext.Users

                .Where(e => e.Email == email)
                .Where(e => e.DateDeleted == null)

                .FirstOrDefault();

            return result;
        }

        public bool ValidateUserId(int userId)
        {
            var result = dbContext.Users
                .Where(e => e.Id == userId)
                .Where(e => e.DateDeleted == null)

                .Any();

            return result;
        }
    }
}
