namespace TT.API.Dto;

public class ProductInOrderDto
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int QuantityOfProduct { get; set; }
}