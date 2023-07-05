using Empresa_Productos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Empresa_Productos.Migrations.Seeds
{
  public static class SeedData
  {
    public static void Seed(ModelBuilder modelBuilder)
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

      modelBuilder.Entity<User>().HasData(userInit);
      modelBuilder.Entity<Supplier>().HasData(supplierInit);
      modelBuilder.Entity<Product>().HasData(productInit);
      modelBuilder.Entity<Sale>().HasData(saleInit);
    }
  }
}
