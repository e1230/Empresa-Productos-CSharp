using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empresa_Productos.Migrations
{
    /// <inheritdoc />
    public partial class refactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0c8100"),
                column: "CreationDate",
                value: new DateTime(2023, 7, 4, 21, 2, 55, 518, DateTimeKind.Local).AddTicks(3950));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0c8101"),
                column: "CreationDate",
                value: new DateTime(2023, 7, 4, 21, 2, 55, 518, DateTimeKind.Local).AddTicks(3990));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0c8102"),
                column: "CreationDate",
                value: new DateTime(2023, 7, 4, 21, 2, 55, 518, DateTimeKind.Local).AddTicks(3990));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0c8103"),
                column: "CreationDate",
                value: new DateTime(2023, 7, 4, 21, 2, 55, 518, DateTimeKind.Local).AddTicks(4000));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0c8104"),
                column: "CreationDate",
                value: new DateTime(2023, 7, 4, 21, 2, 55, 518, DateTimeKind.Local).AddTicks(4000));

            migrationBuilder.UpdateData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0e8100"),
                column: "SaleDate",
                value: new DateTime(2023, 7, 4, 21, 2, 55, 518, DateTimeKind.Local).AddTicks(4020));

            migrationBuilder.UpdateData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: new Guid("f7d31d43-485b-4499-9502-97c3cf0e8101"),
                column: "SaleDate",
                value: new DateTime(2023, 7, 4, 21, 2, 55, 518, DateTimeKind.Local).AddTicks(4020));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
