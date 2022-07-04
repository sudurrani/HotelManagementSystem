using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.EntityFrameworkCore.Migrations
{
    public partial class addcontactFieldsToEmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactNumber1",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber2",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 3, 15, 47, 12, 727, DateTimeKind.Local).AddTicks(2952));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 3, 15, 47, 12, 732, DateTimeKind.Local).AddTicks(366));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 3, 15, 47, 12, 732, DateTimeKind.Local).AddTicks(4330));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactNumber1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ContactNumber2",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 3, 15, 32, 43, 243, DateTimeKind.Local).AddTicks(4076));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 3, 15, 32, 43, 246, DateTimeKind.Local).AddTicks(3535));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 3, 15, 32, 43, 246, DateTimeKind.Local).AddTicks(7441));
        }
    }
}
