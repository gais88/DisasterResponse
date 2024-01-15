using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisasterResponse.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixAidDoner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonerId",
                table: "Aids");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DonerId",
                table: "Aids",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
