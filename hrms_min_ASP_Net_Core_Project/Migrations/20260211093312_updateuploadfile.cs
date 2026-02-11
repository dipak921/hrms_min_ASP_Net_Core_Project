using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hrms_min_ASP_Net_Core_Project.Migrations
{
    /// <inheritdoc />
    public partial class updateuploadfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Joining Date",
                table: "Employees",
                newName: "Date of Joining");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date of Joining",
                table: "Employees",
                newName: "Joining Date");
        }
    }
}
