
using Bogus;
using Api.Models;


namespace Api.Data;

public static class DbInitialiser
{
  public static void Seed(ApiDbContext context)
  {
    if (context.Products.Any())
    {
      return; // Already seeded
    }

    var faker = new Faker<Product>()
      .RuleFor(p => p.Name, f => f.Commerce.ProductName())
      .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
      .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price()))
      .RuleFor(p => p.Stock, f => f.Random.Int(0, 100));

    List<Product>? products = faker.Generate(500);

    context.Products.AddRange(products);
    context.SaveChanges();
  }
  
}
