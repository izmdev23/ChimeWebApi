using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChimeWebApi.Migrations
{
    /// <inheritdoc />
    public partial class IdentityDb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RefreshToken = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RefreshTokenExpireDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName", "PasswordHash", "RefreshToken", "RefreshTokenExpireDate", "Role", "UserName" },
                values: new object[,]
                {
                    { new Guid("062ea2e0-c625-4d3b-8863-b5bed87244cd"), "Anton Jay", "Cañete", "Adlit", "AQAAAAIAAYagAAAAEMCAqFd1gUqBRssags1TTRQ82pY9RdgqkwFXMMveYGDymbbWjUBA5RoRZZKBQfm1tw==", "", new DateTime(2025, 10, 12, 4, 57, 50, 0, DateTimeKind.Unspecified), "User", "antonjay23" },
                    { new Guid("6fda04f9-18a4-475f-80c4-3863e691cc7b"), "Angel", "Pacaña", "Caballes", "AQAAAAIAAYagAAAAEDOJTHYMo3ZEGpRlyY/ygV8n2gv1zd0sALftHy+bnM9pZe5cdXOwZtijzcLZRZpw8Q==", "", new DateTime(2025, 10, 12, 4, 57, 50, 0, DateTimeKind.Unspecified), "User", "angel26" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
