using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAVacation.Migrations
{
    /// <inheritdoc />
    public partial class AddMaxGuestsNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxGuestsNo",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxGuestsNo",
                table: "Properties");
        }
    }
}
