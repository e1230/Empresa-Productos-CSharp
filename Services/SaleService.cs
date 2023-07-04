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

  public IEnumerable<Sale> Get()
  {
    return context.Sales;
  }
  public async Task Save(Sale sale)
  {
    await context.AddAsync(sale);
    await context.SaveChangesAsync();
  }
  public async Task Update(Sale sale, Guid id)
  {
    var actualSale = context.Sales.Find(id);
    if (actualSale != null)
    {
      actualSale.UserNit = sale.UserNit;
      actualSale.ProductId = sale.ProductId;
      actualSale.Amount = sale.Amount;
      actualSale.Tax = sale.Tax;
      actualSale.SaleDate = sale.SaleDate;
      actualSale.FinalPrice = sale.FinalPrice;
      await context.SaveChangesAsync();
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

  }
}

public interface ISaleService
{
  IEnumerable<Sale> Get();
  Task Save(Sale sale);
  Task Update(Sale sale, Guid id);
  Task Delete(Guid id);
}