using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class automig_seeding_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileURL",
                table: "Tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Lists",
                columns: new[] { "id", "Timestamp", "Title", "isEnabled" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 23, 14, 13, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum", true },
                    { 2, new DateTime(2024, 4, 23, 10, 13, 0, 0, DateTimeKind.Unspecified), "dolor sit amet", true }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "id", "Description", "DueDate", "FileURL", "ListId", "NextRemindDate", "Status", "Timestamp", "Title", "Type", "isEnabled" },
                values: new object[,]
                {
                    { 1, "viverra tellus in hac habitasse", new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "files/Image.png", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", new DateTime(2024, 4, 23, 14, 13, 0, 0, DateTimeKind.Unspecified), "tincidunt ornare", "None", true },
                    { 2, "viverra tellus in hac habitasse", new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "files/Image.png", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", new DateTime(2024, 4, 23, 14, 13, 0, 0, DateTimeKind.Unspecified), "tincidunt ornare", "None", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "FileURL",
                table: "Tasks");
        }
    }
}
