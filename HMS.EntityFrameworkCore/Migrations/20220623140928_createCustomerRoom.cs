using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.EntityFrameworkCore.Migrations
{
    public partial class createCustomerRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerRooms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivalDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommingFromId = table.Column<long>(type: "bigint", nullable: true),
                    DepartureDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextDestinationId = table.Column<long>(type: "bigint", nullable: true),
                    RoomId = table.Column<long>(type: "bigint", nullable: false),
                    RoomRentFor24Hour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdvancePayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(500)", nullable: true),
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
                    table.PrimaryKey("PK_CustomerRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerRooms_Locations_CommingFromId",
                        column: x => x.CommingFromId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerRooms_Locations_NextDestinationId",
                        column: x => x.NextDestinationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerRooms_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purposeOfVisits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Purpose = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_purposeOfVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_purposeOfVisits_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRooms_CommingFromId",
                table: "CustomerRooms",
                column: "CommingFromId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRooms_NextDestinationId",
                table: "CustomerRooms",
                column: "NextDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRooms_RoomId",
                table: "CustomerRooms",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_purposeOfVisits_CustomerId",
                table: "purposeOfVisits",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerRooms");

            migrationBuilder.DropTable(
                name: "purposeOfVisits");
        }
    }
}
