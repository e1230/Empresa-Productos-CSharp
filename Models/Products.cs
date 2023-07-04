namespace Empresa_Productos.Models;

public class Product
{
  public Guid Id { get; set; }
  public required string SupplierId { get; set; }
  public required string Name { get; set; }
  public int Price { get; set; }
  public DateTime CreationDate { get; set; }
  public string? Photo_url { get; set; }
  public virtual Supplier Supplier { get; set; }
  public virtual ICollection<Sale>? Sales { get; set; }

}
