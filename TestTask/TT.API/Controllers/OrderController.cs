using Microsoft.AspNetCore.Mvc;
using TT.API.Dto;
using TT.API.Interfaces;
using TT.Engine.Entities;

namespace TT.API.Controllers;

[ApiController]
[Route("api/v1/Order")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<ActionResult<OrderDto>> CreateOrder(OrderDto orderDto, CancellationToken cancellationToken)
    {
        var newOrder = await _orderService.CreateOrderAsync(orderDto, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOrder(Guid id, CancellationToken cancellationToken)
    {
        await _orderService.DeleteOrderAsync(id, cancellationToken);
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<List<OrderDto>>> GetAllOrders(CancellationToken cancellationToken)
    {
        var orders = await _orderService.GetAllOrders(cancellationToken);
        return Ok(orders);
    }
}