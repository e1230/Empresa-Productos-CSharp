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

  public IEnumerable<Supplier> Get()
  {
    return context.Suppliers;
  }
  public async Task Save(Supplier supplier)
  {
    await context.AddAsync(supplier);
    await context.SaveChangesAsync();
  }
  public async Task Update(Supplier supplier, Guid id)
  {
    var actualSupplier = context.Suppliers.Find(id);
    if (actualSupplier != null)
    {
      actualSupplier.Name = supplier.Name;
      actualSupplier.Tel = supplier.Tel;
      actualSupplier.Cel = supplier.Cel;
      actualSupplier.Email = supplier.Email;
      await context.SaveChangesAsync();
    }
  }
  public async Task Delete(Guid id)
  {
    var actualSupplier = context.Suppliers.Find(id);
    if (actualSupplier != null)
    {
      context.Remove(actualSupplier);
      await context.SaveChangesAsync();
    }

  }
}

public interface ISupplierService
{
  IEnumerable<Supplier> Get();
  Task Save(Supplier supplier);
  Task Update(Supplier supplier, Guid id);
  Task Delete(Guid id);
}