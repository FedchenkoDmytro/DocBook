using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocBook.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "0b8bbd7c-6049-436e-9cd3-35dcaee75a79", null, "Patient", "PATIENT" },
                    { "1a6b069a-6bfc-4646-b5f9-82ae21725a38", null, "Doctor", "DOCTOR" },
                    { "5d153b3e-7de5-490e-942e-87bf207656c2", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "89cff9af-a323-41d7-a078-641c67adcc71", "AQAAAAIAAYagAAAAENo+bSdyFVdrZdDDRpKslHwS+uh+du2ND+rH3SG6ayqAvSSYHNG2ViozVGAtIYxzAw==", "4b1c3eb4-6053-44ae-8ff2-389a3faf19e7", "johndoe@hospital.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "91ea7e46-c4c8-486c-b2f2-c4111377e2a6", "AQAAAAIAAYagAAAAEEIW0kCXpBQIIHDjyTBdytdjBm2e111IkWzBnl1SaGqDAq5FI9w1gD0IXbz4nMXZUA==", "6ccec07f-9e2a-471a-b306-f9c87a021334", "janesmith@hospital.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "d8519cab-a862-412e-a11e-fb091f93fbf8", "AQAAAAIAAYagAAAAELMc3e/C0X5Bn0vXspb2GdIDq2v483Xt+ykkxRvwxfmSS1fkwc5ry/zYXL2V1XxFBg==", "462b5afa-615c-4e86-bf73-f2f0c85828e2", "alice@patient.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "41697ce2-6aa9-470e-a85d-b9081871a98d", "AQAAAAIAAYagAAAAEEf2GU07vBTUd36I1FUnSBZueJcmwmZlbH01u2qVKvnc/QyXDrVV1/Hz44CMQzs3Dg==", "292f66db-1fd9-4ef7-b0f7-c08cb9827f5c", "bob@patient.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b8bbd7c-6049-436e-9cd3-35dcaee75a79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a6b069a-6bfc-4646-b5f9-82ae21725a38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d153b3e-7de5-490e-942e-87bf207656c2");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "452f6eb1-e5b0-4b73-af16-e57102c70c86", "hashedpassword123", "36f24465-a2bd-4c1a-89e6-95268c0d9513", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "82fab036-f8c5-4280-ac8e-1a51e48a33f2", "hashedpassword456", "63cf5bde-4fd2-4780-bab6-ebb8cf0fff03", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "124bac89-f3b4-4ffd-a3e9-c8a847d5ea40", "hashedpassword789", "94bc3747-2637-4a66-a1fe-beaa5b3bd8fb", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8dc384a9-f201-4887-b2b4-4c0a5c955300", "hashedpassword101", "c07d7a24-7f52-4b90-97a8-bfd75dc13f3c", null });
        }
    }
}
