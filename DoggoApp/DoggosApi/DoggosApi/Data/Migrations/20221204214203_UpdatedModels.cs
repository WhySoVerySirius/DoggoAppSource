using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoggosApi.Data.Migrations
{
    public partial class UpdatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Appointments",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<long>(
                name: "Uuid",
                table: "Appointments",
                type: "NUMBER(19)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(19)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.AlterColumn<long>(
                name: "Uuid",
                table: "Appointments",
                type: "NUMBER(19)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(19)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Appointments",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Uuid");
        }
    }
}
