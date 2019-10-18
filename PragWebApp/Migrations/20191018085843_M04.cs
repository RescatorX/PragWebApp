using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PragWebApp.Migrations
{
    public partial class M04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CalendarEvent",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvent_CreatedById",
                table: "CalendarEvent",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarEvent_AspNetUsers_CreatedById",
                table: "CalendarEvent",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarEvent_AspNetUsers_CreatedById",
                table: "CalendarEvent");

            migrationBuilder.DropIndex(
                name: "IX_CalendarEvent_CreatedById",
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

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CalendarEvent");

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
    }
}
