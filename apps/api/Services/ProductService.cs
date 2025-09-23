

using Api.Models.Classes;
using Api.Models.DTOs;
using Api.Models.Interfaces;


namespace Api.Services;

public class ProductService : IProductService
{
  private readonly IProductRepository _productRepo;

  public ProductService(IProductRepository productRepo)
  {
    _productRepo = productRepo;
  }

  public async Task<ProductListDto> GetProducts()
  {
    List<Product> products = await _productRepo.GetAll();

    var summaries = products.Select(p => new ProductSummaryDto
    {
      Id = p.Id,
      Name = p.Name,
      Price = p.Price
    }).ToList();

    return new ProductListDto
    {
      Items = summaries,
      TotalCount = summaries.Count
    };
  }

  public async Task<ProductDetailDto?> GetProductById(int id)
  {
    Product? product = await _productRepo.GetById(id);
    if (product == null)
    {
      return null;
    }

    return new ProductDetailDto
      {
        Id = product.Id,
        Name = product.Name,
        Description = product.Description,
        Price = product.Price,
        Stock = product.Stock
      };
  }

}
