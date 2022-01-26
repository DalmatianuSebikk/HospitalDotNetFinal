using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalDotNetFinal.DAL.Migrations
{
    public partial class AddOtherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spitale_Orase_OrasId",
                table: "Spitale");

            migrationBuilder.DropIndex(
                name: "IX_Spitale_OrasId",
                table: "Spitale");

            migrationBuilder.AlterColumn<int>(
                name: "OrasId",
                table: "Spitale",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Medici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeMedic = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SpecializareMedic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumarDeTelefon = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SpitalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medici_Spitale_SpitalId",
                        column: x => x.SpitalId,
                        principalTable: "Spitale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacienti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumePacient = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CNP = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    NumarDeTelefon = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BoalaId = table.Column<int>(type: "int", nullable: true),
                    SpitalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacienti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacienti_Boli_BoalaId",
                        column: x => x.BoalaId,
                        principalTable: "Boli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pacienti_Spitale_SpitalId",
                        column: x => x.SpitalId,
                        principalTable: "Spitale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicPacient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicId = table.Column<int>(type: "int", nullable: false),
                    PacientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicPacient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicPacient_Medici_MedicId",
                        column: x => x.MedicId,
                        principalTable: "Medici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicPacient_Pacienti_PacientId",
                        column: x => x.PacientId,
                        principalTable: "Pacienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spitale_OrasId",
                table: "Spitale",
                column: "OrasId",
                unique: true,
                filter: "[OrasId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Medici_SpitalId",
                table: "Medici",
                column: "SpitalId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicPacient_MedicId",
                table: "MedicPacient",
                column: "MedicId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicPacient_PacientId",
                table: "MedicPacient",
                column: "PacientId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacienti_BoalaId",
                table: "Pacienti",
                column: "BoalaId",
                unique: true,
                filter: "[BoalaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pacienti_SpitalId",
                table: "Pacienti",
                column: "SpitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Spitale_Orase_OrasId",
                table: "Spitale",
                column: "OrasId",
                principalTable: "Orase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spitale_Orase_OrasId",
                table: "Spitale");

            migrationBuilder.DropTable(
                name: "MedicPacient");

            migrationBuilder.DropTable(
                name: "Medici");

            migrationBuilder.DropTable(
                name: "Pacienti");

            migrationBuilder.DropIndex(
                name: "IX_Spitale_OrasId",
                table: "Spitale");

            migrationBuilder.AlterColumn<int>(
                name: "OrasId",
                table: "Spitale",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spitale_OrasId",
                table: "Spitale",
                column: "OrasId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Spitale_Orase_OrasId",
                table: "Spitale",
                column: "OrasId",
                principalTable: "Orase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
