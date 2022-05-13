using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace challenge.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaNac = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actor", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genero", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "productora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaFundacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productora", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pelicula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Duracion = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    Puntuacion = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PresupuestoUsd = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false),
                    ProductoraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pelicula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pelicula_genero_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pelicula_productora_ProductoraId",
                        column: x => x.ProductoraId,
                        principalTable: "productora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "imagen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Ruta = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Peso = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Ancho = table.Column<int>(type: "int", nullable: false),
                    Alto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imagen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_imagen_pelicula_Id",
                        column: x => x.Id,
                        principalTable: "pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pelicula_actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pelicula_actor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pelicula_actor_actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pelicula_actor_pelicula_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_pelicula_GeneroId",
                table: "pelicula",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_pelicula_ProductoraId",
                table: "pelicula",
                column: "ProductoraId");

            migrationBuilder.CreateIndex(
                name: "IX_pelicula_actor_ActorId",
                table: "pelicula_actor",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_pelicula_actor_PeliculaId",
                table: "pelicula_actor",
                column: "PeliculaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imagen");

            migrationBuilder.DropTable(
                name: "pelicula_actor");

            migrationBuilder.DropTable(
                name: "actor");

            migrationBuilder.DropTable(
                name: "pelicula");

            migrationBuilder.DropTable(
                name: "genero");

            migrationBuilder.DropTable(
                name: "productora");
        }
    }
}
