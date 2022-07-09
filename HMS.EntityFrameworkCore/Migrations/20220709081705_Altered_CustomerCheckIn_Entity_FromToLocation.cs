using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.EntityFrameworkCore.Migrations
{
    public partial class Altered_CustomerCheckIn_Entity_FromToLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCheckIn_Locations_DepartureLocationId",
                table: "CustomerCheckIn");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCheckIn_Locations_LocationId",
                table: "CustomerCheckIn");

            migrationBuilder.DropIndex(
                name: "IX_CustomerCheckIn_DepartureLocationId",
                table: "CustomerCheckIn");

            migrationBuilder.DropIndex(
                name: "IX_CustomerCheckIn_LocationId",
                table: "CustomerCheckIn");

            migrationBuilder.DropColumn(
                name: "DepartureLocationId",
                table: "CustomerCheckIn");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "CustomerCheckIn");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 9, 13, 17, 4, 375, DateTimeKind.Local).AddTicks(206));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 9, 13, 17, 4, 378, DateTimeKind.Local).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 9, 13, 17, 4, 378, DateTimeKind.Local).AddTicks(7272));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DepartureLocationId",
                table: "CustomerCheckIn",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LocationId",
                table: "CustomerCheckIn",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 9, 13, 11, 50, 718, DateTimeKind.Local).AddTicks(789));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 9, 13, 11, 50, 720, DateTimeKind.Local).AddTicks(8682));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 9, 13, 11, 50, 721, DateTimeKind.Local).AddTicks(650));

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCheckIn_DepartureLocationId",
                table: "CustomerCheckIn",
                column: "DepartureLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCheckIn_LocationId",
                table: "CustomerCheckIn",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCheckIn_Locations_DepartureLocationId",
                table: "CustomerCheckIn",
                column: "DepartureLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCheckIn_Locations_LocationId",
                table: "CustomerCheckIn",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
