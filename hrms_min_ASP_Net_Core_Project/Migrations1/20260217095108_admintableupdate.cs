using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hrms_min_ASP_Net_Core_Project.Migrations
{
    /// <inheritdoc />
    public partial class admintableupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Usermame",
                table: "Admins",
                newName: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Admins",
                newName: "Usermame");
        }
    }
}
