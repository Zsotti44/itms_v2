using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace itms_v2.Server.Migrations
{
    /// <inheritdoc />
    public partial class Correction4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_Users_dispatcherId",
                table: "Shifts");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_dispatcherId",
                table: "Shifts");

            migrationBuilder.RenameColumn(
                name: "dispatcherId",
                table: "Shifts",
                newName: "dispatcher");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dispatcher",
                table: "Shifts",
                newName: "dispatcherId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_dispatcherId",
                table: "Shifts",
                column: "dispatcherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_Users_dispatcherId",
                table: "Shifts",
                column: "dispatcherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
