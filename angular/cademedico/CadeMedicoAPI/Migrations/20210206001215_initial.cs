using Microsoft.EntityFrameworkCore.Migrations;

namespace CadeMedicoAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    EspecialidadeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especialidades_Especialidades_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Crm = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Privilegios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privilegios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Login = table.Column<string>(type: "TEXT", nullable: true),
                    Senha = table.Column<string>(type: "TEXT", nullable: true),
                    PrivilegioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicoCidade",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CidadeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoCidade", x => new { x.MedicoId, x.CidadeId });
                    table.ForeignKey(
                        name: "FK_MedicoCidade_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoCidade_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicoEspecialidade",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "INTEGER", nullable: false),
                    EspecialidadeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoEspecialidade", x => new { x.MedicoId, x.EspecialidadeId });
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidade_Especialidades_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidade_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "Id", "Estado", "Nome" },
                values: new object[] { 1, "PR", "Londrina" });

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "Id", "Estado", "Nome" },
                values: new object[] { 2, "PR", "Maringa" });

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "Id", "Estado", "Nome" },
                values: new object[] { 3, "PR", "Apucarana" });

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "Id", "Estado", "Nome" },
                values: new object[] { 4, "SP", "Assai" });

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "Id", "Estado", "Nome" },
                values: new object[] { 5, "SP", "São Paulo" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "EspecialidadeId", "Nome" },
                values: new object[] { 1, null, "Ortopedista" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "EspecialidadeId", "Nome" },
                values: new object[] { 2, null, "Otorrinolaringologista" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "EspecialidadeId", "Nome" },
                values: new object[] { 3, null, "Ginecologita" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "EspecialidadeId", "Nome" },
                values: new object[] { 4, null, "Cardiologista" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "EspecialidadeId", "Nome" },
                values: new object[] { 5, null, "Oftalmologista" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "EspecialidadeId", "Nome" },
                values: new object[] { 6, null, "Clínico Geral" });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "Crm", "Nome", "Telefone" },
                values: new object[] { 5, "439800", "Joares", "1155335" });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "Crm", "Nome", "Telefone" },
                values: new object[] { 4, "501854", "Guilherme", "778899" });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "Crm", "Nome", "Telefone" },
                values: new object[] { 1, "3645655", "Marcos", "909090" });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "Crm", "Nome", "Telefone" },
                values: new object[] { 2, "123456", "Luiz", "404050" });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "Crm", "Nome", "Telefone" },
                values: new object[] { 3, "098764", "Joao", "201050" });

            migrationBuilder.InsertData(
                table: "Privilegios",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Master" });

            migrationBuilder.InsertData(
                table: "Privilegios",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "ADM" });

            migrationBuilder.InsertData(
                table: "Privilegios",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "USER" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Login", "Nome", "PrivilegioId", "Senha" },
                values: new object[] { 4, "joao", "joao", 3, "1234" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Login", "Nome", "PrivilegioId", "Senha" },
                values: new object[] { 1, "marc", "Marcos", 1, "1234" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Login", "Nome", "PrivilegioId", "Senha" },
                values: new object[] { 2, "carl", "Carlos", 2, "1234" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Login", "Nome", "PrivilegioId", "Senha" },
                values: new object[] { 3, "fern", "fernando", 3, "1234" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Login", "Nome", "PrivilegioId", "Senha" },
                values: new object[] { 5, "jona", "Jonathan", 2, "1234" });

            migrationBuilder.InsertData(
                table: "MedicoCidade",
                columns: new[] { "CidadeId", "MedicoId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "MedicoCidade",
                columns: new[] { "CidadeId", "MedicoId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "MedicoCidade",
                columns: new[] { "CidadeId", "MedicoId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "MedicoCidade",
                columns: new[] { "CidadeId", "MedicoId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "MedicoCidade",
                columns: new[] { "CidadeId", "MedicoId" },
                values: new object[] { 5, 5 });

            migrationBuilder.InsertData(
                table: "MedicoEspecialidade",
                columns: new[] { "EspecialidadeId", "MedicoId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "MedicoEspecialidade",
                columns: new[] { "EspecialidadeId", "MedicoId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "MedicoEspecialidade",
                columns: new[] { "EspecialidadeId", "MedicoId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "MedicoEspecialidade",
                columns: new[] { "EspecialidadeId", "MedicoId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "MedicoEspecialidade",
                columns: new[] { "EspecialidadeId", "MedicoId" },
                values: new object[] { 5, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_EspecialidadeId",
                table: "Especialidades",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoCidade_CidadeId",
                table: "MedicoCidade",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoEspecialidade_EspecialidadeId",
                table: "MedicoEspecialidade",
                column: "EspecialidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicoCidade");

            migrationBuilder.DropTable(
                name: "MedicoEspecialidade");

            migrationBuilder.DropTable(
                name: "Privilegios");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Medicos");
        }
    }
}
