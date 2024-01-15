using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisasterResponse.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDisbursAid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisbursesAid",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisbursesSteps = table.Column<int>(type: "int", nullable: false),
                    IndividualRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisbursesAid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisbursesAid_IndividualRequests_IndividualRequestId",
                        column: x => x.IndividualRequestId,
                        principalTable: "IndividualRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisbursesAid_IndividualRequestId",
                table: "DisbursesAid",
                column: "IndividualRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisbursesAid");
        }
    }
}
