using Empresa_Productos.Models;
using Microsoft.EntityFrameworkCore;

namespace Empresa_Productos.Services;

public class SupplierService : ISupplierService
{
  Context context;
  public SupplierService(Context dbContext)
  {
    context = dbContext;
  }
  public async Task<IEnumerable<Supplier>> Get()
  {
    return await Task.FromResult(context.Suppliers);
  }
  public async Task Save(Supplier supplier)
  {
    await context.AddAsync(supplier);
    await context.SaveChangesAsync();
  }
  public async Task Update(Supplier supplier, string id)
  {
    var actualSupplier = context.Suppliers.Find(id);
    if (actualSupplier != null)
    {
      actualSupplier.Name = supplier.Name ?? actualSupplier.Name;
      actualSupplier.Tel = supplier.Tel ?? actualSupplier.Tel;
      actualSupplier.Cel = supplier.Cel ?? actualSupplier.Cel;
      actualSupplier.Email = supplier.Email ?? actualSupplier.Email;
      await context.SaveChangesAsync();
    }
    else
    {
      throw new InvalidOperationException("Supplier Not Found.");
    }
  }
  public async Task Delete(string id)
  {
    var actualSupplier = context.Suppliers.Find(id);
    if (actualSupplier != null)
    {
      context.Remove(actualSupplier);
      await context.SaveChangesAsync();
    }
    else
    {
      throw new InvalidOperationException("Supplier Not Found.");
    }

  }
}

public interface ISupplierService
{
  Task<IEnumerable<Supplier>> Get();
  Task Save(Supplier supplier);
  Task Update(Supplier supplier, string id);
  Task Delete(string id);
}