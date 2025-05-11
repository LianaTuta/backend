using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketService.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Event3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModifiedDate",
                table: "Users",
                newName: "Last");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "EventSchedule",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "EventSchedule",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "Event",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Event",
                newName: "DateCreated");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "TicketCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "TicketCategory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "EventType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "EventType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "EventPrice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "EventPrice",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "EventDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "EventDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "ArtistSchedule",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Artist",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Artist",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "EventType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "TicketCategory");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "TicketCategory");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "EventType");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "EventType");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "EventPrice");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "EventPrice");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "EventDetails");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "EventDetails");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Artist");

            migrationBuilder.RenameColumn(
                name: "Last",
                table: "Users",
                newName: "LastModifiedDate");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "EventSchedule",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "EventSchedule",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "Event",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Event",
                newName: "Created");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "ArtistSchedule",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
