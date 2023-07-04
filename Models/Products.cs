namespace Empresa_Productos.Models;

public class Product
{
  public Guid Id { get; set; }
  public required string Name { get; set; }
  public required int Price { get; set; }
  public DateTime CreationDate { get; set; }
  public string? Photo_url { get; set; }
  public virtual required Supplier Supplier { get; set; }
  public virtual ICollection<Sale>? Sales { get; set; }

}
