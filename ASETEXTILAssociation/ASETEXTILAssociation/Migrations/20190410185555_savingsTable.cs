using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASETEXTILAssociation.Migrations
{
    public partial class savingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SavingType",
                columns: table => new
                {
                    SavingTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    MonthTerm = table.Column<int>(nullable: false),
                    Interest = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingType", x => x.SavingTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Savings",
                columns: table => new
                {
                    SavingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    TypeSavingTypeId = table.Column<int>(nullable: true),
                    AffiliateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Savings", x => x.SavingId);
                    table.ForeignKey(
                        name: "FK_Savings_Affiliates_AffiliateId",
                        column: x => x.AffiliateId,
                        principalTable: "Affiliates",
                        principalColumn: "AffiliateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Savings_SavingType_TypeSavingTypeId",
                        column: x => x.TypeSavingTypeId,
                        principalTable: "SavingType",
                        principalColumn: "SavingTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Savings_AffiliateId",
                table: "Savings",
                column: "AffiliateId");

            migrationBuilder.CreateIndex(
                name: "IX_Savings_TypeSavingTypeId",
                table: "Savings",
                column: "TypeSavingTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Savings");

            migrationBuilder.DropTable(
                name: "SavingType");
        }
    }
}
