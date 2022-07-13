using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.EntityFrameworkCore.Migrations
{
    public partial class Added_CustomerCheckInRoom_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCheckIn_Customers_CustomerId",
                table: "CustomerCheckIn");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerCheckIn",
                table: "CustomerCheckIn");

            migrationBuilder.RenameTable(
                name: "CustomerCheckIn",
                newName: "CustomerCheckIns");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerCheckIn_CustomerId",
                table: "CustomerCheckIns",
                newName: "IX_CustomerCheckIns_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerCheckIns",
                table: "CustomerCheckIns",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CustomerCheckInRooms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCheckInId = table.Column<long>(type: "bigint", nullable: false),
                    RoomId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCheckInRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerCheckInRooms_CustomerCheckIns_CustomerCheckInId",
                        column: x => x.CustomerCheckInId,
                        principalTable: "CustomerCheckIns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerCheckInRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 9, 16, 23, 44, 55, DateTimeKind.Local).AddTicks(2033));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 9, 16, 23, 44, 57, DateTimeKind.Local).AddTicks(8686));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDateTime",
                value: new DateTime(2022, 7, 9, 16, 23, 44, 58, DateTimeKind.Local).AddTicks(671));

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCheckInRooms_CustomerCheckInId",
                table: "CustomerCheckInRooms",
                column: "CustomerCheckInId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCheckInRooms_RoomId",
                table: "CustomerCheckInRooms",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCheckIns_Customers_CustomerId",
                table: "CustomerCheckIns",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerCheckIns_Customers_CustomerId",
                table: "CustomerCheckIns");

            migrationBuilder.DropTable(
                name: "CustomerCheckInRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerCheckIns",
                table: "CustomerCheckIns");

            migrationBuilder.RenameTable(
                name: "CustomerCheckIns",
                newName: "CustomerCheckIn");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerCheckIns_CustomerId",
                table: "CustomerCheckIn",
                newName: "IX_CustomerCheckIn_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerCheckIn",
                table: "CustomerCheckIn",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerCheckIn_Customers_CustomerId",
                table: "CustomerCheckIn",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
