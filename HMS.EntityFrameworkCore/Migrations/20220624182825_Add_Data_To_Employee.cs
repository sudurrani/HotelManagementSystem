using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.EntityFrameworkCore.Migrations
{
    public partial class Add_Data_To_Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedBy", "CreatedDateTime", "DeletedBy", "DeletedDateTime", "IsDeleted", "Name", "UpdatedBy", "UpdatedDateTime" },
                values: new object[] { 1L, 1L, new DateTime(2022, 6, 24, 23, 28, 24, 718, DateTimeKind.Local).AddTicks(633), null, null, false, "Muhammad Zeb", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
