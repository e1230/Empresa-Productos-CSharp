namespace Empresa_Productos.Models;

public class Supplier
{
  public Guid Nit { get; set; }
  public required string Name { get; set; }
  public string? Tel { get; set; }
  public string? Cel { get; set; }
  public string? Email { get; set; }
  public virtual ICollection<Product>? Products { get; set; }
}