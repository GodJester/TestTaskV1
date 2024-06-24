using Microsoft.EntityFrameworkCore;
using TT.API.Dto;
using TT.API.Interfaces;
using TT.Engine.DbContexts;
using TT.Engine.Entities;

namespace TT.API.Services;

public class ProductService : IProductService
{
    private readonly TestTaskDbContext _testTaskDbContext;

    public ProductService(TestTaskDbContext testTaskDbContext)
    {
        _testTaskDbContext = testTaskDbContext;
    }

    public async Task<ProductDto> CreateProductAsync(ProductDto productDto, CancellationToken cancellationToken)
    {
        var newProduct = new Product
        {
            Id = Guid.NewGuid(),
            Name = productDto.Name,
            Price = productDto.Price,
            QuantityInStock = productDto.QuantityInStock
        };

        _testTaskDbContext.Products.Add(newProduct);
        await _testTaskDbContext.SaveChangesAsync(cancellationToken);
        return new ProductDto
        {
            Name = newProduct.Name,
            Price = newProduct.Price,
            QuantityInStock = newProduct.QuantityInStock
        };
    }

    public async Task DeleteProductAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await _testTaskDbContext.Products
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (product == null)
        {
            throw new Exception("product not found");
        }

        _testTaskDbContext.Products.Remove(product);
        await _testTaskDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<ProductDto>> GetAllProducts(CancellationToken cancellationToken)
    {
        var products = await _testTaskDbContext.Products.ToListAsync(cancellationToken);

        var productDto = products.Select(product => new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            QuantityInStock = product.QuantityInStock
            
        }).ToList();

        return productDto;
    }
}