using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PragWebApp.Migrations
{
    public partial class M06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("07a9fd5b-4aa6-48c2-b048-989b821d1eb2"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("58349e0b-1dea-4921-bff4-770e8c47e2c6"), new Guid("b50cf3cb-8569-46bb-a6a1-f1c174062aa5") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("f5d04a05-b57f-41cb-b734-1d7bfef1b47d"), new Guid("b50cf3cb-8569-46bb-a6a1-f1c174062aa5") });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("58349e0b-1dea-4921-bff4-770e8c47e2c6"), "PragWebAppLoginProvider", "Token1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("f5d04a05-b57f-41cb-b734-1d7bfef1b47d"), "PragWebAppLoginProvider", "Token2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b50cf3cb-8569-46bb-a6a1-f1c174062aa5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("58349e0b-1dea-4921-bff4-770e8c47e2c6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f5d04a05-b57f-41cb-b734-1d7bfef1b47d"));

            migrationBuilder.AddColumn<string>(
                name: "DefaultColor",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "Status" },
                values: new object[,]
                {
                    { new Guid("0d9a3255-1830-4492-96b0-65b52f58bd46"), "16020754-2a9b-46b2-bda1-3cf47e5a6352", "Administrators role", "Admin", "ADMIN", 1 },
                    { new Guid("958f754d-eca7-4781-8bb1-8875084602f5"), "11d430b9-9504-4c80-9828-d672a5e7edbc", "Stylists role", "Stylist", "STYLIST", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created", "DefaultColor", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("54ccdd73-b3d7-478a-8fae-f73b5b9b43af"), 0, "fa8a7506-0f35-4d24-ac46-a348d8f85e8d", new DateTime(2019, 10, 25, 9, 37, 47, 64, DateTimeKind.Local).AddTicks(171), "#lightgreen", "xkalinam@email.cz", true, "Miroslav", "Kalina", false, null, "XKALINAM@EMAIL.CZ", "RESCATORX", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "123456789", true, null, 2, false, "RescatorX" },
                    { new Guid("a9736a6e-be7e-437b-a3b7-3555f5403f29"), 0, "1fcec2c3-e6ec-4b70-a1ea-d8854f25dbdb", new DateTime(2019, 10, 25, 9, 37, 47, 66, DateTimeKind.Local).AddTicks(2611), "#lightblue", "jiri.pragr@seznam.cz", true, "Jiří", "Prágr", false, null, "JIRI.PRAGR@SEZNAM.CZ", "JPRAGR", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "987654321", true, null, 2, false, "jpragr" },
                    { new Guid("27549f0f-b3a5-44d6-a81e-8d48afa5628c"), 0, "47f8e07a-379f-47de-adc2-21626bd081b1", new DateTime(2019, 10, 25, 9, 37, 47, 66, DateTimeKind.Local).AddTicks(2759), "#pink", "sandra.nisterova@seznam.cz", true, "Sandra", "Nisterová", false, null, "SANDRA.NISTEROVA@SEZNAM.CZ", "SNISTEROVA", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "666555444", true, null, 2, false, "snisterova" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Added" },
                values: new object[,]
                {
                    { new Guid("54ccdd73-b3d7-478a-8fae-f73b5b9b43af"), new Guid("0d9a3255-1830-4492-96b0-65b52f58bd46"), new DateTime(2019, 10, 25, 9, 37, 47, 66, DateTimeKind.Local).AddTicks(8197) },
                    { new Guid("27549f0f-b3a5-44d6-a81e-8d48afa5628c"), new Guid("0d9a3255-1830-4492-96b0-65b52f58bd46"), new DateTime(2019, 10, 25, 9, 37, 47, 66, DateTimeKind.Local).AddTicks(9343) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("54ccdd73-b3d7-478a-8fae-f73b5b9b43af"), "PragWebAppLoginProvider", "Token1", "Token1" },
                    { new Guid("27549f0f-b3a5-44d6-a81e-8d48afa5628c"), "PragWebAppLoginProvider", "Token2", "Token2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("958f754d-eca7-4781-8bb1-8875084602f5"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("27549f0f-b3a5-44d6-a81e-8d48afa5628c"), new Guid("0d9a3255-1830-4492-96b0-65b52f58bd46") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("54ccdd73-b3d7-478a-8fae-f73b5b9b43af"), new Guid("0d9a3255-1830-4492-96b0-65b52f58bd46") });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("27549f0f-b3a5-44d6-a81e-8d48afa5628c"), "PragWebAppLoginProvider", "Token2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("54ccdd73-b3d7-478a-8fae-f73b5b9b43af"), "PragWebAppLoginProvider", "Token1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9736a6e-be7e-437b-a3b7-3555f5403f29"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0d9a3255-1830-4492-96b0-65b52f58bd46"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("27549f0f-b3a5-44d6-a81e-8d48afa5628c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("54ccdd73-b3d7-478a-8fae-f73b5b9b43af"));

            migrationBuilder.DropColumn(
                name: "DefaultColor",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "Status" },
                values: new object[,]
                {
                    { new Guid("b50cf3cb-8569-46bb-a6a1-f1c174062aa5"), "fb45648d-c0d3-45b2-b6bb-2b2d4521c59b", "Administrators role", "Admin", "ADMIN", 1 },
                    { new Guid("07a9fd5b-4aa6-48c2-b048-989b821d1eb2"), "fd10a151-ad05-4ab8-9499-8ede30600d8a", "Stylists role", "Stylist", "STYLIST", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("58349e0b-1dea-4921-bff4-770e8c47e2c6"), 0, "6d99e130-7333-4be2-a513-45c42b48566f", new DateTime(2019, 10, 23, 12, 12, 12, 565, DateTimeKind.Local).AddTicks(5462), "xkalinam@email.cz", true, "Miroslav", "Kalina", false, null, "XKALINAM@EMAIL.CZ", "RESCATORX", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "123456789", true, null, 2, false, "RescatorX" },
                    { new Guid("f5d04a05-b57f-41cb-b734-1d7bfef1b47d"), 0, "ca8496da-bf46-4554-a6b1-7095f5f70135", new DateTime(2019, 10, 23, 12, 12, 12, 567, DateTimeKind.Local).AddTicks(3336), "jiri.pragr@seznam.cz", true, "Jiří", "Prágr", false, null, "JIRI.PRAGR@SEZNAM.CZ", "JPRAGR", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "987654321", true, null, 2, false, "jpragr" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Added" },
                values: new object[,]
                {
                    { new Guid("58349e0b-1dea-4921-bff4-770e8c47e2c6"), new Guid("b50cf3cb-8569-46bb-a6a1-f1c174062aa5"), new DateTime(2019, 10, 23, 12, 12, 12, 567, DateTimeKind.Local).AddTicks(9437) },
                    { new Guid("f5d04a05-b57f-41cb-b734-1d7bfef1b47d"), new Guid("b50cf3cb-8569-46bb-a6a1-f1c174062aa5"), new DateTime(2019, 10, 23, 12, 12, 12, 568, DateTimeKind.Local).AddTicks(1228) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("58349e0b-1dea-4921-bff4-770e8c47e2c6"), "PragWebAppLoginProvider", "Token1", "Token1" },
                    { new Guid("f5d04a05-b57f-41cb-b734-1d7bfef1b47d"), "PragWebAppLoginProvider", "Token2", "Token2" }
                });
        }
    }
}
