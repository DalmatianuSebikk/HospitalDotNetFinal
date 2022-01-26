using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalDotNetFinal.DAL.Migrations
{
    public partial class AddBoala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeBoala = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Gravitate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boli", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boli");
        }
    }
}
