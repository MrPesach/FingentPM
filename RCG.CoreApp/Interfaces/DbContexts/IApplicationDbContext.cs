using System.Data;
using Microsoft.EntityFrameworkCore;
using RCG.Domain.Entities;

namespace RCG.CoreApp.Interfaces.DbContexts
{
    public interface IApplicationDbContext
    {
        IDbConnection Connection { get; }

        DbSet<Users> Users { get; set; }

        DbSet<ProductMain> ProductMain { get; set; }

        DbSet<Products> Products { get; set; }

        DbSet<ApplConfigs> ApplConfigs { get; set; }
    }
}