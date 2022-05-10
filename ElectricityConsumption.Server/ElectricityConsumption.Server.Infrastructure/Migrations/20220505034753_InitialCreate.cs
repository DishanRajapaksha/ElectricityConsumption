using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectricityConsumption.Server.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeterReadings",
                columns: table => new
                {
                    Time = table.Column<string>(type: "TEXT", nullable: false),
                    MeterUsage = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterReadings", x => x.Time);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeterReadings");
        }
    }
}
