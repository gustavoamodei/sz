using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sz.Migrations
{
    public partial class simuloe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SimulacaoId",
                table: "OleoEssencial",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SimulOE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SimulacaoId = table.Column<int>(type: "int", nullable: false),
                    OleoEssencialId = table.Column<int>(type: "int", nullable: false),
                    GotasOE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimulOE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SimulOE_OleoEssencial_OleoEssencialId",
                        column: x => x.OleoEssencialId,
                        principalTable: "OleoEssencial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SimulOE_Simulacao_SimulacaoId",
                        column: x => x.SimulacaoId,
                        principalTable: "Simulacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SimulOB_SimulacaoId",
                table: "SimulOB",
                column: "SimulacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_OleoEssencial_SimulacaoId",
                table: "OleoEssencial",
                column: "SimulacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_SimulOE_OleoEssencialId",
                table: "SimulOE",
                column: "OleoEssencialId");

            migrationBuilder.CreateIndex(
                name: "IX_SimulOE_SimulacaoId",
                table: "SimulOE",
                column: "SimulacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_OleoEssencial_Simulacao_SimulacaoId",
                table: "OleoEssencial",
                column: "SimulacaoId",
                principalTable: "Simulacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SimulOB_Simulacao_SimulacaoId",
                table: "SimulOB",
                column: "SimulacaoId",
                principalTable: "Simulacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OleoEssencial_Simulacao_SimulacaoId",
                table: "OleoEssencial");

            migrationBuilder.DropForeignKey(
                name: "FK_SimulOB_Simulacao_SimulacaoId",
                table: "SimulOB");

            migrationBuilder.DropTable(
                name: "SimulOE");

            migrationBuilder.DropIndex(
                name: "IX_SimulOB_SimulacaoId",
                table: "SimulOB");

            migrationBuilder.DropIndex(
                name: "IX_OleoEssencial_SimulacaoId",
                table: "OleoEssencial");

            migrationBuilder.DropColumn(
                name: "SimulacaoId",
                table: "OleoEssencial");
        }
    }
}
