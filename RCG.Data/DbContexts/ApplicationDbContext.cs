using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RCG.CoreApp.Helpers;
using RCG.CoreApp.Interfaces.DbContexts;
using RCG.CoreApp.Interfaces.Shared;
using RCG.Domain.Entities;


namespace RCG.Data.DbContexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Users> Users { get; set; }

        public DbSet<ProductMain> ProductMain { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<ApplConfigs> ApplConfigs { get; set; }

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

            modelBuilder.Entity<ApplConfigs>().HasData(
                new ApplConfigs
                {
                    Id = 1,
                    Name = "IndesignIndexFileSavePath",
                    DisplayName = "Indesign Index File Save Path",
                    Value = "C:\\Indesign\\IndexFiles\\",
                    ShowtoUser = true,
                    CreatedOn = DateTime.UtcNow
                }
               );
        }

    }
}

