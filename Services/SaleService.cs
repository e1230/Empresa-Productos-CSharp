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

  public async Task<IEnumerable<Sale>> GetByDateRange(string startDate, string endDate)
  {
    DateTime parsedStartDate;
    DateTime parsedEndDate;

    if (!DateTime.TryParse(startDate, out parsedStartDate) || !DateTime.TryParse(endDate, out parsedEndDate))
    {
      throw new ArgumentException("Invalid date format. Please use the format yyyy-MM-dd.");
    }

    parsedStartDate = parsedStartDate.Date;
    parsedEndDate = parsedEndDate.Date.AddDays(1).AddMilliseconds(-1);

    return await context.Sales
        .Where(s => s.SaleDate >= parsedStartDate && s.SaleDate <= parsedEndDate)
        .Include(p => p.User)
        .Include(p => p.Product)
        .ThenInclude(p => p.Supplier)
        .ToListAsync();
  }

  public async Task<IEnumerable<object>> GetTopSellingUsersByDateRange(string startDate, string endDate)
  {
    DateTime parsedStartDate;
    DateTime parsedEndDate;

    if (!DateTime.TryParse(startDate, out parsedStartDate) || !DateTime.TryParse(endDate, out parsedEndDate))
    {
      throw new ArgumentException("Invalid date format. Please use the format yyyy-MM-dd.");
    }

    parsedStartDate = parsedStartDate.Date;
    parsedEndDate = parsedEndDate.Date.AddDays(1).AddMilliseconds(-1);

    var topSellingUsers = await context.Sales
        .Where(s => s.SaleDate >= parsedStartDate && s.SaleDate <= parsedEndDate)
        .GroupBy(s => s.User.Name)
        .Select(group => new
        {
          Name = group.Key,
          TotalSales = group.Sum(s => s.FinalPrice) ?? 0
        })
        .OrderByDescending(s => s.TotalSales)
        .ToListAsync();

    return topSellingUsers.Select(user => new
    {
      Name = user.Name,
      TotalSales = user.TotalSales
    });
  }


  public async Task<IEnumerable<object>> GetTopSellingProductsByDateRange(string startDate, string endDate)
  {
    DateTime parsedStartDate;
    DateTime parsedEndDate;

    if (!DateTime.TryParse(startDate, out parsedStartDate) || !DateTime.TryParse(endDate, out parsedEndDate))
    {
      throw new ArgumentException("Invalid date format. Please use the format yyyy-MM-dd.");
    }

    parsedStartDate = parsedStartDate.Date;
    parsedEndDate = parsedEndDate.Date.AddDays(1).AddMilliseconds(-1);

    var topSellingProducts = await context.Sales
        .Where(s => s.SaleDate >= parsedStartDate && s.SaleDate <= parsedEndDate)
        .GroupBy(s => s.Product!.Name)
        .Select(group => new
        {
          Name = group.Key,
          TotalAmount = group.Sum(s => s.Amount) ?? 0
        })
        .OrderByDescending(s => s.TotalAmount)
        .ToListAsync();

    return topSellingProducts.Select(product => new
    {
      ProductName = product.Name,
      TotalAmount = product.TotalAmount
    });
  }



}

public interface ISaleService
{
  Task<IEnumerable<Sale>> Get();
  Task Save(Sale sale);
  Task Update(Sale sale, Guid id);
  Task Delete(Guid id);
  Task<IEnumerable<Sale>> GetByDateRange(string startDate, string endDate);
  Task<IEnumerable<object>> GetTopSellingUsersByDateRange(string startDate, string endDate);
  Task<IEnumerable<object>> GetTopSellingProductsByDateRange(string startDate, string endDate);

}