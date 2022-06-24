using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.EntityFrameworkCore.Migrations
{
    public partial class Add_Data_To_Role_And_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 6, 24, 23, 30, 30, 662, DateTimeKind.Local).AddTicks(9281));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDateTime", "DeletedBy", "DeletedDateTime", "IsDeleted", "Name", "UpdatedBy", "UpdatedDateTime" },
                values: new object[] { 1L, 1L, new DateTime(2022, 6, 24, 23, 30, 30, 664, DateTimeKind.Local).AddTicks(7849), null, null, false, "admin", null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDateTime", "DeletedBy", "DeletedDateTime", "EmployeeId", "IsDeleted", "Password", "RoleId", "UpdatedBy", "UpdatedDateTime", "Username" },
                values: new object[] { 1L, 1L, new DateTime(2022, 6, 24, 23, 30, 30, 664, DateTimeKind.Local).AddTicks(9331), null, null, 1L, false, "123", 1L, null, null, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 6, 24, 23, 28, 24, 718, DateTimeKind.Local).AddTicks(633));
        }
    }
}
