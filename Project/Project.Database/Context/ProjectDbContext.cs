using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using Project.Database.Entities;

namespace Project.Database.Context
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Gundam> Gundams { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("Host=localhost;Database=gundams;Username=postgres;Password=1q2w3e");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<Gundam>()
                .HasKey(g => g.Id);
            modelBuilder.Entity<Role>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Gundams)
                .WithOne(g => g.User)
                .HasForeignKey(u => u.Id).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(r => r.Id).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
