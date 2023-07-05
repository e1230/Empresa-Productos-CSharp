using Empresa_Productos.Migrations.Seeds;
using Empresa_Productos.Models;
using Microsoft.EntityFrameworkCore;

namespace Empresa_Productos.Builder
{
  public static class ModelBuilderExtensions
  {
    public static void ConfigureEntities(this ModelBuilder modelBuilder)
    {
      SeedData.Seed(modelBuilder);

      modelBuilder.Entity<User>(user =>
    {
      user.ToTable("User");
      user.HasKey(p => p.Nit);
      user.Property(p => p.Name).IsRequired();
      user.Property(p => p.UserName).IsRequired();
      user.Property(p => p.Password).IsRequired();
      user.Property(p => p.Role);
    });

      modelBuilder.Entity<Supplier>(supplier =>
    {
      supplier.ToTable("Supplier");
      supplier.HasKey(p => p.Nit);
      supplier.Property(p => p.Name).IsRequired();
      supplier.Property(p => p.Tel).IsRequired(false);
      supplier.Property(p => p.Cel).IsRequired(false);
      supplier.Property(p => p.Email).IsRequired(false);
    });

      modelBuilder.Entity<Product>(product =>
    {
      product.ToTable("Product");
      product.HasKey(p => p.Id);
      product.Property(p => p.Name).IsRequired();
      product.Property(p => p.Price);
      product.Property(p => p.CreationDate);
      product.Property(p => p.Photo_url).IsRequired(false);
      product.HasOne(p => p.Supplier).WithMany(p => p.Products).HasForeignKey(p => p.SupplierId);
    });

      modelBuilder.Entity<Sale>(sale =>
    {
      sale.ToTable("Sale");
      sale.HasKey(p => p.Id);
      sale.Property(p => p.Amount);
      sale.Property(p => p.Tax);
      sale.Property(p => p.SaleDate);
      sale.Property(p => p.FinalPrice);
      sale.HasOne(p => p.User).WithMany(p => p.Sales).HasForeignKey(p => p.UserNit);
      sale.HasOne(p => p.Product).WithMany(p => p.Sales).HasForeignKey(p => p.ProductId);
    });
    }
  }
}
