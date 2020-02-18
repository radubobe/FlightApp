using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelAPI.Migrations
{
    public partial class bbb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Passager_PassagerId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_PassagerId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Arrive",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Departure",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "PassagerId",
                table: "Booking");

            migrationBuilder.AddColumn<DateTime>(
                name: "Arrive",
                table: "Flight",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Departure",
                table: "Flight",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AppUserID",
                table: "Booking",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_AppUserID",
                table: "Booking",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_AspNetUsers_AppUserID",
                table: "Booking",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_AspNetUsers_AppUserID",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_AppUserID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Arrive",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "Departure",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Booking");

            migrationBuilder.AddColumn<DateTime>(
                name: "Arrive",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Departure",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PassagerId",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PassagerId",
                table: "Booking",
                column: "PassagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Passager_PassagerId",
                table: "Booking",
                column: "PassagerId",
                principalTable: "Passager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
