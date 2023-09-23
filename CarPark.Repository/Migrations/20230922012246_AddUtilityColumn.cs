using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPark.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddUtilityColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Utility",
                table: "Vehicles",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Utility",
                table: "Vehicles");
        }
    }
}
