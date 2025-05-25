using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TicketService.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_ticket_order_payment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ticket_order_id = table.Column<int>(type: "integer", nullable: false),
                    TicketOrderId = table.Column<int>(type: "integer", nullable: false),
                    user_payment_id = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    date_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_ticket_order_payment", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_ticket_order_payment_ticket_order_TicketOrderId",
                        column: x => x.TicketOrderId,
                        principalTable: "ticket_order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_ticket_order_payment_user_payment_user_payment_id",
                        column: x => x.user_payment_id,
                        principalTable: "user_payment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_ticket_order_payment_TicketOrderId",
                table: "user_ticket_order_payment",
                column: "TicketOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_user_ticket_order_payment_user_payment_id",
                table: "user_ticket_order_payment",
                column: "user_payment_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_ticket_order_payment");
        }
    }
}
