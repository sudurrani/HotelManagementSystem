using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.EntityFrameworkCore.Migrations
{
    public partial class Altered_CustomerCheckIn_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCheckIn_Locations_FromLocationId",
                table: "CustomerCheckIn");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCheckIn_Locations_ToLocationId",
                table: "CustomerCheckIn");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCheckIn_Rooms_RoomId",
                table: "CustomerCheckIn");

            migrationBuilder.DropIndex(
                name: "IX_CustomerCheckIn_FromLocationId",
                table: "CustomerCheckIn");

            migrationBuilder.DropIndex(
                name: "IX_CustomerCheckIn_RoomId",
                table: "CustomerCheckIn");

            migrationBuilder.DropIndex(
                name: "IX_CustomerCheckIn_ToLocationId",
                table: "CustomerCheckIn");

            migrationBuilder.DropColumn(
                name: "Rent",
                table: "CustomerCheckIn");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "CustomerCheckIn");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckOut",
                table: "CustomerCheckIn",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckOut",
                table: "CustomerCheckIn",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Rent",
                table: "CustomerCheckIn",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "RoomId",
                table: "CustomerCheckIn",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCheckIn_FromLocationId",
                table: "CustomerCheckIn",
                column: "FromLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCheckIn_RoomId",
                table: "CustomerCheckIn",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCheckIn_ToLocationId",
                table: "CustomerCheckIn",
                column: "ToLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCheckIn_Locations_FromLocationId",
                table: "CustomerCheckIn",
                column: "FromLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCheckIn_Locations_ToLocationId",
                table: "CustomerCheckIn",
                column: "ToLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCheckIn_Rooms_RoomId",
                table: "CustomerCheckIn",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
