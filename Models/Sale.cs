namespace Empresa_Productos.Models;

public class Sale
{
  public Guid Id { get; set; }
  public Guid UserNit { get; set; }
  public Guid ProductId { get; set; }
  public int Amount { get; set; }
  public Tax Tax { get; set; }
  public DateTime SaleDate { get; set; }
  public double FinalPrice { get; set; }
  public virtual User User { get; set; }
  public virtual Product Product { get; set; }
}

public enum Tax
{
  Tax0Percent = 0,
  Tax15Percent = 15,
  Tax19Percent = 19
}