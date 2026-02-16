using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hrms_min_ASP_Net_Core_Project.Migrations
{
    /// <inheritdoc />
    public partial class initialithinkfinalloksdjgklrjkla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDepartments_Cities_CityId",
                table: "EmployeeDepartments");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "EmployeeDepartments");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "EmployeeDepartments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDepartments_Cities_CityId",
                table: "EmployeeDepartments",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDepartments_Cities_CityId",
                table: "EmployeeDepartments");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "EmployeeDepartments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "EmployeeDepartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDepartments_Cities_CityId",
                table: "EmployeeDepartments",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }
    }
}
