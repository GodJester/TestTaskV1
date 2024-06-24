using TT.API.Dto;

namespace TT.API.Interfaces;

public interface IProductInOrderService
{
    Task<ProductInOrderDto> AddProductToOrderAsync(Guid orderId, Guid productId, ProductInOrderDto productInOrderDto, CancellationToken cancellationToken);
    Task DeleteProductFromOrderAsync(Guid orderId, Guid productId, CancellationToken cancellationToken);
    Task<List<ProductInOrderDto>> GetAllProductsInOrder(Guid orderId, CancellationToken cancellationToken);
}