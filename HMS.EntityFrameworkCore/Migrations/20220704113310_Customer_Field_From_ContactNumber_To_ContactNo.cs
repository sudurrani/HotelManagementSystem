using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.EntityFrameworkCore.Migrations
{
    public partial class Customer_Field_From_ContactNumber_To_ContactNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactNumber",
                table: "Customers",
                newName: "ContactNo");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 4, 16, 33, 9, 810, DateTimeKind.Local).AddTicks(8649));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 4, 16, 33, 9, 812, DateTimeKind.Local).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 4, 16, 33, 9, 812, DateTimeKind.Local).AddTicks(8569));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactNo",
                table: "Customers",
                newName: "ContactNumber");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 2, 17, 40, 42, 372, DateTimeKind.Local).AddTicks(1845));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 2, 17, 40, 42, 373, DateTimeKind.Local).AddTicks(9881));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 2, 17, 40, 42, 374, DateTimeKind.Local).AddTicks(1348));
        }
    }
}
