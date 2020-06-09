using Microsoft.EntityFrameworkCore.Migrations;

namespace AppResenas.Migrations
{
    public partial class AppResenasContextResenasDataBaseContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true),
                    apellido = table.Column<string>(nullable: true),
                    edad = table.Column<int>(nullable: false),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    esAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "autores",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true),
                    apellido = table.Column<string>(nullable: true),
                    Usuarioid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autores", x => x.id);
                    table.ForeignKey(
                        name: "FK_autores_usuarios_Usuarioid",
                        column: x => x.Usuarioid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "resenas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    texto = table.Column<string>(nullable: true),
                    puntajeAcum = table.Column<double>(nullable: false),
                    votos = table.Column<int>(nullable: false),
                    Usuarioid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resenas", x => x.id);
                    table.ForeignKey(
                        name: "FK_resenas_usuarios_Usuarioid",
                        column: x => x.Usuarioid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "libros",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(nullable: true),
                    isbn = table.Column<string>(nullable: true),
                    autorid = table.Column<int>(nullable: true),
                    resenaid = table.Column<int>(nullable: true),
                    Usuarioid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libros", x => x.id);
                    table.ForeignKey(
                        name: "FK_libros_usuarios_Usuarioid",
                        column: x => x.Usuarioid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_libros_autores_autorid",
                        column: x => x.autorid,
                        principalTable: "autores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_libros_resenas_resenaid",
                        column: x => x.resenaid,
                        principalTable: "resenas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_autores_Usuarioid",
                table: "autores",
                column: "Usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_libros_Usuarioid",
                table: "libros",
                column: "Usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_libros_autorid",
                table: "libros",
                column: "autorid");

            migrationBuilder.CreateIndex(
                name: "IX_libros_resenaid",
                table: "libros",
                column: "resenaid");

            migrationBuilder.CreateIndex(
                name: "IX_resenas_Usuarioid",
                table: "resenas",
                column: "Usuarioid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "libros");

            migrationBuilder.DropTable(
                name: "autores");

            migrationBuilder.DropTable(
                name: "resenas");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
