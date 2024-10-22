using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocBook.Data.Migrations
{
    /// <inheritdoc />
    public partial class Tests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1416a603-f45b-4079-806c-3a43f3117591");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bec56418-04c1-4503-ba7d-5ca493859acf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d70bbcdd-3671-4f98-9f80-a751c0b2875e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37fed4f0-a981-4c64-9d0f-201ba9c4a5da", null, "Doctor", "DOCTOR" },
                    { "38987525-6955-449a-8691-2a0fd00b9c9a", null, "User", "USER" },
                    { "ae33f258-b053-479f-8efb-28785f5bbc17", null, "Patient", "PATIENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "452f6eb1-e5b0-4b73-af16-e57102c70c86", "36f24465-a2bd-4c1a-89e6-95268c0d9513" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "82fab036-f8c5-4280-ac8e-1a51e48a33f2", "63cf5bde-4fd2-4780-bab6-ebb8cf0fff03" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "124bac89-f3b4-4ffd-a3e9-c8a847d5ea40", "94bc3747-2637-4a66-a1fe-beaa5b3bd8fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8dc384a9-f201-4887-b2b4-4c0a5c955300", "c07d7a24-7f52-4b90-97a8-bfd75dc13f3c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37fed4f0-a981-4c64-9d0f-201ba9c4a5da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38987525-6955-449a-8691-2a0fd00b9c9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae33f258-b053-479f-8efb-28785f5bbc17");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1416a603-f45b-4079-806c-3a43f3117591", null, "User", "USER" },
                    { "bec56418-04c1-4503-ba7d-5ca493859acf", null, "Patient", "PATIENT" },
                    { "d70bbcdd-3671-4f98-9f80-a751c0b2875e", null, "Doctor", "DOCTOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ec721676-8309-4e23-8b5d-dc54aa2571ef", "2e223458-c1a2-4679-93e5-1319b114b2c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1a652bb8-9b6f-43df-b670-0aeb88e0816d", "03c3abfb-345e-41d2-9872-e65d6af6858c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "73c4996c-ed6b-4604-936d-501200d28e89", "b79285ab-3d05-4a52-b97d-60fee091db0a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b4243f4a-7ca1-4b54-997f-57b67b3a0017", "806f1c3a-deb8-41fb-9b88-db9c6a69ec28" });
        }
    }
}
