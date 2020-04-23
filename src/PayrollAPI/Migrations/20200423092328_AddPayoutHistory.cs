using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PayrollAPI.Migrations
{
    public partial class AddPayoutHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "NetPay",
                table: "Employees",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayRollDay",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanBillingId",
                table: "Companies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Wallet",
                table: "Companies",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "PayoutHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountName = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Month = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    UniqueCode = table.Column<string>(nullable: true),
                    NetPay = table.Column<float>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayoutHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayoutHistories_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanBilling",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Plan = table.Column<string>(nullable: true),
                    PayrollTransaction = table.Column<string>(nullable: true),
                    Fee = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanBilling", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WalletTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TransactionType = table.Column<string>(nullable: true),
                    Amount = table.Column<float>(nullable: false),
                    ReferenceNo = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletTransactions_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayrollHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<string>(nullable: true),
                    PayrollType = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    PayoutHistoryId = table.Column<int>(nullable: false),
                    PayoutHistoryUniqueCode = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrollHistories_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PayrollHistories_PayoutHistories_PayoutHistoryId",
                        column: x => x.PayoutHistoryId,
                        principalTable: "PayoutHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_PlanBillingId",
                table: "Companies",
                column: "PlanBillingId");

            migrationBuilder.CreateIndex(
                name: "IX_PayoutHistories_CompanyId",
                table: "PayoutHistories",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollHistories_CompanyId",
                table: "PayrollHistories",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollHistories_PayoutHistoryId",
                table: "PayrollHistories",
                column: "PayoutHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransactions_CompanyId",
                table: "WalletTransactions",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_PlanBilling_PlanBillingId",
                table: "Companies",
                column: "PlanBillingId",
                principalTable: "PlanBilling",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_PlanBilling_PlanBillingId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "PayrollHistories");

            migrationBuilder.DropTable(
                name: "PlanBilling");

            migrationBuilder.DropTable(
                name: "WalletTransactions");

            migrationBuilder.DropTable(
                name: "PayoutHistories");

            migrationBuilder.DropIndex(
                name: "IX_Companies_PlanBillingId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NetPay",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PayRollDay",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "PlanBillingId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Wallet",
                table: "Companies");
        }
    }
}
