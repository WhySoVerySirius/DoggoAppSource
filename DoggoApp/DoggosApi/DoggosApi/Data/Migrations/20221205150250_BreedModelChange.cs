using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoggosApi.Data.Migrations
{
    public partial class BreedModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Wikipedia_Link",
                table: "Breeds",
                newName: "Reference_image_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reference_image_id",
                table: "Breeds",
                newName: "Wikipedia_Link");
        }
    }
}
