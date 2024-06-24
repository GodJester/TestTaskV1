using Microsoft.EntityFrameworkCore;
using TT.Engine.Entities;

namespace TT.Engine.DbContexts;

public class TestTaskDbContext : DbContext
{
    public TestTaskDbContext(DbContextOptions<TestTaskDbContext> options) : base(options)
    {
    }
    
    
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductInOrder> ProductsInOrders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("TestTask");
        modelBuilder.ApplyConfigurationsFromAssembly(assembly: typeof(TestTaskDbContext).Assembly);
    }
}