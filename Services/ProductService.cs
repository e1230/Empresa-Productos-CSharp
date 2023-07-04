using Empresa_Productos.Models;
using Microsoft.EntityFrameworkCore;

namespace Empresa_Productos.Services;
public class ProductService : IProductService
{
  Context context;
  public ProductService(Context dbContext)
  {
    context = dbContext;
  }
  public IEnumerable<Product> Get()
  {
    return context.Products;
  }
  public async Task Save(Product product)
  {
    await context.AddAsync(product);
    await context.SaveChangesAsync();
  }
  public async Task Update(Product product, Guid id)
  {
    var actualProduct = context.Products.Find(id);
    if (actualProduct != null)
    {
      actualProduct.Name = product.Name;
      actualProduct.Price = product.Price;
      actualProduct.CreationDate = product.CreationDate;
      actualProduct.Photo_url = product.Photo_url;
      actualProduct.SupplierId = product.SupplierId;
      await context.SaveChangesAsync();
    }
  }
  public async Task Delete(Guid id)
  {
    var actualProduct = context.Products.Find(id);
    if (actualProduct != null)
    {
      context.Remove(actualProduct);
      await context.SaveChangesAsync();
    }

  }
}

public interface IProductService
{
  IEnumerable<Product> Get();
  Task Save(Product product);
  Task Update(Product product, Guid id);
  Task Delete(Guid id);
}