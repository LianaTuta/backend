using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TicketService.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class tets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketOrderId",
                table: "ticket_order",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "user_payment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    UserModelId = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    payment_id = table.Column<string>(type: "text", nullable: false),
                    request = table.Column<Dictionary<string, object>>(type: "jsonb", nullable: false),
                    response = table.Column<Dictionary<string, object>>(type: "jsonb", nullable: true),
                    date_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_payment", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_payment_users_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ticket_order_TicketOrderId",
                table: "ticket_order",
                column: "TicketOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_user_payment_UserModelId",
                table: "user_payment",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_order_ticket_order_TicketOrderId",
                table: "ticket_order",
                column: "TicketOrderId",
                principalTable: "ticket_order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticket_order_ticket_order_TicketOrderId",
                table: "ticket_order");

            migrationBuilder.DropTable(
                name: "user_payment");

            migrationBuilder.DropIndex(
                name: "IX_ticket_order_TicketOrderId",
                table: "ticket_order");

            migrationBuilder.DropColumn(
                name: "TicketOrderId",
                table: "ticket_order");
        }
    }
}
