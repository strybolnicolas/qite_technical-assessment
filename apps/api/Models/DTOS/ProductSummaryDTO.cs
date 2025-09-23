

namespace Api.Models.DTOs;

public class ProductSummaryDto
{
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public decimal Price { get; set; }
}
