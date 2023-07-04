namespace Empresa_Productos.Models;

public class User
{
  public Guid Nit { get; set; }
  public required string Name { get; set; }
  public required string UserName { get; set; }
  public required string Password { get; set; }
  public Role Role { get; set; }
  public virtual ICollection<Sale>? Sales { get; set; }
}

public enum Role
{
  Admin,
  Vendor
}