namespace TT.Engine.Entities;

public class Order
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Status { get; set; }
}