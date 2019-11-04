using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PragWebApp.Migrations
{
    public partial class M11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("06edb851-5bbd-4f0a-9f21-7c412eb71b5d"), new Guid("08cbd66a-24f7-487e-a975-3e7ad817c199") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("06edb851-5bbd-4f0a-9f21-7c412eb71b5d"), new Guid("6743d304-b2f4-440e-928e-628536edf88e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("4b852fd0-5de0-4c5b-9a3a-48627a5dcb7a"), new Guid("6743d304-b2f4-440e-928e-628536edf88e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("d465c52e-f1ea-45c0-a299-eb489e85de08"), new Guid("08cbd66a-24f7-487e-a975-3e7ad817c199") });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("06edb851-5bbd-4f0a-9f21-7c412eb71b5d"), "PragWebAppLoginProvider", "Token2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("d465c52e-f1ea-45c0-a299-eb489e85de08"), "PragWebAppLoginProvider", "Token1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("08cbd66a-24f7-487e-a975-3e7ad817c199"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6743d304-b2f4-440e-928e-628536edf88e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("06edb851-5bbd-4f0a-9f21-7c412eb71b5d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4b852fd0-5de0-4c5b-9a3a-48627a5dcb7a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d465c52e-f1ea-45c0-a299-eb489e85de08"));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Customer",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customer",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customer",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customer",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Customer",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CalendarEventType",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "CalendarEventType",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "Status" },
                values: new object[,]
                {
                    { new Guid("ad86c13b-f076-4386-a019-9d4d7a6ec6b0"), "7f069fce-81c1-4351-a4f1-7563dbaab506", "Administrators role", "Admin", "ADMIN", 1 },
                    { new Guid("0e99e85e-e670-4a47-8aec-382c77239a07"), "bc87c901-93b3-4092-9dbe-ffba4a209ac8", "Stylists role", "Stylist", "STYLIST", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created", "DefaultColor", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("37e7f671-1340-4032-b3d3-4969e467089b"), 0, "2d9db24d-cf82-4644-8484-96f17c8fdb71", new DateTime(2019, 11, 4, 13, 11, 42, 997, DateTimeKind.Local).AddTicks(7438), "lightgreen", "xkalinam@email.cz", true, "Miroslav", "Kalina", false, null, "XKALINAM@EMAIL.CZ", "RESCATORX", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "123456789", true, null, 2, false, "RescatorX" },
                    { new Guid("a26a686c-effe-4341-91f4-acbdf852dde6"), 0, "cb988fdb-e8c7-4118-ad49-0b48cdf56b1a", new DateTime(2019, 11, 4, 13, 11, 42, 999, DateTimeKind.Local).AddTicks(6842), "lightblue", "jiri.pragr@seznam.cz", true, "Jiří", "Prágr", false, null, "JIRI.PRAGR@SEZNAM.CZ", "JPRAGR", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "987654321", true, null, 2, false, "jpragr" },
                    { new Guid("8faa1685-e2a3-4cbd-86fd-e143017f06ad"), 0, "299229ca-d918-478b-9434-f21e51dd36e5", new DateTime(2019, 11, 4, 13, 11, 42, 999, DateTimeKind.Local).AddTicks(7069), "pink", "sandra.nisterova@seznam.cz", true, "Sandra", "Nisterová", false, null, "SANDRA.NISTEROVA@SEZNAM.CZ", "SNISTEROVA", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "666555444", true, null, 2, false, "snisterova" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Added" },
                values: new object[,]
                {
                    { new Guid("37e7f671-1340-4032-b3d3-4969e467089b"), new Guid("ad86c13b-f076-4386-a019-9d4d7a6ec6b0"), new DateTime(2019, 11, 4, 13, 11, 43, 0, DateTimeKind.Local).AddTicks(1924) },
                    { new Guid("a26a686c-effe-4341-91f4-acbdf852dde6"), new Guid("ad86c13b-f076-4386-a019-9d4d7a6ec6b0"), new DateTime(2019, 11, 4, 13, 11, 43, 0, DateTimeKind.Local).AddTicks(3025) },
                    { new Guid("a26a686c-effe-4341-91f4-acbdf852dde6"), new Guid("0e99e85e-e670-4a47-8aec-382c77239a07"), new DateTime(2019, 11, 4, 13, 11, 43, 0, DateTimeKind.Local).AddTicks(3075) },
                    { new Guid("8faa1685-e2a3-4cbd-86fd-e143017f06ad"), new Guid("0e99e85e-e670-4a47-8aec-382c77239a07"), new DateTime(2019, 11, 4, 13, 11, 43, 0, DateTimeKind.Local).AddTicks(3097) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("37e7f671-1340-4032-b3d3-4969e467089b"), "PragWebAppLoginProvider", "Token1", "Token1" },
                    { new Guid("a26a686c-effe-4341-91f4-acbdf852dde6"), "PragWebAppLoginProvider", "Token2", "Token2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("37e7f671-1340-4032-b3d3-4969e467089b"), new Guid("ad86c13b-f076-4386-a019-9d4d7a6ec6b0") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("8faa1685-e2a3-4cbd-86fd-e143017f06ad"), new Guid("0e99e85e-e670-4a47-8aec-382c77239a07") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("a26a686c-effe-4341-91f4-acbdf852dde6"), new Guid("0e99e85e-e670-4a47-8aec-382c77239a07") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("a26a686c-effe-4341-91f4-acbdf852dde6"), new Guid("ad86c13b-f076-4386-a019-9d4d7a6ec6b0") });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("37e7f671-1340-4032-b3d3-4969e467089b"), "PragWebAppLoginProvider", "Token1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserTokens",
                keyColumns: new[] { "UserId", "LoginProvider", "Name" },
                keyValues: new object[] { new Guid("a26a686c-effe-4341-91f4-acbdf852dde6"), "PragWebAppLoginProvider", "Token2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e99e85e-e670-4a47-8aec-382c77239a07"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ad86c13b-f076-4386-a019-9d4d7a6ec6b0"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("37e7f671-1340-4032-b3d3-4969e467089b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8faa1685-e2a3-4cbd-86fd-e143017f06ad"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a26a686c-effe-4341-91f4-acbdf852dde6"));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CalendarEventType",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "CalendarEventType",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "Status" },
                values: new object[,]
                {
                    { new Guid("08cbd66a-24f7-487e-a975-3e7ad817c199"), "1ae5c636-8ba7-46cf-82c4-196553d6ee01", "Administrators role", "Admin", "ADMIN", 1 },
                    { new Guid("6743d304-b2f4-440e-928e-628536edf88e"), "fe9c5b96-6303-4137-8451-24487aa1a773", "Stylists role", "Stylist", "STYLIST", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created", "DefaultColor", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("d465c52e-f1ea-45c0-a299-eb489e85de08"), 0, "9c9c9b80-7db6-4f45-b959-9b5adcb3c8ff", new DateTime(2019, 10, 30, 1, 34, 41, 890, DateTimeKind.Local).AddTicks(7411), "lightgreen", "xkalinam@email.cz", true, "Miroslav", "Kalina", false, null, "XKALINAM@EMAIL.CZ", "RESCATORX", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "123456789", true, null, 2, false, "RescatorX" },
                    { new Guid("06edb851-5bbd-4f0a-9f21-7c412eb71b5d"), 0, "6e31e28a-ae3a-4b53-be3e-c53197f845b4", new DateTime(2019, 10, 30, 1, 34, 41, 894, DateTimeKind.Local).AddTicks(8166), "lightblue", "jiri.pragr@seznam.cz", true, "Jiří", "Prágr", false, null, "JIRI.PRAGR@SEZNAM.CZ", "JPRAGR", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "987654321", true, null, 2, false, "jpragr" },
                    { new Guid("4b852fd0-5de0-4c5b-9a3a-48627a5dcb7a"), 0, "f9281591-f041-47d3-a297-877c7b8745d0", new DateTime(2019, 10, 30, 1, 34, 41, 894, DateTimeKind.Local).AddTicks(8478), "pink", "sandra.nisterova@seznam.cz", true, "Sandra", "Nisterová", false, null, "SANDRA.NISTEROVA@SEZNAM.CZ", "SNISTEROVA", "d82494f05d6917ba02f7aaa29689ccb444bb73f20380876cb05d1f37537b7892", "666555444", true, null, 2, false, "snisterova" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Added" },
                values: new object[,]
                {
                    { new Guid("d465c52e-f1ea-45c0-a299-eb489e85de08"), new Guid("08cbd66a-24f7-487e-a975-3e7ad817c199"), new DateTime(2019, 10, 30, 1, 34, 41, 895, DateTimeKind.Local).AddTicks(5181) },
                    { new Guid("06edb851-5bbd-4f0a-9f21-7c412eb71b5d"), new Guid("08cbd66a-24f7-487e-a975-3e7ad817c199"), new DateTime(2019, 10, 30, 1, 34, 41, 895, DateTimeKind.Local).AddTicks(6756) },
                    { new Guid("06edb851-5bbd-4f0a-9f21-7c412eb71b5d"), new Guid("6743d304-b2f4-440e-928e-628536edf88e"), new DateTime(2019, 10, 30, 1, 34, 41, 895, DateTimeKind.Local).AddTicks(6847) },
                    { new Guid("4b852fd0-5de0-4c5b-9a3a-48627a5dcb7a"), new Guid("6743d304-b2f4-440e-928e-628536edf88e"), new DateTime(2019, 10, 30, 1, 34, 41, 895, DateTimeKind.Local).AddTicks(6887) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("d465c52e-f1ea-45c0-a299-eb489e85de08"), "PragWebAppLoginProvider", "Token1", "Token1" },
                    { new Guid("06edb851-5bbd-4f0a-9f21-7c412eb71b5d"), "PragWebAppLoginProvider", "Token2", "Token2" }
                });
        }
    }
}
