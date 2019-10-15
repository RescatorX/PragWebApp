using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PragWebApp.Migrations
{
    public partial class M02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d4166487-42b9-44ae-b2c1-1736d9c1d8ce"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("55cea356-1a85-46f2-96d4-2eb225bc663d"), new Guid("cb39dd53-3840-4dab-8c6a-de169087c800") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("86a2483e-ea01-4875-ae95-b70bf759bfba"), new Guid("cb39dd53-3840-4dab-8c6a-de169087c800") });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("55cea356-1a85-46f2-96d4-2eb225bc663d"), "PragWebAppLoginProvider", "Token2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("86a2483e-ea01-4875-ae95-b70bf759bfba"), "PragWebAppLoginProvider", "Token1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cb39dd53-3840-4dab-8c6a-de169087c800"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("55cea356-1a85-46f2-96d4-2eb225bc663d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("86a2483e-ea01-4875-ae95-b70bf759bfba"));

            migrationBuilder.RenameColumn(
                name: "Term",
                table: "CalendarEvent",
                newName: "Start");

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "CalendarEvent",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "Status" },
                values: new object[,]
                {
                    { new Guid("fff47175-d0a6-40c9-b8bd-dca96a19f07e"), "d3a6f2d3-c1c1-4b05-8103-18163a7e5a50", "Administrators role", "Admin", "ADMIN", 1 },
                    { new Guid("89f32d6e-0e06-40e8-9c7c-6c9f3146781f"), "a6e961de-ba32-4200-8d2e-b83b1dc7dd04", "Stylists role", "Stylist", "STYLIST", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("dbacbba3-6bc0-4ccd-b2a3-fcbee3262ada"), 0, "00abbe28-f890-413d-a7d9-981196497aaf", new DateTime(2019, 10, 14, 22, 17, 52, 19, DateTimeKind.Local).AddTicks(3707), "xkalinam@email.cz", true, "Miroslav", "Kalina", false, null, "XKALINAM@EMAIL.CZ", "RESCATORX", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "123456789", true, null, 2, false, "RescatorX" },
                    { new Guid("5fd14933-6a90-4840-ab0b-144400452b5e"), 0, "ff3053e0-4092-472a-b94a-08a4ca8b33b2", new DateTime(2019, 10, 14, 22, 17, 52, 22, DateTimeKind.Local).AddTicks(1897), "jiri.pragr@seznam.cz", true, "Jiří", "Prágr", false, null, "JIRI.PRAGR@SEZNAM.CZ", "JPRAGR", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "987654321", true, null, 2, false, "jpragr" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Added" },
                values: new object[,]
                {
                    { new Guid("dbacbba3-6bc0-4ccd-b2a3-fcbee3262ada"), new Guid("fff47175-d0a6-40c9-b8bd-dca96a19f07e"), new DateTime(2019, 10, 14, 22, 17, 52, 22, DateTimeKind.Local).AddTicks(6839) },
                    { new Guid("5fd14933-6a90-4840-ab0b-144400452b5e"), new Guid("fff47175-d0a6-40c9-b8bd-dca96a19f07e"), new DateTime(2019, 10, 14, 22, 17, 52, 22, DateTimeKind.Local).AddTicks(8281) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("dbacbba3-6bc0-4ccd-b2a3-fcbee3262ada"), "PragWebAppLoginProvider", "Token1", "Token1" },
                    { new Guid("5fd14933-6a90-4840-ab0b-144400452b5e"), "PragWebAppLoginProvider", "Token2", "Token2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("89f32d6e-0e06-40e8-9c7c-6c9f3146781f"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("5fd14933-6a90-4840-ab0b-144400452b5e"), new Guid("fff47175-d0a6-40c9-b8bd-dca96a19f07e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("dbacbba3-6bc0-4ccd-b2a3-fcbee3262ada"), new Guid("fff47175-d0a6-40c9-b8bd-dca96a19f07e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("5fd14933-6a90-4840-ab0b-144400452b5e"), "PragWebAppLoginProvider", "Token2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("dbacbba3-6bc0-4ccd-b2a3-fcbee3262ada"), "PragWebAppLoginProvider", "Token1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fff47175-d0a6-40c9-b8bd-dca96a19f07e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5fd14933-6a90-4840-ab0b-144400452b5e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dbacbba3-6bc0-4ccd-b2a3-fcbee3262ada"));

            migrationBuilder.DropColumn(
                name: "End",
                table: "CalendarEvent");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "CalendarEvent",
                newName: "Term");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "Status" },
                values: new object[,]
                {
                    { new Guid("cb39dd53-3840-4dab-8c6a-de169087c800"), "967065a1-4099-472a-9456-0fdfeb14e339", "Administrators role", "Admin", "ADMIN", 1 },
                    { new Guid("d4166487-42b9-44ae-b2c1-1736d9c1d8ce"), "e743ec0f-eac4-473e-8236-b9d45a6e6d16", "Stylists role", "Stylist", "STYLIST", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("86a2483e-ea01-4875-ae95-b70bf759bfba"), 0, "f3a86153-1767-441e-928a-b051a3f3ecb1", new DateTime(2019, 10, 8, 14, 41, 7, 969, DateTimeKind.Local).AddTicks(980), "xkalinam@email.cz", true, "Miroslav", "Kalina", false, null, "XKALINAM@EMAIL.CZ", "RESCATORX", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "123456789", true, null, 2, false, "RescatorX" },
                    { new Guid("55cea356-1a85-46f2-96d4-2eb225bc663d"), 0, "dab430ad-c901-4254-9ac0-17a335023cf8", new DateTime(2019, 10, 8, 14, 41, 7, 970, DateTimeKind.Local).AddTicks(6449), "jiri.pragr@seznam.cz", true, "Jiří", "Prágr", false, null, "JIRI.PRAGR@SEZNAM.CZ", "JPRAGR", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "987654321", true, null, 2, false, "jpragr" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Added" },
                values: new object[,]
                {
                    { new Guid("86a2483e-ea01-4875-ae95-b70bf759bfba"), new Guid("cb39dd53-3840-4dab-8c6a-de169087c800"), new DateTime(2019, 10, 8, 14, 41, 7, 971, DateTimeKind.Local).AddTicks(1201) },
                    { new Guid("55cea356-1a85-46f2-96d4-2eb225bc663d"), new Guid("cb39dd53-3840-4dab-8c6a-de169087c800"), new DateTime(2019, 10, 8, 14, 41, 7, 971, DateTimeKind.Local).AddTicks(2553) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("86a2483e-ea01-4875-ae95-b70bf759bfba"), "PragWebAppLoginProvider", "Token1", "Token1" },
                    { new Guid("55cea356-1a85-46f2-96d4-2eb225bc663d"), "PragWebAppLoginProvider", "Token2", "Token2" }
                });
        }
    }
}
