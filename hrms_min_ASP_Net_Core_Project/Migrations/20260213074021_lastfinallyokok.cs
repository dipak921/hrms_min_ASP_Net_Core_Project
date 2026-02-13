using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hrms_min_ASP_Net_Core_Project.Migrations
{
    /// <inheritdoc />
    public partial class lastfinallyokok : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDepartments_EmployeemetnTypes_EmployeemetnTypeId",
                table: "EmployeeDepartments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDepartments_EmployeemetnTypeId",
                table: "EmployeeDepartments");

            migrationBuilder.DropColumn(
                name: "EmployeemetnTypeId",
                table: "EmployeeDepartments");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeemetnTypeId",
                table: "EmployeeDepartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeemetnTypeId1",
                table: "EmployeeDepartments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartments_EmployeemetnTypeId1",
                table: "EmployeeDepartments",
                column: "EmployeemetnTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDepartments_EmployeemetnTypes_EmployeemetnTypeId1",
                table: "EmployeeDepartments",
                column: "EmployeemetnTypeId1",
                principalTable: "EmployeemetnTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDepartments_EmployeemetnTypes_EmployeemetnTypeId1",
                table: "EmployeeDepartments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDepartments_EmployeemetnTypeId1",
                table: "EmployeeDepartments");

            migrationBuilder.DropColumn(
                name: "EmployeemetnTypeId1",
                table: "EmployeeDepartments");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeemetnTypeId",
                table: "EmployeeDepartments",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "EmployeemetnTypeId",
                table: "EmployeeDepartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartments_EmployeemetnTypeId",
                table: "EmployeeDepartments",
                column: "EmployeemetnTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDepartments_EmployeemetnTypes_EmployeemetnTypeId",
                table: "EmployeeDepartments",
                column: "EmployeemetnTypeId",
                principalTable: "EmployeemetnTypes",
                principalColumn: "Id");
        }
    }
}
