using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace B2B_BACKEND.Migrations
{
    public partial class Initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "B2B_Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 15, nullable: false),
                    VendorID = table.Column<string>(maxLength: 15, nullable: false),
                    UserHash = table.Column<string>(nullable: false),
                    Salt = table.Column<string>(nullable: true),
                    LastLogin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2B_Users", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "B2B_Users");
        }
    }
}
