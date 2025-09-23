
namespace Api.Models.DTOs
{
  public class ProductListDto
  {
    public List<ProductSummaryDto> Items { get; set; } = new();
    public int TotalCount { get; set; }
  }
}
