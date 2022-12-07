using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoggosApi.Data.Migrations
{
    public partial class ChangedApplicationRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Breeds_Breeds",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "Breeds",
                table: "Appointments",
                newName: "BreedID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_Breeds",
                table: "Appointments",
                newName: "IX_Appointments_BreedID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Breeds_BreedID",
                table: "Appointments",
                column: "BreedID",
                principalTable: "Breeds",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Breeds_BreedID",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "BreedID",
                table: "Appointments",
                newName: "Breeds");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_BreedID",
                table: "Appointments",
                newName: "IX_Appointments_Breeds");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Breeds_Breeds",
                table: "Appointments",
                column: "Breeds",
                principalTable: "Breeds",
                principalColumn: "Id");
        }
    }
}
