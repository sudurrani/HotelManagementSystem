using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.EntityFrameworkCore.Migrations
{
    public partial class creatcustomertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NationalityId = table.Column<long>(type: "bigint", nullable: true),
                    ProfessionId = table.Column<long>(type: "bigint", nullable: true),
                    NIC = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    PassportNo = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(200)", nullable: true),
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
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_NationalityId",
                table: "Customers",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ProfessionId",
                table: "Customers",
                column: "ProfessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
