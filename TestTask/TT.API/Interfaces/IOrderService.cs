using TT.API.Dto;

namespace TT.API.Interfaces;

public interface IOrderService
{
    Task<OrderDto> CreateOrderAsync(OrderDto orderDto, CancellationToken cancellationToken);
    Task DeleteOrderAsync(Guid id, CancellationToken cancellationToken);
    Task<List<OrderDto>> GetAllOrders(CancellationToken cancellationToken);
}