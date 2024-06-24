using Microsoft.EntityFrameworkCore;
using TT.API.Dto;
using TT.API.Interfaces;
using TT.Engine.DbContexts;
using TT.Engine.Entities;

namespace TT.API.Services;

public class OrderService : IOrderService
{
    private readonly TestTaskDbContext _testTaskDbContext;

    public OrderService(TestTaskDbContext testTaskDbContext)
    {
        _testTaskDbContext = testTaskDbContext;
    }

    public async Task<OrderDto> CreateOrderAsync(OrderDto orderDto, CancellationToken cancellationToken)
    {
        var newOrder = new Order
        {
            Id = Guid.NewGuid(),
            CreatedAt = orderDto.CreatedAt,
            Status = orderDto.Status
        };

        _testTaskDbContext.Orders.Add(newOrder);
        await _testTaskDbContext.SaveChangesAsync(cancellationToken);
        return new OrderDto
        {
            CreatedAt = newOrder.CreatedAt,
            Status = newOrder.Status
        };
    }

    public async Task DeleteOrderAsync(Guid id, CancellationToken cancellationToken)
    {
        var order = await _testTaskDbContext.Orders
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (order == null)
        {
            throw new Exception("order not found");
        }

        _testTaskDbContext.Orders.Remove(order);
        var productsInOrderToDelete = _testTaskDbContext.ProductsInOrders
            .Where(x => x.OrderId == id);

        _testTaskDbContext.ProductsInOrders.RemoveRange(productsInOrderToDelete);
        await _testTaskDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<OrderDto>> GetAllOrders(CancellationToken cancellationToken)
    {
        var orders = await _testTaskDbContext.Orders.ToListAsync(cancellationToken);

        var orderDto = orders.Select(order => new OrderDto
        {
            Id = order.Id,
            CreatedAt = order.CreatedAt,
            Status = order.Status
        }).ToList();

        return orderDto;
    }
}