using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketService.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Event2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Event_EventId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TotalNumberSeats",
                table: "EventDetails");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Order",
                newName: "TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_EventId",
                table: "Order",
                newName: "IX_Order_TicketId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "EventDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "EventDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Event",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSchedule_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtistSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    EventScheduleId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtistSchedule_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistSchedule_EventSchedule_EventScheduleId",
                        column: x => x.EventScheduleId,
                        principalTable: "EventSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketCategoryId = table.Column<int>(type: "int", nullable: false),
                    EventScheduleId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_EventSchedule_EventScheduleId",
                        column: x => x.EventScheduleId,
                        principalTable: "EventSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_TicketCategory_TicketCategoryId",
                        column: x => x.TicketCategoryId,
                        principalTable: "TicketCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventPrice_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSchedule_ArtistId",
                table: "ArtistSchedule",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSchedule_EventScheduleId",
                table: "ArtistSchedule",
                column: "EventScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_EventPrice_TicketId",
                table: "EventPrice",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSchedule_EventId",
                table: "EventSchedule",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_EventScheduleId",
                table: "Ticket",
                column: "EventScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TicketCategoryId",
                table: "Ticket",
                column: "TicketCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Ticket_TicketId",
                table: "Order",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Ticket_TicketId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "ArtistSchedule");

            migrationBuilder.DropTable(
                name: "EventPrice");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "EventSchedule");

            migrationBuilder.DropTable(
                name: "TicketCategory");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "EventDetails");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "EventDetails");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "Order",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_TicketId",
                table: "Order",
                newName: "IX_Order_EventId");

            migrationBuilder.AddColumn<int>(
                name: "TotalNumberSeats",
                table: "EventDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "Event",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Event_EventId",
                table: "Order",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
