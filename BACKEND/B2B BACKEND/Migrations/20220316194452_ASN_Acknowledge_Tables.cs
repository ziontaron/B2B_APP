using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace B2B_BACKEND.Migrations
{
    public partial class ASN_Acknowledge_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "B2B_ASN",
                columns: table => new
                {
                    ASNID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rel_AcknowledgeID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    VendorID = table.Column<string>(maxLength: 15, nullable: false),
                    Carrier = table.Column<string>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    PackingSlip = table.Column<string>(nullable: false),
                    Lot = table.Column<string>(nullable: false),
                    TrakingNo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2B_ASN", x => x.ASNID);
                });

            migrationBuilder.CreateTable(
                name: "B2B_Rel_Acknowledge",
                columns: table => new
                {
                    Rel_AcknowledgeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    FSPOLineKey = table.Column<int>(nullable: false),
                    VendorID = table.Column<string>(maxLength: 15, nullable: false),
                    Acknowledge = table.Column<string>(nullable: false),
                    AcknowledgeDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2B_Rel_Acknowledge", x => x.Rel_AcknowledgeID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "B2B_ASN");

            migrationBuilder.DropTable(
                name: "B2B_Rel_Acknowledge");
        }
    }
}
