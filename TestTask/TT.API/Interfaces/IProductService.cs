using TT.API.Dto;

namespace TT.API.Interfaces;

public interface IProductService
{
    Task<ProductDto> CreateProductAsync(ProductDto productDto, CancellationToken cancellationToken);
    Task DeleteProductAsync(Guid id, CancellationToken cancellationToken);
    Task<List<ProductDto>> GetAllProducts(CancellationToken cancellationToken);
}