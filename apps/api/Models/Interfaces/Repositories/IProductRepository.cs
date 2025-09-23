
namespace Api.Models;

public interface IProductRepository
{
  Task<List<Product>> GetAll();
  Task<Product?> GetById(int id);
}
