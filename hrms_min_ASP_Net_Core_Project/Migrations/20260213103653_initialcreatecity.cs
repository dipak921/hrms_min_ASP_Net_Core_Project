using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hrms_min_ASP_Net_Core_Project.Migrations
{
    /// <inheritdoc />
    public partial class initialcreatecity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "EmployeeDepartments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartments_CityId",
                table: "EmployeeDepartments",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDepartments_Cities_CityId",
                table: "EmployeeDepartments",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDepartments_Cities_CityId",
                table: "EmployeeDepartments");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDepartments_CityId",
                table: "EmployeeDepartments");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "EmployeeDepartments");
        }
    }
}
