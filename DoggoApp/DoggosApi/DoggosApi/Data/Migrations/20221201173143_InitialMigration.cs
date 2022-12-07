using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoggosApi.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Temperament = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Life_Span = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Alt_Names = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Wikipedia_Link = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Origin = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Weight = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Country_Code = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Height = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SSUID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Breeds = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Age = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Height = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Length = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Weight = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.SSUID);
                    table.ForeignKey(
                        name: "FK_Appointments_Breeds_Breeds",
                        column: x => x.Breeds,
                        principalTable: "Breeds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Breeds",
                table: "Appointments",
                column: "Breeds");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Breeds");
        }
    }
}
