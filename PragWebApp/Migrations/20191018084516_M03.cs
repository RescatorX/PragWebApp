using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PragWebApp.Migrations
{
    public partial class M03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedBy",
                table: "CalendarEvent",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "Status" },
                values: new object[,]
                {
                    { new Guid("b2a4d267-9259-47d3-af00-46608c80be0c"), "06b4f950-0b77-4239-801b-9805fb4bceb9", "Administrators role", "Admin", "ADMIN", 1 },
                    { new Guid("c25b44fc-c7fd-425d-b794-8577b9e393b8"), "05ea6a50-b191-490a-9060-a6fb808b7126", "Stylists role", "Stylist", "STYLIST", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("c51ac8cd-badf-4b9c-8d49-4cb51ae0d967"), 0, "4fd3a0ac-3fb5-434c-b96d-0c3b2769f24e", new DateTime(2019, 10, 18, 10, 45, 15, 382, DateTimeKind.Local).AddTicks(463), "xkalinam@email.cz", true, "Miroslav", "Kalina", false, null, "XKALINAM@EMAIL.CZ", "RESCATORX", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "123456789", true, null, 2, false, "RescatorX" },
                    { new Guid("e24f066e-6275-40c7-b80f-6248f5233515"), 0, "17af2b8c-3108-40c3-9e08-4e092b323538", new DateTime(2019, 10, 18, 10, 45, 15, 383, DateTimeKind.Local).AddTicks(8574), "jiri.pragr@seznam.cz", true, "Jiří", "Prágr", false, null, "JIRI.PRAGR@SEZNAM.CZ", "JPRAGR", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "987654321", true, null, 2, false, "jpragr" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Added" },
                values: new object[,]
                {
                    { new Guid("c51ac8cd-badf-4b9c-8d49-4cb51ae0d967"), new Guid("b2a4d267-9259-47d3-af00-46608c80be0c"), new DateTime(2019, 10, 18, 10, 45, 15, 384, DateTimeKind.Local).AddTicks(5875) },
                    { new Guid("e24f066e-6275-40c7-b80f-6248f5233515"), new Guid("b2a4d267-9259-47d3-af00-46608c80be0c"), new DateTime(2019, 10, 18, 10, 45, 15, 384, DateTimeKind.Local).AddTicks(7758) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("c51ac8cd-badf-4b9c-8d49-4cb51ae0d967"), "PragWebAppLoginProvider", "Token1", "Token1" },
                    { new Guid("e24f066e-6275-40c7-b80f-6248f5233515"), "PragWebAppLoginProvider", "Token2", "Token2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c25b44fc-c7fd-425d-b794-8577b9e393b8"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("c51ac8cd-badf-4b9c-8d49-4cb51ae0d967"), new Guid("b2a4d267-9259-47d3-af00-46608c80be0c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("e24f066e-6275-40c7-b80f-6248f5233515"), new Guid("b2a4d267-9259-47d3-af00-46608c80be0c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("c51ac8cd-badf-4b9c-8d49-4cb51ae0d967"), "PragWebAppLoginProvider", "Token1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("e24f066e-6275-40c7-b80f-6248f5233515"), "PragWebAppLoginProvider", "Token2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b2a4d267-9259-47d3-af00-46608c80be0c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c51ac8cd-badf-4b9c-8d49-4cb51ae0d967"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e24f066e-6275-40c7-b80f-6248f5233515"));

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CalendarEvent");

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
    }
}
