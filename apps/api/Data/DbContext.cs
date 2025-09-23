
using Microsoft.EntityFrameworkCore;
using Api.Models;


namespace Api.Data
{
  public class ApiDbContext : DbContext
  {
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
  }
  
}