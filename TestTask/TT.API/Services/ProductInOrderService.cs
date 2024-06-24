using Microsoft.EntityFrameworkCore;
using TT.API.Dto;
using TT.API.Interfaces;
using TT.Engine.DbContexts;
using TT.Engine.Entities;

namespace TT.API.Services;

public class ProductInOrderService : IProductInOrderService
{
    private readonly TestTaskDbContext _testTaskDbContext;

    public ProductInOrderService(TestTaskDbContext testTaskDbContext)
    {
        _testTaskDbContext = testTaskDbContext;
    }


    public async Task<ProductInOrderDto> AddProductToOrderAsync(Guid orderId, Guid productId,
        ProductInOrderDto productInOrderDto,
        CancellationToken cancellationToken)
    {
        var newProductInOrder = new ProductInOrder
        {
            OrderId = orderId,
            ProductId = productId,
            QuantityOfProduct = productInOrderDto.QuantityOfProduct
        };

        _testTaskDbContext.ProductsInOrders.Add(newProductInOrder);
        await _testTaskDbContext.SaveChangesAsync(cancellationToken);
        return new ProductInOrderDto
        {
            OrderId = newProductInOrder.OrderId,
            ProductId = newProductInOrder.ProductId,
            QuantityOfProduct = newProductInOrder.QuantityOfProduct
        };
    }

    public async Task DeleteProductFromOrderAsync(Guid orderId, Guid productId, CancellationToken cancellationToken)
    {
        var productInOrder = await _testTaskDbContext.ProductsInOrders
            .FirstOrDefaultAsync(x => x.OrderId == orderId && x.ProductId == productId, cancellationToken);
        if (productInOrder == null)
        {
            throw new Exception("product in order not found");
        }

        _testTaskDbContext.ProductsInOrders.Remove(productInOrder);
        await _testTaskDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<ProductInOrderDto>> GetAllProductsInOrder(Guid orderId, CancellationToken cancellationToken)
    {
        var productsInOrder = await _testTaskDbContext.ProductsInOrders
            .Where(x => x.OrderId == orderId)
            .ToListAsync(cancellationToken);
        
        var productInOrderDto = productsInOrder.Select(productInOrder => new ProductInOrderDto
        {
            OrderId = productInOrder.OrderId,
            ProductId = productInOrder.ProductId,
            QuantityOfProduct = productInOrder.QuantityOfProduct
        }).ToList();

        return productInOrderDto;
    }
}