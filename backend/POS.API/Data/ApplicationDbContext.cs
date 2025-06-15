using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using POS.API.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace POS.API.Data;

public class ApplicationDbContext : IdentityDbContext<User, Role, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<SaleItem> SaleItems => Set<SaleItem>();
    public DbSet<Receipt> Receipts => Set<Receipt>();
    public DbSet<InventoryLog> InventoryLogs => Set<InventoryLog>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connStr = Environment.GetEnvironmentVariable("MYSQL_CONNECTION");
            if (!string.IsNullOrEmpty(connStr))
            {
                optionsBuilder.UseMySql(connStr, new MySqlServerVersion(new Version(8,0,36)));
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Seed roles
        builder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
            new Role { Id = 2, Name = "Cashier", NormalizedName = "CASHIER" }
        );

        // Seed admin user
        var admin = new User
        {
            Id = 1,
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@example.com",
            NormalizedEmail = "ADMIN@EXAMPLE.COM",
            SecurityStamp = Guid.NewGuid().ToString("D")
        };
        var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<User>();
        admin.PasswordHash = hasher.HashPassword(admin, "Admin123!");

        builder.Entity<User>().HasData(admin);

        builder.Entity<Microsoft.AspNetCore.Identity.IdentityUserRole<int>>().HasData(
            new Microsoft.AspNetCore.Identity.IdentityUserRole<int> { RoleId = 1, UserId = 1 }
        );
    }
}
