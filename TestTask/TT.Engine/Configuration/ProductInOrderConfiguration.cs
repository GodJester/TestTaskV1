using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TT.Engine.Entities;

namespace TT.Engine.Configuration;

public class ProductInOrderConfiguration : IEntityTypeConfiguration<ProductInOrder>
{
    public void Configure(EntityTypeBuilder<ProductInOrder> builder)
    {
        builder.HasKey(x => new { x.OrderId, x.ProductId });
    }
}