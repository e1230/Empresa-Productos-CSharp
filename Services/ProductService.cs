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
  public async Task<IEnumerable<Product>> Get()
  {
    return await Task.FromResult(context.Products.Include(p => p.Supplier));
  }
  public async Task<Product> GetById(Guid id)
  {
    return await context.Products.Include(p => p.Supplier).FirstOrDefaultAsync(p => p.Id == id);
  }
  public async Task Save(Product product)
  {
    product.Id = Guid.NewGuid();
    product.CreationDate = DateTime.Now;
    await context.AddAsync(product);
    await context.SaveChangesAsync();
  }
  public async Task Update(Product product, Guid id)
  {
    var actualProduct = context.Products.Find(id);
    if (actualProduct != null)
    {
      actualProduct.Name = product.Name ?? actualProduct.Name;
      actualProduct.Price = product.Price ?? actualProduct.Price;
      actualProduct.CreationDate = product.CreationDate ?? actualProduct.CreationDate;
      actualProduct.Photo_url = product.Photo_url ?? actualProduct.Photo_url;
      actualProduct.SupplierId = product.SupplierId ?? actualProduct.SupplierId;
      await context.SaveChangesAsync();
    }
    else
    {
      throw new InvalidOperationException("Product Not Found.");
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
    else
    {
      throw new InvalidOperationException("Product Not Found.");
    }

  }
}

public interface IProductService
{
  Task<IEnumerable<Product>> Get();
  Task<Product> GetById(Guid id);
  Task Save(Product product);
  Task Update(Product product, Guid id);
  Task Delete(Guid id);
}