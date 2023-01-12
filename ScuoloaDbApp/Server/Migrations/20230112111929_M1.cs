using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScuoloaDbApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classi",
                columns: table => new
                {
                    Sigla = table.Column<string>(type: "TEXT", maxLength: 5, nullable: false),
                    Ubicazione = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classi", x => x.Sigla);
                });

            migrationBuilder.CreateTable(
                name: "ClassiStudenti",
                columns: table => new
                {
                    Sigla = table.Column<string>(type: "TEXT", nullable: false),
                    Ubicazione = table.Column<string>(type: "TEXT", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroStudenti = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassiStudenti", x => x.Sigla);
                });

            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    Matricola = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cognome = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Indirizzo = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Diplomato = table.Column<bool>(type: "INTEGER", nullable: false),
                    ClasseSigla = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.Matricola);
                    table.ForeignKey(
                        name: "FK_Studenti_Classi_ClasseSigla",
                        column: x => x.ClasseSigla,
                        principalTable: "Classi",
                        principalColumn: "Sigla",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_ClasseSigla",
                table: "Studenti",
                column: "ClasseSigla");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassiStudenti");

            migrationBuilder.DropTable(
                name: "Studenti");

            migrationBuilder.DropTable(
                name: "Classi");
        }
    }
}
