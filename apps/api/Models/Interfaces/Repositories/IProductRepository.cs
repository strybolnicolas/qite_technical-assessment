
using Api.Models.Classes;

namespace Api.Models.Interfaces;

public interface IProductRepository
{
  Task<List<Product>> GetAll();
  Task<Product?> GetById(int id);
}
