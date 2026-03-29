using MiniERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using MiniERP_Application.DTOs;

namespace MiniERP_Infrastructure
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<User> Users => Set<User>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Sale> Sales => Set<Sale>();
        public DbSet<SaleItem> SaleItems => Set<SaleItem>();
        public DbSet<StockLedger> StockLedger => Set<StockLedger>();
        public DbSet<SpResponseDto> SpResponse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        var basePath = Path.Combine(Directory.GetCurrentDirectory());

            var configuration = new ConfigurationBuilder()
              .SetBasePath(basePath)
              .AddJsonFile("appsettings.json", optional: false)
              .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            // to be done

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>();
            modelBuilder.Entity<Role>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<RefreshToken>();
            modelBuilder.Entity<Customer>();
            modelBuilder.Entity<Sale>();
            modelBuilder.Entity<SaleItem>();
            modelBuilder.Entity<StockLedger>();

            modelBuilder.Entity<SpResponseDto>().HasNoKey();

        }

    }
}
