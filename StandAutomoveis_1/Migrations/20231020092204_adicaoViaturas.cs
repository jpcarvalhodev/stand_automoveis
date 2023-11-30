using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StandAutomoveis_1.Migrations
{
    public partial class adicaoViaturas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Viatura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Loja = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viatura", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Viatura");
        }
    }
}
