using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Empresa_Productos.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Nit = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Nit);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Nit = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Nit);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Photo_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Nit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserNit = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Tax = table.Column<int>(type: "int", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sale_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sale_User_UserNit",
                        column: x => x.UserNit,
                        principalTable: "User",
                        principalColumn: "Nit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "Nit", "Cel", "Email", "Name", "Tel" },
                values: new object[,]
                {
                    { "2271", "3158429046", "manuel@correo.com", "Manuel", "6017922798" },
                    { "9027", "3101285739", "ana@correo.com", "Ana", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Nit", "Name", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { "1013", "Edgar", "850518", 0, "E1230" },
                    { "1398", "Diana", "asd85", 1, "DIANA" },
                    { "8080", "Jose", "12xx", 1, "J87" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CreationDate", "Name", "Photo_url", "Price", "SupplierId" },
                values: new object[,]
                {
                    { new Guid("f7d31d43-485b-4499-9502-97c3cf0c8100"), new DateTime(2023, 7, 4, 13, 47, 13, 885, DateTimeKind.Local).AddTicks(8500), "Televisor", null, 1200000, "9027" },
                    { new Guid("f7d31d43-485b-4499-9502-97c3cf0c8101"), new DateTime(2023, 7, 4, 13, 47, 13, 885, DateTimeKind.Local).AddTicks(8540), "Computador", null, 1800000, "9027" },
                    { new Guid("f7d31d43-485b-4499-9502-97c3cf0c8102"), new DateTime(2023, 7, 4, 13, 47, 13, 885, DateTimeKind.Local).AddTicks(8550), "Equipo de sonido", null, 900000, "9027" },
                    { new Guid("f7d31d43-485b-4499-9502-97c3cf0c8103"), new DateTime(2023, 7, 4, 13, 47, 13, 885, DateTimeKind.Local).AddTicks(8550), "Cortinas", null, 250000, "2271" },
                    { new Guid("f7d31d43-485b-4499-9502-97c3cf0c8104"), new DateTime(2023, 7, 4, 13, 47, 13, 885, DateTimeKind.Local).AddTicks(8550), "Armario", null, 900000, "2271" }
                });

            migrationBuilder.InsertData(
                table: "Sale",
                columns: new[] { "Id", "Amount", "FinalPrice", "ProductId", "SaleDate", "Tax", "UserNit" },
                values: new object[,]
                {
                    { new Guid("f7d31d43-485b-4499-9502-97c3cf0e8100"), 2, 2400000.0, new Guid("f7d31d43-485b-4499-9502-97c3cf0c8100"), new DateTime(2023, 7, 4, 13, 47, 13, 886, DateTimeKind.Local).AddTicks(1200), 19, "8080" },
                    { new Guid("f7d31d43-485b-4499-9502-97c3cf0e8101"), 1, 1800000.0, new Guid("f7d31d43-485b-4499-9502-97c3cf0c8101"), new DateTime(2023, 7, 4, 13, 47, 13, 886, DateTimeKind.Local).AddTicks(1220), 19, "1398" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplierId",
                table: "Product",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ProductId",
                table: "Sale",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_UserNit",
                table: "Sale",
                column: "UserNit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}
