using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PragWebApp.Migrations
{
    public partial class M05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarEvent_CalendarEventType_EventId",
                table: "CalendarEvent");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d8eac52d-a3ce-46ec-9c24-4dea3362e2a2"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("8fbf0317-92a3-450e-8d02-5133a3c1c8b9"), new Guid("0d30709d-7e7c-408a-b5d5-6c7834eccb6f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("94c52b57-0241-4678-a74d-089b0403a226"), new Guid("0d30709d-7e7c-408a-b5d5-6c7834eccb6f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("8fbf0317-92a3-450e-8d02-5133a3c1c8b9"), "PragWebAppLoginProvider", "Token2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("94c52b57-0241-4678-a74d-089b0403a226"), "PragWebAppLoginProvider", "Token1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0d30709d-7e7c-408a-b5d5-6c7834eccb6f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8fbf0317-92a3-450e-8d02-5133a3c1c8b9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("94c52b57-0241-4678-a74d-089b0403a226"));

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "CalendarEvent",
                newName: "EventTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CalendarEvent_EventId",
                table: "CalendarEvent",
                newName: "IX_CalendarEvent_EventTypeId");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "CalendarEvent",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarEvent_CalendarEventType_EventTypeId",
                table: "CalendarEvent",
                column: "EventTypeId",
                principalTable: "CalendarEventType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarEvent_CalendarEventType_EventTypeId",
                table: "CalendarEvent");

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

            migrationBuilder.DropColumn(
                name: "Note",
                table: "CalendarEvent");

            migrationBuilder.RenameColumn(
                name: "EventTypeId",
                table: "CalendarEvent",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_CalendarEvent_EventTypeId",
                table: "CalendarEvent",
                newName: "IX_CalendarEvent_EventId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "Status" },
                values: new object[,]
                {
                    { new Guid("0d30709d-7e7c-408a-b5d5-6c7834eccb6f"), "13c38aa8-53d7-44d1-979c-5984b04fd7fc", "Administrators role", "Admin", "ADMIN", 1 },
                    { new Guid("d8eac52d-a3ce-46ec-9c24-4dea3362e2a2"), "18792c95-c442-48d9-b659-3d9dcfd397d0", "Stylists role", "Stylist", "STYLIST", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("94c52b57-0241-4678-a74d-089b0403a226"), 0, "dd9452d1-a0a5-440f-813c-0902b7d4e19f", new DateTime(2019, 10, 18, 10, 58, 42, 517, DateTimeKind.Local).AddTicks(729), "xkalinam@email.cz", true, "Miroslav", "Kalina", false, null, "XKALINAM@EMAIL.CZ", "RESCATORX", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "123456789", true, null, 2, false, "RescatorX" },
                    { new Guid("8fbf0317-92a3-450e-8d02-5133a3c1c8b9"), 0, "be0fa5ea-59f1-4b0b-a4c2-cc230e9e0480", new DateTime(2019, 10, 18, 10, 58, 42, 519, DateTimeKind.Local).AddTicks(7122), "jiri.pragr@seznam.cz", true, "Jiří", "Prágr", false, null, "JIRI.PRAGR@SEZNAM.CZ", "JPRAGR", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "987654321", true, null, 2, false, "jpragr" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Added" },
                values: new object[,]
                {
                    { new Guid("94c52b57-0241-4678-a74d-089b0403a226"), new Guid("0d30709d-7e7c-408a-b5d5-6c7834eccb6f"), new DateTime(2019, 10, 18, 10, 58, 42, 520, DateTimeKind.Local).AddTicks(4666) },
                    { new Guid("8fbf0317-92a3-450e-8d02-5133a3c1c8b9"), new Guid("0d30709d-7e7c-408a-b5d5-6c7834eccb6f"), new DateTime(2019, 10, 18, 10, 58, 42, 520, DateTimeKind.Local).AddTicks(6859) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("94c52b57-0241-4678-a74d-089b0403a226"), "PragWebAppLoginProvider", "Token1", "Token1" },
                    { new Guid("8fbf0317-92a3-450e-8d02-5133a3c1c8b9"), "PragWebAppLoginProvider", "Token2", "Token2" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarEvent_CalendarEventType_EventId",
                table: "CalendarEvent",
                column: "EventId",
                principalTable: "CalendarEventType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
