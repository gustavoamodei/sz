using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sz.Migrations
{
    public partial class ob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SimulOB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SimulacaoId = table.Column<int>(type: "int", nullable: false),
                    OleoBaseId = table.Column<int>(type: "int", nullable: false),
                    Ml = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimulOB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SimulOB_OleoBase_OleoBaseId",
                        column: x => x.OleoBaseId,
                        principalTable: "OleoBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SimulOB_OleoBaseId",
                table: "SimulOB",
                column: "OleoBaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SimulOB");
        }
    }
}
