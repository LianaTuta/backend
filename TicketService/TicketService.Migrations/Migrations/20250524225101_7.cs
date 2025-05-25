using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketService.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class _7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticket_order_ticket_order_ticket_id",
                table: "ticket_order");

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_order_ticket_ticket_id",
                table: "ticket_order",
                column: "ticket_id",
                principalTable: "ticket",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticket_order_ticket_ticket_id",
                table: "ticket_order");

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_order_ticket_order_ticket_id",
                table: "ticket_order",
                column: "ticket_id",
                principalTable: "ticket_order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
