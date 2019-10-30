using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PragWebApp.Migrations
{
    public partial class M09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Title",
                table: "CalendarEvent");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "Status" },
                values: new object[,]
                {
                    { new Guid("48ed27dc-0ec9-416d-80dd-7720f77ed714"), "74d892a9-9c9f-46b2-adda-77d98b9bbc7e", "Administrators role", "Admin", "ADMIN", 1 },
                    { new Guid("ebce2ced-4814-4e32-be31-798eba05c59e"), "78a6ac78-ff4e-4c8a-9232-691e9d97d3f0", "Stylists role", "Stylist", "STYLIST", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created", "DefaultColor", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("345cf80b-29a8-400d-9e6b-aad37206d3da"), 0, "4f16e0c7-38a7-4f6d-a50a-4e34c7a4d9e5", new DateTime(2019, 10, 30, 0, 40, 38, 341, DateTimeKind.Local).AddTicks(2780), "lightgreen", "xkalinam@email.cz", true, "Miroslav", "Kalina", false, null, "XKALINAM@EMAIL.CZ", "RESCATORX", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "123456789", true, null, 2, false, "RescatorX" },
                    { new Guid("4b1a374b-bffa-4f5a-98c6-b74104a61f29"), 0, "f842b0a6-fd2f-4a62-81d3-5770e8fd543f", new DateTime(2019, 10, 30, 0, 40, 38, 345, DateTimeKind.Local).AddTicks(6863), "lightblue", "jiri.pragr@seznam.cz", true, "Jiří", "Prágr", false, null, "JIRI.PRAGR@SEZNAM.CZ", "JPRAGR", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "987654321", true, null, 2, false, "jpragr" },
                    { new Guid("3d609da1-9c14-4b22-9716-39318f48e6a2"), 0, "4ea2f115-0e6d-4e0d-8b7b-f8c796d2e643", new DateTime(2019, 10, 30, 0, 40, 38, 345, DateTimeKind.Local).AddTicks(7285), "pink", "sandra.nisterova@seznam.cz", true, "Sandra", "Nisterová", false, null, "SANDRA.NISTEROVA@SEZNAM.CZ", "SNISTEROVA", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "666555444", true, null, 2, false, "snisterova" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Added" },
                values: new object[,]
                {
                    { new Guid("345cf80b-29a8-400d-9e6b-aad37206d3da"), new Guid("48ed27dc-0ec9-416d-80dd-7720f77ed714"), new DateTime(2019, 10, 30, 0, 40, 38, 346, DateTimeKind.Local).AddTicks(4067) },
                    { new Guid("3d609da1-9c14-4b22-9716-39318f48e6a2"), new Guid("48ed27dc-0ec9-416d-80dd-7720f77ed714"), new DateTime(2019, 10, 30, 0, 40, 38, 346, DateTimeKind.Local).AddTicks(5650) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("345cf80b-29a8-400d-9e6b-aad37206d3da"), "PragWebAppLoginProvider", "Token1", "Token1" },
                    { new Guid("3d609da1-9c14-4b22-9716-39318f48e6a2"), "PragWebAppLoginProvider", "Token2", "Token2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ebce2ced-4814-4e32-be31-798eba05c59e"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("345cf80b-29a8-400d-9e6b-aad37206d3da"), new Guid("48ed27dc-0ec9-416d-80dd-7720f77ed714") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("3d609da1-9c14-4b22-9716-39318f48e6a2"), new Guid("48ed27dc-0ec9-416d-80dd-7720f77ed714") });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("345cf80b-29a8-400d-9e6b-aad37206d3da"), "PragWebAppLoginProvider", "Token1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("3d609da1-9c14-4b22-9716-39318f48e6a2"), "PragWebAppLoginProvider", "Token2" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4b1a374b-bffa-4f5a-98c6-b74104a61f29"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("48ed27dc-0ec9-416d-80dd-7720f77ed714"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("345cf80b-29a8-400d-9e6b-aad37206d3da"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3d609da1-9c14-4b22-9716-39318f48e6a2"));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CalendarEvent",
                nullable: true);

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
    }
}
