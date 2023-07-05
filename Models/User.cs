using System.Text.Json.Serialization;

namespace Empresa_Productos.Models;

public class User
{
  public string? Nit { get; set; }
  public string? Name { get; set; }
  public string? UserName { get; set; }
  public string? Password { get; set; }
  public Role? Role { get; set; }
  [JsonIgnore]
  public virtual ICollection<Sale>? Sales { get; set; }
}

public enum Role
{
  Admin,
  Vendor
}