
using Api.Models.Classes;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class ApiDbContext : DbContext
{
  public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

  public DbSet<Product> Products { get; set; }

  public DbSet<User> Users { get; set; }
}
