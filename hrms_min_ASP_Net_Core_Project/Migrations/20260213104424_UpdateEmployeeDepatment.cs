using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hrms_min_ASP_Net_Core_Project.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployeeDepatment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "EmployeeDepartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityName",
                table: "EmployeeDepartments");
        }
    }
}
