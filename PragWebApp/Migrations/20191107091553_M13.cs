using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PragWebApp.Migrations
{
    public partial class M13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("63674a6d-940b-4109-91db-19ab465c24ca"), new Guid("d3396f6e-1edc-492c-a1a8-b6940d218ff2") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("63674a6d-940b-4109-91db-19ab465c24ca"), new Guid("e1a1576d-266c-4ded-9b31-05acb03c558e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("9b234bd4-7e0a-405b-9e90-b7402308cf62"), new Guid("e1a1576d-266c-4ded-9b31-05acb03c558e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("d68b8a26-1560-470f-acb7-29ce48eb100e"), new Guid("d3396f6e-1edc-492c-a1a8-b6940d218ff2") });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("63674a6d-940b-4109-91db-19ab465c24ca"), "PragWebAppLoginProvider", "Token2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("9b234bd4-7e0a-405b-9e90-b7402308cf62"), "PragWebAppLoginProvider", "Token1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d3396f6e-1edc-492c-a1a8-b6940d218ff2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1a1576d-266c-4ded-9b31-05acb03c558e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("63674a6d-940b-4109-91db-19ab465c24ca"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9b234bd4-7e0a-405b-9e90-b7402308cf62"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d68b8a26-1560-470f-acb7-29ce48eb100e"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "Status" },
                values: new object[,]
                {
                    { new Guid("1e49a349-eb22-423b-acce-f970087da37b"), "889c8969-6ade-4481-b643-066b799f23d1", "Stylists role", "Stylist", "STYLIST", 1 },
                    { new Guid("8a2c5e38-4897-492c-8c29-017abb95afbc"), "de78c235-ed58-4e67-8ea4-fe42cec4bd92", "Administrators role", "Admin", "ADMIN", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created", "DefaultColor", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("076fe42f-6ae9-4605-a763-4e6b21902f19"), 0, "6e049757-58c5-47cb-9ce9-1fce5d7547fb", new DateTime(2019, 11, 7, 10, 15, 52, 410, DateTimeKind.Local).AddTicks(9986), "pink", "sandra.nisterova@seznam.cz", true, "Sandra", "Nisterová", false, null, "SANDRA.NISTEROVA@SEZNAM.CZ", "SNISTEROVA", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "666555444", true, null, 2, false, "snisterova" },
                    { new Guid("b9e8ee77-2fa6-4275-b50e-0223ef9218a7"), 0, "c75de219-b7e1-4ff5-9d6d-2e3ef2ce583d", new DateTime(2019, 11, 7, 10, 15, 52, 409, DateTimeKind.Local).AddTicks(3008), "lightgreen", "xkalinam@email.cz", true, "Miroslav", "Kalina", false, null, "XKALINAM@EMAIL.CZ", "RESCATORX", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "123456789", true, null, 2, false, "RescatorX" },
                    { new Guid("b62baacf-5911-4826-bf14-6d07f199f7ad"), 0, "e14a54ce-cfae-47cf-955e-0ab8fdaa2a6c", new DateTime(2019, 11, 7, 10, 15, 52, 410, DateTimeKind.Local).AddTicks(9821), "lightblue", "jiri.pragr@seznam.cz", true, "Jiří", "Prágr", false, null, "JIRI.PRAGR@SEZNAM.CZ", "JPRAGR", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "987654321", true, null, 2, false, "jpragr" }
                });

            migrationBuilder.InsertData(
                table: "CalendarEventType",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[,]
                {
                    { new Guid("ad31b205-3996-479e-81ea-53c6c1c4e037"), "lightbrown", "JINÉ" },
                    { new Guid("123300c2-60cf-41b4-8b7d-ff8ca9eb1432"), "cyan", "VÝČES" },
                    { new Guid("0dcf8f41-3383-4193-a67f-a86f5a87d2b9"), "red", "KONZULTACE" },
                    { new Guid("ac984de6-5a47-47e9-939a-744ab4b1876e"), "magenta", "AGÁVE" },
                    { new Guid("1842cb64-e8b3-48c6-a9a8-fc74addf8123"), "blue", "MSF" },
                    { new Guid("5eaacc9d-12b9-4ecc-8025-3fbe26b5fe7e"), "brown", "MF" },
                    { new Guid("bc122343-a1ae-428b-a3e8-3ccda26ef002"), "orange", "BSF" },
                    { new Guid("5974f2dd-753a-4a5d-8553-bfda065f2d74"), "pink", "BF" },
                    { new Guid("3e7b3417-bd0d-43cc-873a-8a6971e8cd0a"), "yellow", "SF" },
                    { new Guid("7c53e34f-5086-4a8d-a7eb-33c65c444059"), "lightblue", "PS" },
                    { new Guid("be0cb773-8adf-4bb7-8cdc-c178b51aaf7d"), "green", "TONER" },
                    { new Guid("96fdb6aa-3803-49f4-994d-b212c85c475f"), "lightgreen", "F" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Added" },
                values: new object[,]
                {
                    { new Guid("b9e8ee77-2fa6-4275-b50e-0223ef9218a7"), new Guid("8a2c5e38-4897-492c-8c29-017abb95afbc"), new DateTime(2019, 11, 7, 10, 15, 52, 411, DateTimeKind.Local).AddTicks(5124) },
                    { new Guid("b62baacf-5911-4826-bf14-6d07f199f7ad"), new Guid("8a2c5e38-4897-492c-8c29-017abb95afbc"), new DateTime(2019, 11, 7, 10, 15, 52, 411, DateTimeKind.Local).AddTicks(6493) },
                    { new Guid("b62baacf-5911-4826-bf14-6d07f199f7ad"), new Guid("1e49a349-eb22-423b-acce-f970087da37b"), new DateTime(2019, 11, 7, 10, 15, 52, 411, DateTimeKind.Local).AddTicks(6549) },
                    { new Guid("076fe42f-6ae9-4605-a763-4e6b21902f19"), new Guid("1e49a349-eb22-423b-acce-f970087da37b"), new DateTime(2019, 11, 7, 10, 15, 52, 411, DateTimeKind.Local).AddTicks(6571) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("b9e8ee77-2fa6-4275-b50e-0223ef9218a7"), "PragWebAppLoginProvider", "Token1", "Token1" },
                    { new Guid("b62baacf-5911-4826-bf14-6d07f199f7ad"), "PragWebAppLoginProvider", "Token2", "Token2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("076fe42f-6ae9-4605-a763-4e6b21902f19"), new Guid("1e49a349-eb22-423b-acce-f970087da37b") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("b62baacf-5911-4826-bf14-6d07f199f7ad"), new Guid("1e49a349-eb22-423b-acce-f970087da37b") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("b62baacf-5911-4826-bf14-6d07f199f7ad"), new Guid("8a2c5e38-4897-492c-8c29-017abb95afbc") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("b9e8ee77-2fa6-4275-b50e-0223ef9218a7"), new Guid("8a2c5e38-4897-492c-8c29-017abb95afbc") });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("b62baacf-5911-4826-bf14-6d07f199f7ad"), "PragWebAppLoginProvider", "Token2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("b9e8ee77-2fa6-4275-b50e-0223ef9218a7"), "PragWebAppLoginProvider", "Token1" });

            migrationBuilder.DeleteData(
                table: "CalendarEventType",
                keyColumn: "Id",
                keyValue: new Guid("0dcf8f41-3383-4193-a67f-a86f5a87d2b9"));

            migrationBuilder.DeleteData(
                table: "CalendarEventType",
                keyColumn: "Id",
                keyValue: new Guid("123300c2-60cf-41b4-8b7d-ff8ca9eb1432"));

            migrationBuilder.DeleteData(
                table: "CalendarEventType",
                keyColumn: "Id",
                keyValue: new Guid("1842cb64-e8b3-48c6-a9a8-fc74addf8123"));

            migrationBuilder.DeleteData(
                table: "CalendarEventType",
                keyColumn: "Id",
                keyValue: new Guid("3e7b3417-bd0d-43cc-873a-8a6971e8cd0a"));

            migrationBuilder.DeleteData(
                table: "CalendarEventType",
                keyColumn: "Id",
                keyValue: new Guid("5974f2dd-753a-4a5d-8553-bfda065f2d74"));

            migrationBuilder.DeleteData(
                table: "CalendarEventType",
                keyColumn: "Id",
                keyValue: new Guid("5eaacc9d-12b9-4ecc-8025-3fbe26b5fe7e"));

            migrationBuilder.DeleteData(
                table: "CalendarEventType",
                keyColumn: "Id",
                keyValue: new Guid("7c53e34f-5086-4a8d-a7eb-33c65c444059"));

            migrationBuilder.DeleteData(
                table: "CalendarEventType",
                keyColumn: "Id",
                keyValue: new Guid("96fdb6aa-3803-49f4-994d-b212c85c475f"));

            migrationBuilder.DeleteData(
                table: "CalendarEventType",
                keyColumn: "Id",
                keyValue: new Guid("ac984de6-5a47-47e9-939a-744ab4b1876e"));

            migrationBuilder.DeleteData(
                table: "CalendarEventType",
                keyColumn: "Id",
                keyValue: new Guid("ad31b205-3996-479e-81ea-53c6c1c4e037"));

            migrationBuilder.DeleteData(
                table: "CalendarEventType",
                keyColumn: "Id",
                keyValue: new Guid("bc122343-a1ae-428b-a3e8-3ccda26ef002"));

            migrationBuilder.DeleteData(
                table: "CalendarEventType",
                keyColumn: "Id",
                keyValue: new Guid("be0cb773-8adf-4bb7-8cdc-c178b51aaf7d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1e49a349-eb22-423b-acce-f970087da37b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8a2c5e38-4897-492c-8c29-017abb95afbc"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("076fe42f-6ae9-4605-a763-4e6b21902f19"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b62baacf-5911-4826-bf14-6d07f199f7ad"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b9e8ee77-2fa6-4275-b50e-0223ef9218a7"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "Status" },
                values: new object[,]
                {
                    { new Guid("e1a1576d-266c-4ded-9b31-05acb03c558e"), "37189b3d-e203-458f-86f0-b998773142b1", "Administrators role", "Admin", "ADMIN", 1 },
                    { new Guid("d3396f6e-1edc-492c-a1a8-b6940d218ff2"), "d16bf70f-1b81-4c1e-b87f-735381dda6a3", "Stylists role", "Stylist", "STYLIST", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created", "DefaultColor", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("9b234bd4-7e0a-405b-9e90-b7402308cf62"), 0, "3aed30a4-1ca3-4e86-a61f-0d28933900b4", new DateTime(2019, 11, 4, 13, 15, 3, 278, DateTimeKind.Local).AddTicks(6575), "lightgreen", "xkalinam@email.cz", true, "Miroslav", "Kalina", false, null, "XKALINAM@EMAIL.CZ", "RESCATORX", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "123456789", true, null, 2, false, "RescatorX" },
                    { new Guid("63674a6d-940b-4109-91db-19ab465c24ca"), 0, "6a8a7d89-4755-4378-b8a0-995f0d8fa80a", new DateTime(2019, 11, 4, 13, 15, 3, 288, DateTimeKind.Local).AddTicks(8726), "lightblue", "jiri.pragr@seznam.cz", true, "Jiří", "Prágr", false, null, "JIRI.PRAGR@SEZNAM.CZ", "JPRAGR", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "987654321", true, null, 2, false, "jpragr" },
                    { new Guid("d68b8a26-1560-470f-acb7-29ce48eb100e"), 0, "da097a14-8c22-4345-9049-e32cf2b2545b", new DateTime(2019, 11, 4, 13, 15, 3, 288, DateTimeKind.Local).AddTicks(9449), "pink", "sandra.nisterova@seznam.cz", true, "Sandra", "Nisterová", false, null, "SANDRA.NISTEROVA@SEZNAM.CZ", "SNISTEROVA", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "666555444", true, null, 2, false, "snisterova" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Added" },
                values: new object[,]
                {
                    { new Guid("9b234bd4-7e0a-405b-9e90-b7402308cf62"), new Guid("e1a1576d-266c-4ded-9b31-05acb03c558e"), new DateTime(2019, 11, 4, 13, 15, 3, 289, DateTimeKind.Local).AddTicks(4967) },
                    { new Guid("63674a6d-940b-4109-91db-19ab465c24ca"), new Guid("e1a1576d-266c-4ded-9b31-05acb03c558e"), new DateTime(2019, 11, 4, 13, 15, 3, 289, DateTimeKind.Local).AddTicks(6420) },
                    { new Guid("63674a6d-940b-4109-91db-19ab465c24ca"), new Guid("d3396f6e-1edc-492c-a1a8-b6940d218ff2"), new DateTime(2019, 11, 4, 13, 15, 3, 289, DateTimeKind.Local).AddTicks(6489) },
                    { new Guid("d68b8a26-1560-470f-acb7-29ce48eb100e"), new Guid("d3396f6e-1edc-492c-a1a8-b6940d218ff2"), new DateTime(2019, 11, 4, 13, 15, 3, 289, DateTimeKind.Local).AddTicks(6515) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("9b234bd4-7e0a-405b-9e90-b7402308cf62"), "PragWebAppLoginProvider", "Token1", "Token1" },
                    { new Guid("63674a6d-940b-4109-91db-19ab465c24ca"), "PragWebAppLoginProvider", "Token2", "Token2" }
                });
        }
    }
}
