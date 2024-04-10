using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAVacation.Migrations
{
    /// <inheritdoc />
    public partial class AddPricePerNight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PricePerNight",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerNight",
                table: "Properties");
        }
    }
}
