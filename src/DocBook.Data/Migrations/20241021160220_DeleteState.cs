using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocBook.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a50c303b-1e51-472e-b5cf-7445f1ee75ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4929c5b-d6e2-4fce-a93a-609ba5632d7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0171f20-5597-42a6-8dab-715e1301562c");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Appointments");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "State",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                column: "State",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3,
                column: "State",
                value: 2);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a50c303b-1e51-472e-b5cf-7445f1ee75ea", null, "Doctor", "DOCTOR" },
                    { "c4929c5b-d6e2-4fce-a93a-609ba5632d7a", null, "Patient", "PATIENT" },
                    { "e0171f20-5597-42a6-8dab-715e1301562c", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fcdcfc52-a3f1-4b18-b87f-006d97db9ff0", "bd5ee47c-91d9-4be8-b397-b2ff4034fb51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cf1622f0-0ffd-4a92-9baa-2b21a6d0faca", "db6b7f7e-5b24-4eab-b269-7ed724a070ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a7d28730-dc39-41f7-b962-dc4c509f0cf8", "5ce9db01-e902-43c5-8f4a-8ad8332dd88f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f7ef5ae9-56d3-42a1-a5b5-ad7bb0895b34", "5e21edb6-4d6b-4e22-99ab-f547648dc097" });
        }
    }
}
