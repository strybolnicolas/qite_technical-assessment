
using Api.Models.DTOs;

namespace Api.Models.Interfaces;

public interface IProductService
{
  Task<ProductListDto> GetProducts();
  Task<ProductDetailDto?> GetProductById(int id);
}
