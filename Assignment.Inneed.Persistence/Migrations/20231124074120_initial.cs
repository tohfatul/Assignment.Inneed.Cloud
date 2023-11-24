using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment.Inneed.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreated", "DateModified", "RoleName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 24, 2, 41, 20, 570, DateTimeKind.Local).AddTicks(2096), new DateTime(2023, 11, 24, 2, 41, 20, 570, DateTimeKind.Local).AddTicks(2123), "Administrator" },
                    { 2, new DateTime(2023, 11, 24, 2, 41, 20, 570, DateTimeKind.Local).AddTicks(2126), new DateTime(2023, 11, 24, 2, 41, 20, 570, DateTimeKind.Local).AddTicks(2127), "Standard" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateModified", "Email", "FullName", "PasswordHash", "PasswordSalt", "RoleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 24, 2, 41, 20, 570, DateTimeKind.Local).AddTicks(2951), new DateTime(2023, 11, 24, 2, 41, 20, 570, DateTimeKind.Local).AddTicks(2955), "admin@admin.com", "Admin User", new byte[] { 179, 252, 89, 63, 218, 255, 47, 153, 168, 119, 42, 179, 212, 118, 217, 189, 228, 91, 15, 28, 51, 136, 196, 97, 107, 102, 28, 174, 39, 195, 147, 83, 179, 226, 208, 30, 20, 147, 152, 12, 91, 222, 61, 249, 177, 152, 118, 231, 240, 23, 178, 84, 86, 235, 128, 151, 223, 75, 223, 83, 221, 232, 142, 14 }, new byte[] { 178, 139, 165, 58, 177, 48, 92, 67, 68, 81, 172, 186, 197, 206, 71, 92, 245, 80, 64, 180, 58, 236, 141, 51, 237, 109, 12, 10, 214, 197, 162, 169, 9, 53, 69, 83, 216, 150, 0, 71, 150, 132, 174, 122, 26, 55, 119, 193, 154, 101, 134, 109, 92, 174, 235, 143, 171, 197, 63, 5, 66, 230, 24, 243, 81, 166, 10, 14, 192, 127, 92, 240, 87, 237, 15, 206, 1, 154, 65, 191, 153, 11, 39, 159, 175, 28, 43, 137, 151, 245, 229, 19, 135, 162, 99, 174, 174, 188, 232, 226, 0, 215, 120, 119, 88, 127, 227, 145, 246, 38, 111, 118, 139, 44, 230, 233, 137, 98, 152, 28, 72, 126, 141, 70, 43, 104, 41, 160 }, 1 },
                    { 2, new DateTime(2023, 11, 24, 2, 41, 20, 570, DateTimeKind.Local).AddTicks(2964), new DateTime(2023, 11, 24, 2, 41, 20, 570, DateTimeKind.Local).AddTicks(2965), "standard@standard.com", "Standard User", new byte[] { 179, 252, 89, 63, 218, 255, 47, 153, 168, 119, 42, 179, 212, 118, 217, 189, 228, 91, 15, 28, 51, 136, 196, 97, 107, 102, 28, 174, 39, 195, 147, 83, 179, 226, 208, 30, 20, 147, 152, 12, 91, 222, 61, 249, 177, 152, 118, 231, 240, 23, 178, 84, 86, 235, 128, 151, 223, 75, 223, 83, 221, 232, 142, 14 }, new byte[] { 178, 139, 165, 58, 177, 48, 92, 67, 68, 81, 172, 186, 197, 206, 71, 92, 245, 80, 64, 180, 58, 236, 141, 51, 237, 109, 12, 10, 214, 197, 162, 169, 9, 53, 69, 83, 216, 150, 0, 71, 150, 132, 174, 122, 26, 55, 119, 193, 154, 101, 134, 109, 92, 174, 235, 143, 171, 197, 63, 5, 66, 230, 24, 243, 81, 166, 10, 14, 192, 127, 92, 240, 87, 237, 15, 206, 1, 154, 65, 191, 153, 11, 39, 159, 175, 28, 43, 137, 151, 245, 229, 19, 135, 162, 99, 174, 174, 188, 232, 226, 0, 215, 120, 119, 88, 127, 227, 145, 246, 38, 111, 118, 139, 44, 230, 233, 137, 98, 152, 28, 72, 126, 141, 70, 43, 104, 41, 160 }, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
