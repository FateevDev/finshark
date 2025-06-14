using FinShark.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinShark.API.Data;

public class ApplicationDbContext(DbContextOptions dbContextOptions) : IdentityDbContext<User>(dbContextOptions)
{
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        ConfigurePortfolioEntity(builder);
        SeedIdentityRoles(builder);
    }

    private static void ConfigurePortfolioEntity(ModelBuilder builder)
    {
        builder.Entity<Portfolio>(entityTypeBuilder => entityTypeBuilder.HasKey(p => new { p.UserId, p.StockId }));
        builder.Entity<Portfolio>()
            .HasOne(portfolio => portfolio.User)
            .WithMany(user => user.Portfolios)
            .HasForeignKey(portfolio => portfolio.UserId);
        builder.Entity<Portfolio>()
            .HasOne(portfolio => portfolio.Stock)
            .WithMany(stock => stock.Portfolios)
            .HasForeignKey(portfolio => portfolio.StockId);
    }

    private static void SeedIdentityRoles(ModelBuilder builder)
    {
        List<IdentityRole> roles =
        [
            new() { Name = "Admin", NormalizedName = "ADMIN" },
            new() { Name = "User", NormalizedName = "USER" }
        ];

        builder.Entity<IdentityRole>().HasData(roles);
    }
}