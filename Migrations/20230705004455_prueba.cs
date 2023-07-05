using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empresa_Productos.Migrations
{
    /// <inheritdoc />
    public partial class prueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Supplier_SupplierId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Product_ProductId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_User_UserNit",
                table: "Sale");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserNit",
                table: "Sale",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Tax",
                table: "Sale",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SaleDate",
                table: "Sale",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<double>(
                name: "FinalPrice",
                table: "Sale",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Sale",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "SupplierId",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Product",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0c8100"),
                column: "CreationDate",
                value: new DateTime(2023, 7, 4, 19, 44, 55, 55, DateTimeKind.Local).AddTicks(8730));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0c8101"),
                column: "CreationDate",
                value: new DateTime(2023, 7, 4, 19, 44, 55, 55, DateTimeKind.Local).AddTicks(8760));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0c8102"),
                column: "CreationDate",
                value: new DateTime(2023, 7, 4, 19, 44, 55, 55, DateTimeKind.Local).AddTicks(8760));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0c8103"),
                column: "CreationDate",
                value: new DateTime(2023, 7, 4, 19, 44, 55, 55, DateTimeKind.Local).AddTicks(8770));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0c8104"),
                column: "CreationDate",
                value: new DateTime(2023, 7, 4, 19, 44, 55, 55, DateTimeKind.Local).AddTicks(8770));

            migrationBuilder.UpdateData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0e8100"),
                column: "SaleDate",
                value: new DateTime(2023, 7, 4, 19, 44, 55, 56, DateTimeKind.Local).AddTicks(1510));

            migrationBuilder.UpdateData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0e8101"),
                column: "SaleDate",
                value: new DateTime(2023, 7, 4, 19, 44, 55, 56, DateTimeKind.Local).AddTicks(1530));

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Supplier_SupplierId",
                table: "Product",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Nit");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Product_ProductId",
                table: "Sale",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_User_UserNit",
                table: "Sale",
                column: "UserNit",
                principalTable: "User",
                principalColumn: "Nit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Supplier_SupplierId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Product_ProductId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_User_UserNit",
                table: "Sale");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserNit",
                table: "Sale",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Tax",
                table: "Sale",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SaleDate",
                table: "Sale",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Sale",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "FinalPrice",
                table: "Sale",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Sale",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SupplierId",
                table: "Product",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0c8100"),
                column: "CreationDate",
                value: new DateTime(2023, 7, 4, 13, 47, 13, 885, DateTimeKind.Local).AddTicks(8500));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0c8101"),
                column: "CreationDate",
                value: new DateTime(2023, 7, 4, 13, 47, 13, 885, DateTimeKind.Local).AddTicks(8540));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0c8102"),
                column: "CreationDate",
                value: new DateTime(2023, 7, 4, 13, 47, 13, 885, DateTimeKind.Local).AddTicks(8550));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0c8103"),
                column: "CreationDate",
                value: new DateTime(2023, 7, 4, 13, 47, 13, 885, DateTimeKind.Local).AddTicks(8550));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0c8104"),
                column: "CreationDate",
                value: new DateTime(2023, 7, 4, 13, 47, 13, 885, DateTimeKind.Local).AddTicks(8550));

            migrationBuilder.UpdateData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0e8100"),
                column: "SaleDate",
                value: new DateTime(2023, 7, 4, 13, 47, 13, 886, DateTimeKind.Local).AddTicks(1200));

            migrationBuilder.UpdateData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0e8101"),
                column: "SaleDate",
                value: new DateTime(2023, 7, 4, 13, 47, 13, 886, DateTimeKind.Local).AddTicks(1220));

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Supplier_SupplierId",
                table: "Product",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Nit",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Product_ProductId",
                table: "Sale",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_User_UserNit",
                table: "Sale",
                column: "UserNit",
                principalTable: "User",
                principalColumn: "Nit",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
