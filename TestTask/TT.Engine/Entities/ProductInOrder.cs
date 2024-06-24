namespace TT.Engine.Entities;

public class ProductInOrder
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int QuantityOfProduct { get; set; }
}