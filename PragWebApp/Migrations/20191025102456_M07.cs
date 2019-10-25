using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PragWebApp.Migrations
{
    public partial class M07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "CalendarEvent",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedById",
                table: "CalendarEvent",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvent_ModifiedById",
                table: "CalendarEvent",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarEvent_AspNetUsers_ModifiedById",
                table: "CalendarEvent",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarEvent_AspNetUsers_ModifiedById",
                table: "CalendarEvent");

            migrationBuilder.DropIndex(
                name: "IX_CalendarEvent_ModifiedById",
                table: "CalendarEvent");

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

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "CalendarEvent");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "CalendarEvent");

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
    }
}
