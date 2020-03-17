using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PayrollAPI.Migrations
{
    public partial class ecompdeduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EcompDeducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Value = table.Column<float>(nullable: false),
                    Year = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcompDeducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcompDeducts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EcompDeducts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EcompDeducts_CompanyId",
                table: "EcompDeducts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EcompDeducts_EmployeeId",
                table: "EcompDeducts",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EcompDeducts");
        }
    }
}
