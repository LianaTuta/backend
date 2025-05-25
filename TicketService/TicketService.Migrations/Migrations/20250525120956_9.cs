using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TicketService.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class _9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_ticket_order_payment");

            migrationBuilder.DropTable(
                name: "user_payment");

            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    checkout_order_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    return_url = table.Column<string>(type: "text", nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    payment_id = table.Column<string>(type: "text", nullable: false),
                    request = table.Column<Dictionary<string, object>>(type: "jsonb", nullable: false),
                    response = table.Column<Dictionary<string, object>>(type: "jsonb", nullable: true),
                    date_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment", x => x.id);
                    table.ForeignKey(
                        name: "FK_payment_checkout_order_checkout_order_id",
                        column: x => x.checkout_order_id,
                        principalTable: "checkout_order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_payment_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ticket_order_payment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ticket_order_id = table.Column<int>(type: "integer", nullable: false),
                    user_payment_id = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    date_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket_order_payment", x => x.id);
                    table.ForeignKey(
                        name: "FK_ticket_order_payment_payment_user_payment_id",
                        column: x => x.user_payment_id,
                        principalTable: "payment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ticket_order_payment_ticket_order_ticket_order_id",
                        column: x => x.ticket_order_id,
                        principalTable: "ticket_order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_payment_checkout_order_id",
                table: "payment",
                column: "checkout_order_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_user_id",
                table: "payment",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_order_payment_ticket_order_id",
                table: "ticket_order_payment",
                column: "ticket_order_id");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_order_payment_user_payment_id",
                table: "ticket_order_payment",
                column: "user_payment_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ticket_order_payment");

            migrationBuilder.DropTable(
                name: "payment");

            migrationBuilder.CreateTable(
                name: "user_payment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    date_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    payment_id = table.Column<string>(type: "text", nullable: false),
                    request = table.Column<Dictionary<string, object>>(type: "jsonb", nullable: false),
                    response = table.Column<Dictionary<string, object>>(type: "jsonb", nullable: true),
                    return_url = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_payment", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_payment_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_ticket_order_payment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ticket_order_id = table.Column<int>(type: "integer", nullable: false),
                    user_payment_id = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    date_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_ticket_order_payment", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_ticket_order_payment_ticket_order_ticket_order_id",
                        column: x => x.ticket_order_id,
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
                name: "IX_user_payment_user_id",
                table: "user_payment",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_ticket_order_payment_ticket_order_id",
                table: "user_ticket_order_payment",
                column: "ticket_order_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_ticket_order_payment_user_payment_id",
                table: "user_ticket_order_payment",
                column: "user_payment_id");
        }
    }
}
