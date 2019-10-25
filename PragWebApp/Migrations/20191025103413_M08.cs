using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PragWebApp.Migrations
{
    public partial class M08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("00100299-e32e-48ba-9d47-dd8f110f2262"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("3f2ee6ae-f39d-46d0-b76b-88880785ee15"), new Guid("febb0d03-57be-497c-a231-db39db97c2f6") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("ae5a97ba-7925-46a2-9a54-a3f42920f796"), new Guid("febb0d03-57be-497c-a231-db39db97c2f6") });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("3f2ee6ae-f39d-46d0-b76b-88880785ee15"), "PragWebAppLoginProvider", "Token1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("ae5a97ba-7925-46a2-9a54-a3f42920f796"), "PragWebAppLoginProvider", "Token2" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("750ee7a2-1033-407d-a991-80722fbfadfc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("febb0d03-57be-497c-a231-db39db97c2f6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3f2ee6ae-f39d-46d0-b76b-88880785ee15"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ae5a97ba-7925-46a2-9a54-a3f42920f796"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "Status" },
                values: new object[,]
                {
                    { new Guid("ec988b67-1144-49fc-b965-0de079c8af81"), "06d76caf-e300-412f-b57e-b1dc227d7296", "Administrators role", "Admin", "ADMIN", 1 },
                    { new Guid("a29b98f1-ad93-4384-b684-d2ee284f653a"), "a0ea99ba-020e-4dd3-ab47-28b8817d3ff7", "Stylists role", "Stylist", "STYLIST", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created", "DefaultColor", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("b58e2e7b-377e-4ece-b360-63bdcc16638a"), 0, "2b0850ac-e2be-40bd-acc0-76deac21bdb3", new DateTime(2019, 10, 25, 12, 34, 12, 533, DateTimeKind.Local).AddTicks(2879), "lightgreen", "xkalinam@email.cz", true, "Miroslav", "Kalina", false, null, "XKALINAM@EMAIL.CZ", "RESCATORX", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "123456789", true, null, 2, false, "RescatorX" },
                    { new Guid("cf54205c-285e-43d6-a6c8-d2cd8e87666d"), 0, "1bf0ac2a-cdc0-4c5c-b62d-7ba732c8bffe", new DateTime(2019, 10, 25, 12, 34, 12, 535, DateTimeKind.Local).AddTicks(4010), "lightblue", "jiri.pragr@seznam.cz", true, "Jiří", "Prágr", false, null, "JIRI.PRAGR@SEZNAM.CZ", "JPRAGR", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "987654321", true, null, 2, false, "jpragr" },
                    { new Guid("908ca5f0-bbe0-4d00-8b4f-95cc27055dbf"), 0, "2232eb9a-1207-4a71-87a2-0cef1038d2de", new DateTime(2019, 10, 25, 12, 34, 12, 535, DateTimeKind.Local).AddTicks(4244), "pink", "sandra.nisterova@seznam.cz", true, "Sandra", "Nisterová", false, null, "SANDRA.NISTEROVA@SEZNAM.CZ", "SNISTEROVA", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "666555444", true, null, 2, false, "snisterova" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Added" },
                values: new object[,]
                {
                    { new Guid("b58e2e7b-377e-4ece-b360-63bdcc16638a"), new Guid("ec988b67-1144-49fc-b965-0de079c8af81"), new DateTime(2019, 10, 25, 12, 34, 12, 535, DateTimeKind.Local).AddTicks(9594) },
                    { new Guid("908ca5f0-bbe0-4d00-8b4f-95cc27055dbf"), new Guid("ec988b67-1144-49fc-b965-0de079c8af81"), new DateTime(2019, 10, 25, 12, 34, 12, 536, DateTimeKind.Local).AddTicks(1248) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("b58e2e7b-377e-4ece-b360-63bdcc16638a"), "PragWebAppLoginProvider", "Token1", "Token1" },
                    { new Guid("908ca5f0-bbe0-4d00-8b4f-95cc27055dbf"), "PragWebAppLoginProvider", "Token2", "Token2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a29b98f1-ad93-4384-b684-d2ee284f653a"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("908ca5f0-bbe0-4d00-8b4f-95cc27055dbf"), new Guid("ec988b67-1144-49fc-b965-0de079c8af81") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("b58e2e7b-377e-4ece-b360-63bdcc16638a"), new Guid("ec988b67-1144-49fc-b965-0de079c8af81") });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("908ca5f0-bbe0-4d00-8b4f-95cc27055dbf"), "PragWebAppLoginProvider", "Token2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("b58e2e7b-377e-4ece-b360-63bdcc16638a"), "PragWebAppLoginProvider", "Token1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cf54205c-285e-43d6-a6c8-d2cd8e87666d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ec988b67-1144-49fc-b965-0de079c8af81"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("908ca5f0-bbe0-4d00-8b4f-95cc27055dbf"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b58e2e7b-377e-4ece-b360-63bdcc16638a"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "Status" },
                values: new object[,]
                {
                    { new Guid("febb0d03-57be-497c-a231-db39db97c2f6"), "437a7d54-e427-4ce0-9d08-050a39e9750c", "Administrators role", "Admin", "ADMIN", 1 },
                    { new Guid("00100299-e32e-48ba-9d47-dd8f110f2262"), "007bd3e8-c65c-4421-b1ea-903084e30b5d", "Stylists role", "Stylist", "STYLIST", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created", "DefaultColor", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("3f2ee6ae-f39d-46d0-b76b-88880785ee15"), 0, "dcd392aa-b203-408d-8ae9-f9e35dc24eed", new DateTime(2019, 10, 25, 12, 24, 55, 598, DateTimeKind.Local).AddTicks(2968), "#lightgreen", "xkalinam@email.cz", true, "Miroslav", "Kalina", false, null, "XKALINAM@EMAIL.CZ", "RESCATORX", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "123456789", true, null, 2, false, "RescatorX" },
                    { new Guid("750ee7a2-1033-407d-a991-80722fbfadfc"), 0, "fcbfe014-da90-4b9e-ad49-ab6b0f86bf14", new DateTime(2019, 10, 25, 12, 24, 55, 600, DateTimeKind.Local).AddTicks(5539), "#lightblue", "jiri.pragr@seznam.cz", true, "Jiří", "Prágr", false, null, "JIRI.PRAGR@SEZNAM.CZ", "JPRAGR", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "987654321", true, null, 2, false, "jpragr" },
                    { new Guid("ae5a97ba-7925-46a2-9a54-a3f42920f796"), 0, "bdafe05c-ad00-482f-9681-c169b1229f8a", new DateTime(2019, 10, 25, 12, 24, 55, 600, DateTimeKind.Local).AddTicks(5738), "#pink", "sandra.nisterova@seznam.cz", true, "Sandra", "Nisterová", false, null, "SANDRA.NISTEROVA@SEZNAM.CZ", "SNISTEROVA", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "666555444", true, null, 2, false, "snisterova" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Added" },
                values: new object[,]
                {
                    { new Guid("3f2ee6ae-f39d-46d0-b76b-88880785ee15"), new Guid("febb0d03-57be-497c-a231-db39db97c2f6"), new DateTime(2019, 10, 25, 12, 24, 55, 601, DateTimeKind.Local).AddTicks(2443) },
                    { new Guid("ae5a97ba-7925-46a2-9a54-a3f42920f796"), new Guid("febb0d03-57be-497c-a231-db39db97c2f6"), new DateTime(2019, 10, 25, 12, 24, 55, 601, DateTimeKind.Local).AddTicks(4189) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("3f2ee6ae-f39d-46d0-b76b-88880785ee15"), "PragWebAppLoginProvider", "Token1", "Token1" },
                    { new Guid("ae5a97ba-7925-46a2-9a54-a3f42920f796"), "PragWebAppLoginProvider", "Token2", "Token2" }
                });
        }
    }
}
