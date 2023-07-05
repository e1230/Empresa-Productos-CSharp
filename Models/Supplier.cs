using System.Text.Json.Serialization;

namespace Empresa_Productos.Models;

public class Supplier
{
  public string? Nit { get; set; }
  public string? Name { get; set; }
  public string? Tel { get; set; }
  public string? Cel { get; set; }
  public string? Email { get; set; }
  [JsonIgnore]
  public virtual ICollection<Product>? Products { get; set; }
}