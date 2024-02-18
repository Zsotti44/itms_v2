using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace itms_v2.Server.Migrations
{
    /// <inheritdoc />
    public partial class Add_WH_and_Product_and_productCategory__ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    ADR = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    Address_line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_line2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_line3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_line4 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Goods_pal = table.Column<int>(type: "int", nullable: false),
                    weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Worktickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequesterId = table.Column<int>(type: "int", nullable: false),
                    request_dateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    start_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    finish_dateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    truckId = table.Column<int>(type: "int", nullable: false),
                    DispatcherId = table.Column<int>(type: "int", nullable: false),
                    FromId = table.Column<int>(type: "int", nullable: false),
                    ToId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PalQty = table.Column<int>(type: "int", nullable: false),
                    GoodsQty = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<bool>(type: "bit", nullable: false),
                    preloading = table.Column<bool>(type: "bit", nullable: false),
                    lot = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worktickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Worktickets_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Worktickets_Users_DispatcherId",
                        column: x => x.DispatcherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Worktickets_Users_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Worktickets_Warehouses_FromId",
                        column: x => x.FromId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Worktickets_Warehouses_ToId",
                        column: x => x.ToId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Worktickets_Workers_truckId",
                        column: x => x.truckId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Worktickets_DispatcherId",
                table: "Worktickets",
                column: "DispatcherId");

            migrationBuilder.CreateIndex(
                name: "IX_Worktickets_FromId",
                table: "Worktickets",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Worktickets_ProductId",
                table: "Worktickets",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Worktickets_RequesterId",
                table: "Worktickets",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Worktickets_ToId",
                table: "Worktickets",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_Worktickets_truckId",
                table: "Worktickets",
                column: "truckId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Worktickets");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "ProductCategorys");
        }
    }
}
