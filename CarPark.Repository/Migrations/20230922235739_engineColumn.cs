using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPark.Repository.Migrations
{
    /// <inheritdoc />
    public partial class engineColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnginePower",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnginePower",
                table: "Vehicles");
        }
    }
}
