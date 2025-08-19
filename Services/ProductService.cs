using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services;

public class ProductService : PageService<Product>, IProductService
{
    public ProductService(TestDbContext ctx) : base(ctx) { }
}
