using Microsoft.EntityFrameworkCore;
using Empresa_Productos.Models;
using Empresa_Productos.Builder;

namespace Empresa_Productos;

public class Context : DbContext
{
  public DbSet<User> Users { get; set; }
  public DbSet<Supplier> Suppliers { get; set; }
  public DbSet<Product> Products { get; set; }
  public DbSet<Sale> Sales { get; set; }
  public Context(DbContextOptions<Context> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ConfigureEntities();
  }
}