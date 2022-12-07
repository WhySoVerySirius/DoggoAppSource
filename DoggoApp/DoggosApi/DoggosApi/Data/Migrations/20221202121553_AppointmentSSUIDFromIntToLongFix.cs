using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoggosApi.Data.Migrations
{
    public partial class AppointmentSSUIDFromIntToLongFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "SSUID",
                table: "Appointments",
                type: "NUMBER(19)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SSUID",
                table: "Appointments",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(19)");
        }
    }
}
