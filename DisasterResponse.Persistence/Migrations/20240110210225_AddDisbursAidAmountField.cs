using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisasterResponse.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDisbursAidAmountField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisbursesAid_IndividualRequests_IndividualRequestId",
                table: "DisbursesAid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DisbursesAid",
                table: "DisbursesAid");

            migrationBuilder.RenameTable(
                name: "DisbursesAid",
                newName: "DisbursesAids");

            migrationBuilder.RenameIndex(
                name: "IX_DisbursesAid_IndividualRequestId",
                table: "DisbursesAids",
                newName: "IX_DisbursesAids_IndividualRequestId");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "DisbursesAids",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DisbursesAids",
                table: "DisbursesAids",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DisbursesAids_IndividualRequests_IndividualRequestId",
                table: "DisbursesAids",
                column: "IndividualRequestId",
                principalTable: "IndividualRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisbursesAids_IndividualRequests_IndividualRequestId",
                table: "DisbursesAids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DisbursesAids",
                table: "DisbursesAids");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "DisbursesAids");

            migrationBuilder.RenameTable(
                name: "DisbursesAids",
                newName: "DisbursesAid");

            migrationBuilder.RenameIndex(
                name: "IX_DisbursesAids_IndividualRequestId",
                table: "DisbursesAid",
                newName: "IX_DisbursesAid_IndividualRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DisbursesAid",
                table: "DisbursesAid",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DisbursesAid_IndividualRequests_IndividualRequestId",
                table: "DisbursesAid",
                column: "IndividualRequestId",
                principalTable: "IndividualRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
