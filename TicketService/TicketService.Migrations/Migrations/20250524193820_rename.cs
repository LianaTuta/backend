using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketService.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_artist_schedule_artist_ArtistId",
                table: "artist_schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_artist_schedule_event_schedule_EventScheduleId",
                table: "artist_schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_event_details_events_EventId",
                table: "event_details");

            migrationBuilder.DropForeignKey(
                name: "FK_event_schedule_events_EventId",
                table: "event_schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_events_event_type_EventTypeId",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_event_schedule_EventScheduleId",
                table: "ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_ticket_category_TicketCategoryId",
                table: "ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_order_checkout_order_CheckoutOrderId",
                table: "ticket_order");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "users",
                newName: "middle_name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "users",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "users",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "EmailConfirmed",
                table: "users",
                newName: "email_confirmed");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "users",
                newName: "date_updated");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "users",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "users",
                newName: "birth_date");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "user_roles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user_roles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ticket_order",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "ticket_order",
                newName: "ticket_id");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "ticket_order",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "ticket_order",
                newName: "end_date");

            migrationBuilder.RenameColumn(
                name: "CheckoutOrderId",
                table: "ticket_order",
                newName: "checkout_order_id");

            migrationBuilder.RenameIndex(
                name: "IX_ticket_order_CheckoutOrderId",
                table: "ticket_order",
                newName: "IX_ticket_order_checkout_order_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ticket_category",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ticket_category",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "ticket_category",
                newName: "date_updated");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "ticket_category",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "ticket",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ticket",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ticket",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ticket",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TicketCategoryId",
                table: "ticket",
                newName: "ticket_category_id");

            migrationBuilder.RenameColumn(
                name: "NumberOfAvailableTickets",
                table: "ticket",
                newName: "number_of_available_tickets");

            migrationBuilder.RenameColumn(
                name: "EventScheduleId",
                table: "ticket",
                newName: "event_schedule_id");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "ticket",
                newName: "date_updated");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "ticket",
                newName: "date_created");

            migrationBuilder.RenameIndex(
                name: "IX_ticket_TicketCategoryId",
                table: "ticket",
                newName: "IX_ticket_ticket_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_ticket_EventScheduleId",
                table: "ticket",
                newName: "IX_ticket_event_schedule_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "events",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "events",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "events",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "EventTypeId",
                table: "events",
                newName: "event_type_id");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "events",
                newName: "date_updated");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "events",
                newName: "date_created");

            migrationBuilder.RenameIndex(
                name: "IX_events_EventTypeId",
                table: "events",
                newName: "IX_events_event_type_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "event_type",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "event_type",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "event_type",
                newName: "date_updated");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "event_type",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "event_schedule",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "event_schedule",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "event_schedule",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "event_schedule",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "event_schedule",
                newName: "event_id");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "event_schedule",
                newName: "end_date");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "event_schedule",
                newName: "date_updated");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "event_schedule",
                newName: "date_created");

            migrationBuilder.RenameIndex(
                name: "IX_event_schedule_EventId",
                table: "event_schedule",
                newName: "IX_event_schedule_event_id");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "event_details",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "event_details",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "event_details",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "event_details",
                newName: "event_id");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "event_details",
                newName: "date_updated");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "event_details",
                newName: "date_created");

            migrationBuilder.RenameIndex(
                name: "IX_event_details_EventId",
                table: "event_details",
                newName: "IX_event_details_event_id");

            migrationBuilder.RenameColumn(
                name: "Step",
                table: "checkout_order",
                newName: "step");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "checkout_order",
                newName: "order");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "checkout_order",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "checkout_order",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "checkout_order",
                newName: "date_updated");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "checkout_order",
                newName: "date_created");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "artist_schedule",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "artist_schedule",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "EventScheduleId",
                table: "artist_schedule",
                newName: "event_schedule_id");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "artist_schedule",
                newName: "end_date");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "artist_schedule",
                newName: "artist_id");

            migrationBuilder.RenameIndex(
                name: "IX_artist_schedule_EventScheduleId",
                table: "artist_schedule",
                newName: "IX_artist_schedule_event_schedule_id");

            migrationBuilder.RenameIndex(
                name: "IX_artist_schedule_ArtistId",
                table: "artist_schedule",
                newName: "IX_artist_schedule_artist_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "artist",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "artist",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DateUpdated",
                table: "artist",
                newName: "date_updated");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "artist",
                newName: "date_created");

            migrationBuilder.AddForeignKey(
                name: "FK_artist_schedule_artist_artist_id",
                table: "artist_schedule",
                column: "artist_id",
                principalTable: "artist",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_artist_schedule_event_schedule_event_schedule_id",
                table: "artist_schedule",
                column: "event_schedule_id",
                principalTable: "event_schedule",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_event_details_events_event_id",
                table: "event_details",
                column: "event_id",
                principalTable: "events",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_event_schedule_events_event_id",
                table: "event_schedule",
                column: "event_id",
                principalTable: "events",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_events_event_type_event_type_id",
                table: "events",
                column: "event_type_id",
                principalTable: "event_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_event_schedule_event_schedule_id",
                table: "ticket",
                column: "event_schedule_id",
                principalTable: "event_schedule",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_ticket_category_ticket_category_id",
                table: "ticket",
                column: "ticket_category_id",
                principalTable: "ticket_category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_order_checkout_order_checkout_order_id",
                table: "ticket_order",
                column: "checkout_order_id",
                principalTable: "checkout_order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_artist_schedule_artist_artist_id",
                table: "artist_schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_artist_schedule_event_schedule_event_schedule_id",
                table: "artist_schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_event_details_events_event_id",
                table: "event_details");

            migrationBuilder.DropForeignKey(
                name: "FK_event_schedule_events_event_id",
                table: "event_schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_events_event_type_event_type_id",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_event_schedule_event_schedule_id",
                table: "ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_ticket_category_ticket_category_id",
                table: "ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_order_checkout_order_checkout_order_id",
                table: "ticket_order");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "middle_name",
                table: "users",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email_confirmed",
                table: "users",
                newName: "EmailConfirmed");

            migrationBuilder.RenameColumn(
                name: "date_updated",
                table: "users",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "date_created",
                table: "users",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "birth_date",
                table: "users",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "user_roles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "user_roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ticket_order",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ticket_id",
                table: "ticket_order",
                newName: "TicketId");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "ticket_order",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "end_date",
                table: "ticket_order",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "checkout_order_id",
                table: "ticket_order",
                newName: "CheckoutOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ticket_order_checkout_order_id",
                table: "ticket_order",
                newName: "IX_ticket_order_CheckoutOrderId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ticket_category",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ticket_category",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "date_updated",
                table: "ticket_category",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "date_created",
                table: "ticket_category",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "ticket",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ticket",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "ticket",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ticket",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ticket_category_id",
                table: "ticket",
                newName: "TicketCategoryId");

            migrationBuilder.RenameColumn(
                name: "number_of_available_tickets",
                table: "ticket",
                newName: "NumberOfAvailableTickets");

            migrationBuilder.RenameColumn(
                name: "event_schedule_id",
                table: "ticket",
                newName: "EventScheduleId");

            migrationBuilder.RenameColumn(
                name: "date_updated",
                table: "ticket",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "date_created",
                table: "ticket",
                newName: "DateCreated");

            migrationBuilder.RenameIndex(
                name: "IX_ticket_ticket_category_id",
                table: "ticket",
                newName: "IX_ticket_TicketCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ticket_event_schedule_id",
                table: "ticket",
                newName: "IX_ticket_EventScheduleId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "events",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "events",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "events",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "event_type_id",
                table: "events",
                newName: "EventTypeId");

            migrationBuilder.RenameColumn(
                name: "date_updated",
                table: "events",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "date_created",
                table: "events",
                newName: "DateCreated");

            migrationBuilder.RenameIndex(
                name: "IX_events_event_type_id",
                table: "events",
                newName: "IX_events_EventTypeId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "event_type",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "event_type",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "date_updated",
                table: "event_type",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "date_created",
                table: "event_type",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "event_schedule",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "event_schedule",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "event_schedule",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "event_schedule",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "event_id",
                table: "event_schedule",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "end_date",
                table: "event_schedule",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "date_updated",
                table: "event_schedule",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "date_created",
                table: "event_schedule",
                newName: "DateCreated");

            migrationBuilder.RenameIndex(
                name: "IX_event_schedule_event_id",
                table: "event_schedule",
                newName: "IX_event_schedule_EventId");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "event_details",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "event_details",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "event_details",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "event_id",
                table: "event_details",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "date_updated",
                table: "event_details",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "date_created",
                table: "event_details",
                newName: "DateCreated");

            migrationBuilder.RenameIndex(
                name: "IX_event_details_event_id",
                table: "event_details",
                newName: "IX_event_details_EventId");

            migrationBuilder.RenameColumn(
                name: "step",
                table: "checkout_order",
                newName: "Step");

            migrationBuilder.RenameColumn(
                name: "order",
                table: "checkout_order",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "checkout_order",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "checkout_order",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "date_updated",
                table: "checkout_order",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "date_created",
                table: "checkout_order",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "artist_schedule",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "artist_schedule",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "event_schedule_id",
                table: "artist_schedule",
                newName: "EventScheduleId");

            migrationBuilder.RenameColumn(
                name: "end_date",
                table: "artist_schedule",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "artist_id",
                table: "artist_schedule",
                newName: "ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_artist_schedule_event_schedule_id",
                table: "artist_schedule",
                newName: "IX_artist_schedule_EventScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_artist_schedule_artist_id",
                table: "artist_schedule",
                newName: "IX_artist_schedule_ArtistId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "artist",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "artist",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "date_updated",
                table: "artist",
                newName: "DateUpdated");

            migrationBuilder.RenameColumn(
                name: "date_created",
                table: "artist",
                newName: "DateCreated");

            migrationBuilder.AddForeignKey(
                name: "FK_artist_schedule_artist_ArtistId",
                table: "artist_schedule",
                column: "ArtistId",
                principalTable: "artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_artist_schedule_event_schedule_EventScheduleId",
                table: "artist_schedule",
                column: "EventScheduleId",
                principalTable: "event_schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_event_details_events_EventId",
                table: "event_details",
                column: "EventId",
                principalTable: "events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_event_schedule_events_EventId",
                table: "event_schedule",
                column: "EventId",
                principalTable: "events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_events_event_type_EventTypeId",
                table: "events",
                column: "EventTypeId",
                principalTable: "event_type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_event_schedule_EventScheduleId",
                table: "ticket",
                column: "EventScheduleId",
                principalTable: "event_schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_ticket_category_TicketCategoryId",
                table: "ticket",
                column: "TicketCategoryId",
                principalTable: "ticket_category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_order_checkout_order_CheckoutOrderId",
                table: "ticket_order",
                column: "CheckoutOrderId",
                principalTable: "checkout_order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
