using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GruppoStoricoApp.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEvento = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataEvento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ruolo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeRuolo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruolo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Calzamaglia",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Taglia = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RuoloID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calzamaglia", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Calzamaglia_Ruolo_RuoloID",
                        column: x => x.RuoloID,
                        principalTable: "Ruolo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Camicia",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Taglia = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RuoloID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camicia", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Camicia_Ruolo_RuoloID",
                        column: x => x.RuoloID,
                        principalTable: "Ruolo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cintura",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Taglia = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RuoloID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cintura", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cintura_Ruolo_RuoloID",
                        column: x => x.RuoloID,
                        principalTable: "Ruolo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataNascita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profilo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuoloID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Persona_Ruolo_RuoloID",
                        column: x => x.RuoloID,
                        principalTable: "Ruolo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stivale",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Taglia = table.Column<int>(type: "int", nullable: false),
                    RuoloID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stivale", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stivale_Ruolo_RuoloID",
                        column: x => x.RuoloID,
                        principalTable: "Ruolo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vestito",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Taglia = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RuoloID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vestito", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vestito_Ruolo_RuoloID",
                        column: x => x.RuoloID,
                        principalTable: "Ruolo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartecipazioneEvento",
                columns: table => new
                {
                    PartecipazioneEventoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventoID = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    CalzamagliaId = table.Column<int>(type: "int", nullable: false),
                    CamiciaId = table.Column<int>(type: "int", nullable: false),
                    CinturaId = table.Column<int>(type: "int", nullable: false),
                    VestitoId = table.Column<int>(type: "int", nullable: false),
                    StivaleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartecipazioneEvento", x => x.PartecipazioneEventoID);
                    table.ForeignKey(
                        name: "FK_PartecipazioneEvento_Calzamaglia_CalzamagliaId",
                        column: x => x.CalzamagliaId,
                        principalTable: "Calzamaglia",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PartecipazioneEvento_Camicia_CamiciaId",
                        column: x => x.CamiciaId,
                        principalTable: "Camicia",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PartecipazioneEvento_Cintura_CinturaId",
                        column: x => x.CinturaId,
                        principalTable: "Cintura",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PartecipazioneEvento_Evento_EventoID",
                        column: x => x.EventoID,
                        principalTable: "Evento",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PartecipazioneEvento_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PartecipazioneEvento_Stivale_StivaleId",
                        column: x => x.StivaleId,
                        principalTable: "Stivale",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PartecipazioneEvento_Vestito_VestitoId",
                        column: x => x.VestitoId,
                        principalTable: "Vestito",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calzamaglia_Numero_RuoloID",
                table: "Calzamaglia",
                columns: new[] { "Numero", "RuoloID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Calzamaglia_RuoloID",
                table: "Calzamaglia",
                column: "RuoloID");

            migrationBuilder.CreateIndex(
                name: "IX_Camicia_Numero_RuoloID",
                table: "Camicia",
                columns: new[] { "Numero", "RuoloID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Camicia_RuoloID",
                table: "Camicia",
                column: "RuoloID");

            migrationBuilder.CreateIndex(
                name: "IX_Cintura_Numero_RuoloID",
                table: "Cintura",
                columns: new[] { "Numero", "RuoloID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cintura_RuoloID",
                table: "Cintura",
                column: "RuoloID");

            migrationBuilder.CreateIndex(
                name: "IX_PartecipazioneEvento_CalzamagliaId",
                table: "PartecipazioneEvento",
                column: "CalzamagliaId");

            migrationBuilder.CreateIndex(
                name: "IX_PartecipazioneEvento_CamiciaId",
                table: "PartecipazioneEvento",
                column: "CamiciaId");

            migrationBuilder.CreateIndex(
                name: "IX_PartecipazioneEvento_CinturaId",
                table: "PartecipazioneEvento",
                column: "CinturaId");

            migrationBuilder.CreateIndex(
                name: "IX_PartecipazioneEvento_EventoID",
                table: "PartecipazioneEvento",
                column: "EventoID");

            migrationBuilder.CreateIndex(
                name: "IX_PartecipazioneEvento_PersonaId",
                table: "PartecipazioneEvento",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_PartecipazioneEvento_StivaleId",
                table: "PartecipazioneEvento",
                column: "StivaleId");

            migrationBuilder.CreateIndex(
                name: "IX_PartecipazioneEvento_VestitoId",
                table: "PartecipazioneEvento",
                column: "VestitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_RuoloID",
                table: "Persona",
                column: "RuoloID");

            migrationBuilder.CreateIndex(
                name: "IX_Stivale_Numero_RuoloID",
                table: "Stivale",
                columns: new[] { "Numero", "RuoloID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stivale_RuoloID",
                table: "Stivale",
                column: "RuoloID");

            migrationBuilder.CreateIndex(
                name: "IX_Vestito_Numero_RuoloID",
                table: "Vestito",
                columns: new[] { "Numero", "RuoloID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vestito_RuoloID",
                table: "Vestito",
                column: "RuoloID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartecipazioneEvento");

            migrationBuilder.DropTable(
                name: "Calzamaglia");

            migrationBuilder.DropTable(
                name: "Camicia");

            migrationBuilder.DropTable(
                name: "Cintura");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Stivale");

            migrationBuilder.DropTable(
                name: "Vestito");

            migrationBuilder.DropTable(
                name: "Ruolo");
        }
    }
}
