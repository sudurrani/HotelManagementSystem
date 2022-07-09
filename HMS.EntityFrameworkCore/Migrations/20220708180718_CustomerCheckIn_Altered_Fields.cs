using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.EntityFrameworkCore.Migrations
{
    public partial class CustomerCheckIn_Altered_Fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OutDateTime",
                table: "CustomerCheckIn",
                newName: "CheckOut");

            migrationBuilder.RenameColumn(
                name: "InDateTime",
                table: "CustomerCheckIn",
                newName: "CheckIn");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 8, 23, 7, 18, 188, DateTimeKind.Local).AddTicks(720));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 8, 23, 7, 18, 189, DateTimeKind.Local).AddTicks(8869));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 8, 23, 7, 18, 190, DateTimeKind.Local).AddTicks(202));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CheckOut",
                table: "CustomerCheckIn",
                newName: "OutDateTime");

            migrationBuilder.RenameColumn(
                name: "CheckIn",
                table: "CustomerCheckIn",
                newName: "InDateTime");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 8, 11, 22, 0, 690, DateTimeKind.Local).AddTicks(200));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 8, 11, 22, 0, 692, DateTimeKind.Local).AddTicks(7300));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 8, 11, 22, 0, 692, DateTimeKind.Local).AddTicks(9721));
        }
    }
}
