using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketService.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class _6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticket_order_ticket_order_TicketOrderId",
                table: "ticket_order");

            migrationBuilder.DropForeignKey(
                name: "FK_user_payment_users_UserModelId",
                table: "user_payment");

            migrationBuilder.DropForeignKey(
                name: "FK_user_ticket_order_payment_ticket_order_TicketOrderId",
                table: "user_ticket_order_payment");

            migrationBuilder.DropIndex(
                name: "IX_user_ticket_order_payment_TicketOrderId",
                table: "user_ticket_order_payment");

            migrationBuilder.DropIndex(
                name: "IX_user_payment_UserModelId",
                table: "user_payment");

            migrationBuilder.DropIndex(
                name: "IX_ticket_order_TicketOrderId",
                table: "ticket_order");

            migrationBuilder.DropColumn(
                name: "TicketOrderId",
                table: "user_ticket_order_payment");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "user_payment");

            migrationBuilder.DropColumn(
                name: "TicketOrderId",
                table: "ticket_order");

            migrationBuilder.CreateIndex(
                name: "IX_user_ticket_order_payment_ticket_order_id",
                table: "user_ticket_order_payment",
                column: "ticket_order_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_payment_user_id",
                table: "user_payment",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_order_ticket_id",
                table: "ticket_order",
                column: "ticket_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_order_ticket_order_ticket_id",
                table: "ticket_order",
                column: "ticket_id",
                principalTable: "ticket_order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_payment_users_user_id",
                table: "user_payment",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_ticket_order_payment_ticket_order_ticket_order_id",
                table: "user_ticket_order_payment",
                column: "ticket_order_id",
                principalTable: "ticket_order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticket_order_ticket_order_ticket_id",
                table: "ticket_order");

            migrationBuilder.DropForeignKey(
                name: "FK_user_payment_users_user_id",
                table: "user_payment");

            migrationBuilder.DropForeignKey(
                name: "FK_user_ticket_order_payment_ticket_order_ticket_order_id",
                table: "user_ticket_order_payment");

            migrationBuilder.DropIndex(
                name: "IX_user_ticket_order_payment_ticket_order_id",
                table: "user_ticket_order_payment");

            migrationBuilder.DropIndex(
                name: "IX_user_payment_user_id",
                table: "user_payment");

            migrationBuilder.DropIndex(
                name: "IX_ticket_order_ticket_id",
                table: "ticket_order");

            migrationBuilder.AddColumn<int>(
                name: "TicketOrderId",
                table: "user_ticket_order_payment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserModelId",
                table: "user_payment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TicketOrderId",
                table: "ticket_order",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_user_ticket_order_payment_TicketOrderId",
                table: "user_ticket_order_payment",
                column: "TicketOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_user_payment_UserModelId",
                table: "user_payment",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_order_TicketOrderId",
                table: "ticket_order",
                column: "TicketOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_order_ticket_order_TicketOrderId",
                table: "ticket_order",
                column: "TicketOrderId",
                principalTable: "ticket_order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_payment_users_UserModelId",
                table: "user_payment",
                column: "UserModelId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_ticket_order_payment_ticket_order_TicketOrderId",
                table: "user_ticket_order_payment",
                column: "TicketOrderId",
                principalTable: "ticket_order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
