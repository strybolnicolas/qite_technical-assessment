
using Api.Data;
using Api.Models;
using Api.Repositories;
using Api.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiDbContext>(options =>
    // options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    // When switching to SQlServer, uncomment the above line and comment the line below.
    options.UseInMemoryDatabase("TestDb"));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seeding with fake data
using (var scope = app.Services.CreateScope())
{
  DbInitialiser.Seed(scope.ServiceProvider.GetRequiredService<ApiDbContext>());
}

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
