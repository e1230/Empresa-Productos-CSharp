using Empresa_Productos.Models;
using Microsoft.EntityFrameworkCore;

namespace Empresa_Productos.Services;
public class SaleService : ISaleService
{
  Context context;
  public SaleService(Context dbContext)
  {
    context = dbContext;
  }
  public async Task<IEnumerable<Sale>> Get()
  {
    return await Task.FromResult(context.Sales.Include(p => p.User).Include(p => p.Product).ThenInclude(p => p.Supplier));
  }
  public async Task Save(Sale sale)
  {
    sale.Id = Guid.NewGuid();
    sale.SaleDate = DateTime.Now;
    // sale.FinalPrice = 0;
    var product = await context.Products.FindAsync(sale.ProductId);
    if (product != null)
    {
      double totalPrice = (double)((sale.Amount * product.Price) + (sale.Amount * product.Price * ((int)sale.Tax) / 100));
      sale.FinalPrice = totalPrice;
    }
    else
    {
      sale.FinalPrice = 0;
    }
    await context.AddAsync(sale);
    await context.SaveChangesAsync();
  }

  public async Task Update(Sale sale, Guid id)
  {
    var actualSale = context.Sales.Find(id);
    if (actualSale != null)
    {
      actualSale.UserNit = sale.UserNit ?? actualSale.UserNit;
      actualSale.ProductId = sale.ProductId ?? actualSale.ProductId;
      actualSale.Amount = sale.Amount ?? actualSale.Amount;
      actualSale.Tax = sale.Tax ?? actualSale.Tax;
      actualSale.SaleDate = sale.SaleDate ?? actualSale.SaleDate;

      var product = await context.Products.FindAsync(sale.ProductId);
      if (product != null)
      {
        double totalPrice = (double)((actualSale.Amount * product.Price) + (actualSale.Amount * product.Price * ((int)actualSale.Tax) / 100));
        actualSale.FinalPrice = totalPrice;
      }
      await context.SaveChangesAsync();
    }
    else
    {
      throw new InvalidOperationException("Sale Not Found.");
    }
  }
  public async Task Delete(Guid id)
  {
    var actualSale = context.Sales.Find(id);
    if (actualSale != null)
    {
      context.Remove(actualSale);
      await context.SaveChangesAsync();
    }
    else
    {
      throw new InvalidOperationException("Sale Not Found.");
    }

  }
}

public interface ISaleService
{
  Task<IEnumerable<Sale>> Get();
  Task Save(Sale sale);
  Task Update(Sale sale, Guid id);
  Task Delete(Guid id);
}