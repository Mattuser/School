using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    usuario = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    senha = table.Column<string>(type: "CHAR(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "turma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    turma = table.Column<string>(type: "VARCHAR(45)", maxLength: 45, nullable: false),
                    ano = table.Column<int>(type: "INT", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "aluno_turma",
                columns: table => new
                {
                    aluno_id = table.Column<int>(type: "int", nullable: false),
                    class_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aluno_turma", x => new { x.aluno_id, x.class_id });
                    table.ForeignKey(
                        name: "FK_aluno_turma_aluno_aluno_id",
                        column: x => x.aluno_id,
                        principalTable: "aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_aluno_turma_turma_class_id",
                        column: x => x.class_id,
                        principalTable: "turma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_aluno_turma_class_id",
                table: "aluno_turma",
                column: "class_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aluno_turma");

            migrationBuilder.DropTable(
                name: "aluno");

            migrationBuilder.DropTable(
                name: "turma");
        }
    }
}
