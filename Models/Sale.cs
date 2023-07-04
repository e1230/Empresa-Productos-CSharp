namespace Empresa_Productos.Models;

public class Sale
{
  public Guid Id { get; set; }
  public int amount { get; set; }
  public Tax Tax { get; set; }
  public DateTime SaleDate { get; set; }
  public double finalPrice { get; set; }
  public virtual required User User { get; set; }
  public virtual required Product Product { get; set; }
}

public enum Tax
{
  Tax0Percent = 0,
  Tax15Percent = 15,
  Tax19Percent = 19
}