using FinShark.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinShark.API.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }
    
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }
}