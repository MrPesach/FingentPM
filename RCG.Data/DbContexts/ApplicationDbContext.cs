using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using RCG.CoreApp.Helpers;
using RCG.CoreApp.Interfaces.DbContexts;
using RCG.Domain.Entities;


namespace RCG.Data.DbContexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Users> Users { get; set; }

        public DbSet<ProductMain> ProductMain { get; set; }

        public IDbConnection Connection => Database.GetDbConnection();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    Id = 1,
                    Name = "Super Admin",
                    Username = "superadmin",
                    PasswordHash = SecurityHelper.HashPassword("password"),
                    //PasswordHash = SecurityHelper.HashPassword("rcQ$%^&*12FH"),
                    IsAdmin = true,
                    CreatedOn = DateTime.UtcNow

                }
               );
        }

    }
}

