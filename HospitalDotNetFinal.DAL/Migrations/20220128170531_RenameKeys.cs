using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalDotNetFinal.DAL.Migrations
{
    public partial class RenameKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicPacient_Medici_MedicId",
                table: "MedicPacient");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicPacient_Pacienti_PacientId",
                table: "MedicPacient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicPacient",
                table: "MedicPacient");

            migrationBuilder.RenameTable(
                name: "MedicPacient",
                newName: "MediciPacienti");

            migrationBuilder.RenameIndex(
                name: "IX_MedicPacient_PacientId",
                table: "MediciPacienti",
                newName: "IX_MediciPacienti_PacientId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicPacient_MedicId",
                table: "MediciPacienti",
                newName: "IX_MediciPacienti_MedicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediciPacienti",
                table: "MediciPacienti",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MediciPacienti_Medici_MedicId",
                table: "MediciPacienti",
                column: "MedicId",
                principalTable: "Medici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediciPacienti_Pacienti_PacientId",
                table: "MediciPacienti",
                column: "PacientId",
                principalTable: "Pacienti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediciPacienti_Medici_MedicId",
                table: "MediciPacienti");

            migrationBuilder.DropForeignKey(
                name: "FK_MediciPacienti_Pacienti_PacientId",
                table: "MediciPacienti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediciPacienti",
                table: "MediciPacienti");

            migrationBuilder.RenameTable(
                name: "MediciPacienti",
                newName: "MedicPacient");

            migrationBuilder.RenameIndex(
                name: "IX_MediciPacienti_PacientId",
                table: "MedicPacient",
                newName: "IX_MedicPacient_PacientId");

            migrationBuilder.RenameIndex(
                name: "IX_MediciPacienti_MedicId",
                table: "MedicPacient",
                newName: "IX_MedicPacient_MedicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicPacient",
                table: "MedicPacient",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicPacient_Medici_MedicId",
                table: "MedicPacient",
                column: "MedicId",
                principalTable: "Medici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicPacient_Pacienti_PacientId",
                table: "MedicPacient",
                column: "PacientId",
                principalTable: "Pacienti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
