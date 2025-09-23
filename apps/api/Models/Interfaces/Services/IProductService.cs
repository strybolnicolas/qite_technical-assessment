
using Api.DTOs;


namespace Api.Models;

public interface IProductService
{
  Task<ProductListDto> GetProducts();
  Task<ProductDetailDto?> GetProductById(int id);
}
