using Microsoft.AspNetCore.Mvc;
using TT.API.Dto;
using TT.API.Interfaces;

namespace TT.API.Controllers;

[Route("api/Products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] ProductDto productDto,
        CancellationToken cancellationToken)
    {
        var newProduct = await _productService.CreateProductAsync(productDto, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(Guid id, CancellationToken cancellationToken)
    {
        await _productService.DeleteProductAsync(id, cancellationToken);
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductDto>>> GetAllProducts(CancellationToken cancellationToken)
    {
        var products = await _productService.GetAllProducts(cancellationToken);
        return Ok(products);
    }
}