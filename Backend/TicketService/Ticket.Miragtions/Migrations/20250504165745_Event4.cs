using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketService.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Event4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Last",
                table: "Users",
                newName: "DateCreated");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Users",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Users",
                newName: "Last");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
