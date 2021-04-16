using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using RCG.CoreApp.Enums;
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
                    Username = "MusaSA",
                    PasswordHash = SecurityHelper.HashPassword("RCI@2w46m"),
                    IsAdmin = true,
                    CreatedOn = DateTime.UtcNow

                }
               );

            modelBuilder.Entity<ApplConfigs>().HasData(
                new ApplConfigs
                {
                    Id = 1,
                    Name = EnumMaster.ApplConfig.IndesignIndexFileSavePath.ToString(),
                    DisplayName = EnumMaster.GetDisplayValue(EnumMaster.ApplConfig.IndesignIndexFileSavePath),
                    Value = "C:\\Indesign\\IndexFiles\\",
                    ShowtoUser = true,
                    CreatedOn = DateTime.UtcNow
                }
               );
        }

    }
}

