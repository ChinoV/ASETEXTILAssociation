using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASETEXTILAssociation.Migrations
{
    public partial class PaymentPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentPlanId",
                table: "Credits",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentPlanId",
                table: "Affiliates",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaymentPlans",
                columns: table => new
                {
                    PaymentPlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Month = table.Column<int>(nullable: false),
                    InitialBalance = table.Column<double>(nullable: false),
                    Amortization = table.Column<double>(nullable: false),
                    Interest = table.Column<int>(nullable: false),
                    MonthlyFee = table.Column<int>(nullable: false),
                    FinalBalance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentPlans", x => x.PaymentPlanId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Credits_PaymentPlanId",
                table: "Credits",
                column: "PaymentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Affiliates_PaymentPlanId",
                table: "Affiliates",
                column: "PaymentPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Affiliates_PaymentPlans_PaymentPlanId",
                table: "Affiliates",
                column: "PaymentPlanId",
                principalTable: "PaymentPlans",
                principalColumn: "PaymentPlanId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_PaymentPlans_PaymentPlanId",
                table: "Credits",
                column: "PaymentPlanId",
                principalTable: "PaymentPlans",
                principalColumn: "PaymentPlanId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Affiliates_PaymentPlans_PaymentPlanId",
                table: "Affiliates");

            migrationBuilder.DropForeignKey(
                name: "FK_Credits_PaymentPlans_PaymentPlanId",
                table: "Credits");

            migrationBuilder.DropTable(
                name: "PaymentPlans");

            migrationBuilder.DropIndex(
                name: "IX_Credits_PaymentPlanId",
                table: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_Affiliates_PaymentPlanId",
                table: "Affiliates");

            migrationBuilder.DropColumn(
                name: "PaymentPlanId",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "PaymentPlanId",
                table: "Affiliates");
        }
    }
}
