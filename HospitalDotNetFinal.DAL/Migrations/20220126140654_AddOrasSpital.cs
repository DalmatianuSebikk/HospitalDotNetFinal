using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalDotNetFinal.DAL.Migrations
{
    public partial class AddOrasSpital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeOras = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LocuitoriOras = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spitale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeSpital = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OrasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spitale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spitale_Orase_OrasId",
                        column: x => x.OrasId,
                        principalTable: "Orase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spitale_OrasId",
                table: "Spitale",
                column: "OrasId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spitale");

            migrationBuilder.DropTable(
                name: "Orase");
        }
    }
}
