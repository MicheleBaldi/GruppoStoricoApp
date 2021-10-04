using Microsoft.EntityFrameworkCore.Migrations;

namespace GruppoStoricoApp.Data.Migrations
{
    public partial class VestitoCompletoPersona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VestitoCompletoPersona",
                columns: table => new
                {
                    VestitoCompletoPersonaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    CalzamagliaId = table.Column<int>(type: "int", nullable: false),
                    CamiciaId = table.Column<int>(type: "int", nullable: false),
                    CinturaId = table.Column<int>(type: "int", nullable: false),
                    VestitoId = table.Column<int>(type: "int", nullable: false),
                    StivaleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VestitoCompletoPersona", x => x.VestitoCompletoPersonaID);
                    table.ForeignKey(
                        name: "FK_VestitoCompletoPersona_Calzamaglia_CalzamagliaId",
                        column: x => x.CalzamagliaId,
                        principalTable: "Calzamaglia",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VestitoCompletoPersona_Camicia_CamiciaId",
                        column: x => x.CamiciaId,
                        principalTable: "Camicia",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VestitoCompletoPersona_Cintura_CinturaId",
                        column: x => x.CinturaId,
                        principalTable: "Cintura",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VestitoCompletoPersona_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VestitoCompletoPersona_Stivale_StivaleId",
                        column: x => x.StivaleId,
                        principalTable: "Stivale",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VestitoCompletoPersona_Vestito_VestitoId",
                        column: x => x.VestitoId,
                        principalTable: "Vestito",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VestitoCompletoPersona_CalzamagliaId",
                table: "VestitoCompletoPersona",
                column: "CalzamagliaId");

            migrationBuilder.CreateIndex(
                name: "IX_VestitoCompletoPersona_CamiciaId",
                table: "VestitoCompletoPersona",
                column: "CamiciaId");

            migrationBuilder.CreateIndex(
                name: "IX_VestitoCompletoPersona_CinturaId",
                table: "VestitoCompletoPersona",
                column: "CinturaId");

            migrationBuilder.CreateIndex(
                name: "IX_VestitoCompletoPersona_PersonaId_VestitoId_CamiciaId_CinturaId_CalzamagliaId_StivaleId",
                table: "VestitoCompletoPersona",
                columns: new[] { "PersonaId", "VestitoId", "CamiciaId", "CinturaId", "CalzamagliaId", "StivaleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VestitoCompletoPersona_StivaleId",
                table: "VestitoCompletoPersona",
                column: "StivaleId");

            migrationBuilder.CreateIndex(
                name: "IX_VestitoCompletoPersona_VestitoId",
                table: "VestitoCompletoPersona",
                column: "VestitoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VestitoCompletoPersona");
        }
    }
}
