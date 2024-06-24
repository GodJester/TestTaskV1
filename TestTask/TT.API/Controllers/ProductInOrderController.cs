using Microsoft.AspNetCore.Mvc;
using TT.API.Dto;
using TT.API.Interfaces;

namespace TT.API.Controllers;

[Route("api/ProductsInOrder")]
[ApiController]
public class ProductInOrderController : ControllerBase
{
    private readonly IProductInOrderService _productInOrderService;

    public ProductInOrderController(IProductInOrderService productInOrderService)
    {
        _productInOrderService = productInOrderService;
    }

    [HttpPost("{orderId}/{productId}")]
    public async Task<ActionResult<ProductInOrderDto>> AddProductToOrder(Guid orderId, Guid productId,
        [FromBody] ProductInOrderDto productInOrderDto, CancellationToken cancellationToken)
    {
        var newProductInOrder =
            await _productInOrderService.AddProductToOrderAsync(orderId, productId, productInOrderDto,
                cancellationToken);
        return Ok();
    }

    [HttpDelete("{orderId}/{productId}")]
    public async Task<ActionResult> DeleteProductFromOrder(Guid orderId, Guid productId,
        CancellationToken cancellationToken)
    {
            await _productInOrderService.DeleteProductFromOrderAsync(orderId, productId, cancellationToken);
            return Ok();
    }

    [HttpGet("{orderId}")]
    public async Task<ActionResult<List<ProductInOrderDto>>> GetAllProductsInOrder(Guid orderId,
        CancellationToken cancellationToken)
    {
        var productsInOrder = await _productInOrderService.GetAllProductsInOrder(orderId, cancellationToken);
        return Ok(productsInOrder);
    }
}