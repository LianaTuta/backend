using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketService.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class fk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserModelId",
                table: "checkout_order",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_checkout_order_UserModelId",
                table: "checkout_order",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_checkout_order_users_UserModelId",
                table: "checkout_order",
                column: "UserModelId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_checkout_order_users_UserModelId",
                table: "checkout_order");

            migrationBuilder.DropIndex(
                name: "IX_checkout_order_UserModelId",
                table: "checkout_order");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "checkout_order");
        }
    }
}
