using Microsoft.EntityFrameworkCore;
using Empresa_Productos.Models;

namespace Empresa_Productos;

public class Context : DbContext
{
  public DbSet<User> Users { get; set; }
  public DbSet<Supplier> Suppliers { get; set; }
  public DbSet<Product> Products { get; set; }
  public DbSet<Sale> Sales { get; set; }
  public Context(DbContextOptions<Context> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    List<User> userInit = new List<User>();
    userInit.Add(new User()
    {
      Nit = "1013",
      Name = "Edgar",
      UserName = "E1230",
      Password = "850518",
      Role = Role.Admin
    });
    userInit.Add(new User()
    {
      Nit = "8080",
      Name = "Jose",
      UserName = "J87",
      Password = "12xx",
      Role = Role.Vendor
    });
    userInit.Add(new User()
    {
      Nit = "1398",
      Name = "Diana",
      UserName = "DIANA",
      Password = "asd85",
      Role = Role.Vendor
    });
    modelBuilder.Entity<User>(user =>
    {
      user.ToTable("User");
      user.HasKey(p => p.Nit);
      user.Property(p => p.Name).IsRequired();
      user.Property(p => p.UserName).IsRequired();
      user.Property(p => p.Password).IsRequired();
      user.Property(p => p.Role);
      user.HasData(userInit);
    });
    List<Supplier> supplierInit = new List<Supplier>();
    supplierInit.Add(new Supplier()
    {
      Nit = "9027",
      Name = "Ana",
      Cel = "3101285739",
      Email = "ana@correo.com"
    });
    supplierInit.Add(new Supplier()
    {
      Nit = "2271",
      Name = "Manuel",
      Tel = "6017922798",
      Cel = "3158429046",
      Email = "manuel@correo.com"
    });
    modelBuilder.Entity<Supplier>(supplier =>
    {
      supplier.ToTable("Supplier");
      supplier.HasKey(p => p.Nit);
      supplier.Property(p => p.Name).IsRequired();
      supplier.Property(p => p.Tel).IsRequired(false);
      supplier.Property(p => p.Cel).IsRequired(false);
      supplier.Property(p => p.Email).IsRequired(false);
      supplier.HasData(supplierInit);
    });
    List<Product> productInit = new List<Product>();
    productInit.Add(new Product()
    {
      Id = Guid.Parse("f7d31d43-485b-4499-9502-97c3cf0c8100"),
      SupplierId = "9027",
      Name = "Televisor",
      Price = 1200000,
      CreationDate = DateTime.Now,
    });
    productInit.Add(new Product()
    {
      Id = Guid.Parse("f7d31d43-485b-4499-9502-97c3cf0c8101"),
      SupplierId = "9027",
      Name = "Computador",
      Price = 1800000,
      CreationDate = DateTime.Now,
    });
    productInit.Add(new Product()
    {
      Id = Guid.Parse("f7d31d43-485b-4499-9502-97c3cf0c8102"),
      SupplierId = "9027",
      Name = "Equipo de sonido",
      Price = 900000,
      CreationDate = DateTime.Now,
    });
    productInit.Add(new Product()
    {
      Id = Guid.Parse("f7d31d43-485b-4499-9502-97c3cf0c8103"),
      SupplierId = "2271",
      Name = "Cortinas",
      Price = 250000,
      CreationDate = DateTime.Now,
    });
    productInit.Add(new Product()
    {
      Id = Guid.Parse("f7d31d43-485b-4499-9502-97c3cf0c8104"),
      SupplierId = "2271",
      Name = "Armario",
      Price = 900000,
      CreationDate = DateTime.Now,
    });
    modelBuilder.Entity<Product>(product =>
    {
      product.ToTable("Product");
      product.HasKey(p => p.Id);
      product.Property(p => p.Name).IsRequired();
      product.Property(p => p.Price);
      product.Property(p => p.CreationDate);
      product.Property(p => p.Photo_url).IsRequired(false);
      product.HasOne(p => p.Supplier).WithMany(p => p.Products).HasForeignKey(p => p.SupplierId);
      product.HasData(productInit);
    });
    List<Sale> saleInit = new List<Sale>();
    saleInit.Add(new Sale()
    {
      Id = Guid.Parse("f7d31d43-485b-4499-9502-97c3cf0e8100"),
      UserNit = "8080",
      ProductId = Guid.Parse("f7d31d43-485b-4499-9502-97c3cf0c8100"),
      Amount = 2,
      Tax = Tax.Tax19Percent,
      SaleDate = DateTime.Now,
      FinalPrice = 2400000
    });
    saleInit.Add(new Sale()
    {
      Id = Guid.Parse("f7d31d43-485b-4499-9502-97c3cf0e8101"),
      UserNit = "1398",
      ProductId = Guid.Parse("f7d31d43-485b-4499-9502-97c3cf0c8101"),
      Amount = 1,
      Tax = Tax.Tax19Percent,
      SaleDate = DateTime.Now,
      FinalPrice = 1800000
    });
    modelBuilder.Entity<Sale>(sale =>
    {
      sale.ToTable("Sale");
      sale.HasKey(p => p.Id);
      sale.Property(p => p.Amount);
      sale.Property(p => p.Tax);
      sale.Property(p => p.SaleDate);
      sale.Property(p => p.FinalPrice);
      sale.HasOne(p => p.User).WithMany(p => p.Sales).HasForeignKey(p => p.UserNit);
      sale.HasOne(p => p.Product).WithMany(p => p.Sales).HasForeignKey(p => p.ProductId);
      sale.HasData(saleInit);
    });
  }
}