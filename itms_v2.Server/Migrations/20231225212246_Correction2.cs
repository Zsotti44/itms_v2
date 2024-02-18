using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace itms_v2.Server.Migrations
{
    /// <inheritdoc />
    public partial class Correction2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_GetTrailerDto_trailerId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_GetTruckDriverDto_driverId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_GetTruckDto_truckId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "GetTrailerDto");

            migrationBuilder.DropTable(
                name: "GetTruckDriverDto");

            migrationBuilder.DropTable(
                name: "GetTruckDto");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Trailers_trailerId",
                table: "Workers",
                column: "trailerId",
                principalTable: "Trailers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_TruckDrivers_driverId",
                table: "Workers",
                column: "driverId",
                principalTable: "TruckDrivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Trucks_truckId",
                table: "Workers",
                column: "truckId",
                principalTable: "Trucks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Trailers_trailerId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_TruckDrivers_driverId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Trucks_truckId",
                table: "Workers");

            migrationBuilder.CreateTable(
                name: "GetTrailerDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADR = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Goods = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Loaded = table.Column<bool>(type: "bit", nullable: false),
                    ParkigLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Standby = table.Column<bool>(type: "bit", nullable: false),
                    Traffic = table.Column<bool>(type: "bit", nullable: false),
                    owner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetTrailerDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GetTruckDriverDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADR = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetTruckDriverDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GetTruckDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADR = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Standalone = table.Column<bool>(type: "bit", nullable: false),
                    Traffic = table.Column<bool>(type: "bit", nullable: false),
                    owner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetTruckDto", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_GetTrailerDto_trailerId",
                table: "Workers",
                column: "trailerId",
                principalTable: "GetTrailerDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_GetTruckDriverDto_driverId",
                table: "Workers",
                column: "driverId",
                principalTable: "GetTruckDriverDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_GetTruckDto_truckId",
                table: "Workers",
                column: "truckId",
                principalTable: "GetTruckDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
