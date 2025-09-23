
using Api.Models.DTOs;
using Api.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<ProductListDto>> GetProducts()
    {
        ProductListDto result = await _service.GetProducts();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDetailDto>> GetProduct(int id)
    {
        ProductDetailDto? result = await _service.GetProductById(id);
        return result == null ? NotFound() : Ok(result);
    }
}