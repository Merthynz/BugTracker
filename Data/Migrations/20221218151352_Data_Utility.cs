using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataUtility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_OwnerUserid",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "OwnerUserid",
                table: "Tickets",
                newName: "OwnerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_OwnerUserid",
                table: "Tickets",
                newName: "IX_Tickets_OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_OwnerUserId",
                table: "Tickets",
                column: "OwnerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_OwnerUserId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "OwnerUserId",
                table: "Tickets",
                newName: "OwnerUserid");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_OwnerUserId",
                table: "Tickets",
                newName: "IX_Tickets_OwnerUserid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_OwnerUserid",
                table: "Tickets",
                column: "OwnerUserid",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
