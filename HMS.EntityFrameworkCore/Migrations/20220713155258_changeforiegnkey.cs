using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.EntityFrameworkCore.Migrations
{
    public partial class changeforiegnkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodTypeDetails_FoodTypes_FoodId",
                table: "FoodTypeDetails");

            migrationBuilder.RenameColumn(
                name: "FoodId",
                table: "FoodTypeDetails",
                newName: "FoodTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodTypeDetails_FoodId",
                table: "FoodTypeDetails",
                newName: "IX_FoodTypeDetails_FoodTypeId");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 13, 20, 52, 56, 338, DateTimeKind.Local).AddTicks(8268));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 13, 20, 52, 56, 348, DateTimeKind.Local).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 13, 20, 52, 56, 349, DateTimeKind.Local).AddTicks(6835));

            migrationBuilder.AddForeignKey(
                name: "FK_FoodTypeDetails_FoodTypes_FoodTypeId",
                table: "FoodTypeDetails",
                column: "FoodTypeId",
                principalTable: "FoodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodTypeDetails_FoodTypes_FoodTypeId",
                table: "FoodTypeDetails");

            migrationBuilder.RenameColumn(
                name: "FoodTypeId",
                table: "FoodTypeDetails",
                newName: "FoodId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodTypeDetails_FoodTypeId",
                table: "FoodTypeDetails",
                newName: "IX_FoodTypeDetails_FoodId");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 13, 20, 43, 43, 568, DateTimeKind.Local).AddTicks(7882));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 13, 20, 43, 43, 573, DateTimeKind.Local).AddTicks(3682));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 13, 20, 43, 43, 573, DateTimeKind.Local).AddTicks(7843));

            migrationBuilder.AddForeignKey(
                name: "FK_FoodTypeDetails_FoodTypes_FoodId",
                table: "FoodTypeDetails",
                column: "FoodId",
                principalTable: "FoodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
