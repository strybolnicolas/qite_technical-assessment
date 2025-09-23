
using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;


namespace Api.Repositories;

public class ProductRepository : IProductRepository
{
  private readonly ApiDbContext _context;

  public ProductRepository(ApiDbContext context)
  {
    _context = context;
  }

  public async Task<List<Product>> GetAll()
  {
    return await _context.Products.ToListAsync();
  }

  public async Task<Product?> GetById(int id)
  {
    return await _context.Products.FindAsync(id);
  }

}