using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PragWebApp.Migrations
{
    public partial class M12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
