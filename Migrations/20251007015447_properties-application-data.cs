using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectApiBasics.Migrations
{
    /// <inheritdoc />
    public partial class propertiesapplicationdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateTimeCreated",
                table: "Games",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<float>(
                name: "Review",
                table: "Games",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Studio",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeCreated",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Review",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Studio",
                table: "Games");
        }
    }
}
