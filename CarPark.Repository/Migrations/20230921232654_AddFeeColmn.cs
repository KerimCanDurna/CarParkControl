using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPark.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddFeeColmn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Fee",
                table: "Vehicles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fee",
                table: "Vehicles");
        }
    }
}
