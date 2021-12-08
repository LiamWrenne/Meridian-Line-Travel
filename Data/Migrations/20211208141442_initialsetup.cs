using Microsoft.EntityFrameworkCore.Migrations;

namespace Meridian_Line_Travel.Data.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    PlaneID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlaneIDNum = table.Column<int>(type: "int", nullable: false),
                    SeatingCapacity = table.Column<int>(type: "int", nullable: false),
                    Assignment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AoO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AoD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightIDNum = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaneName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.PlaneID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planes");
        }
    }
}
