using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketService.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class _12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticket_order_payment_payment_user_payment_id",
                table: "ticket_order_payment");

            migrationBuilder.RenameColumn(
                name: "user_payment_id",
                table: "ticket_order_payment",
                newName: "payment_id");

            migrationBuilder.RenameIndex(
                name: "IX_ticket_order_payment_user_payment_id",
                table: "ticket_order_payment",
                newName: "IX_ticket_order_payment_payment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_order_payment_payment_payment_id",
                table: "ticket_order_payment",
                column: "payment_id",
                principalTable: "payment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticket_order_payment_payment_payment_id",
                table: "ticket_order_payment");

            migrationBuilder.RenameColumn(
                name: "payment_id",
                table: "ticket_order_payment",
                newName: "user_payment_id");

            migrationBuilder.RenameIndex(
                name: "IX_ticket_order_payment_payment_id",
                table: "ticket_order_payment",
                newName: "IX_ticket_order_payment_user_payment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_order_payment_payment_user_payment_id",
                table: "ticket_order_payment",
                column: "user_payment_id",
                principalTable: "payment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
