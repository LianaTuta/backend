using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketService.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Event5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventDetails_EventType_EventId",
                table: "EventDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_EventDetails_Event_EventId",
                table: "EventDetails",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventDetails_Event_EventId",
                table: "EventDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_EventDetails_EventType_EventId",
                table: "EventDetails",
                column: "EventId",
                principalTable: "EventType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
