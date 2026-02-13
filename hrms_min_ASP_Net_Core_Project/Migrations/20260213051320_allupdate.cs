using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hrms_min_ASP_Net_Core_Project.Migrations
{
    /// <inheritdoc />
    public partial class allupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeementType",
                table: "EmployeeDepartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EmployeemetnTypeId",
                table: "EmployeeDepartments",
                type: "int",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDepartments_EmployeemetnTypes_EmployeemetnTypeId",
                table: "EmployeeDepartments");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDepartments_EmployeemetnTypeId",
                table: "EmployeeDepartments");

            migrationBuilder.DropColumn(
                name: "EmployeementType",
                table: "EmployeeDepartments");

            migrationBuilder.DropColumn(
                name: "EmployeemetnTypeId",
                table: "EmployeeDepartments");
        }
    }
}
