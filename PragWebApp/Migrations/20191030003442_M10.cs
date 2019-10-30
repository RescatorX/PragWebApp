using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PragWebApp.Migrations
{
    public partial class M10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
