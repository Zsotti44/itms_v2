using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace itms_v2.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worktickets_Products_ProductId",
                table: "Worktickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Worktickets_Users_DispatcherId",
                table: "Worktickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Worktickets_Users_RequesterId",
                table: "Worktickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Worktickets_Warehouses_FromId",
                table: "Worktickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Worktickets_Warehouses_ToId",
                table: "Worktickets");

            migrationBuilder.RenameColumn(
                name: "ToId",
                table: "Worktickets",
                newName: "toId");

            migrationBuilder.RenameColumn(
                name: "RequesterId",
                table: "Worktickets",
                newName: "requesterId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Worktickets",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "Worktickets",
                newName: "priority");

            migrationBuilder.RenameColumn(
                name: "PalQty",
                table: "Worktickets",
                newName: "palQty");

            migrationBuilder.RenameColumn(
                name: "GoodsQty",
                table: "Worktickets",
                newName: "goodsQty");

            migrationBuilder.RenameColumn(
                name: "FromId",
                table: "Worktickets",
                newName: "fromId");

            migrationBuilder.RenameColumn(
                name: "DispatcherId",
                table: "Worktickets",
                newName: "dispatcherId");

            migrationBuilder.RenameIndex(
                name: "IX_Worktickets_ToId",
                table: "Worktickets",
                newName: "IX_Worktickets_toId");

            migrationBuilder.RenameIndex(
                name: "IX_Worktickets_RequesterId",
                table: "Worktickets",
                newName: "IX_Worktickets_requesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Worktickets_ProductId",
                table: "Worktickets",
                newName: "IX_Worktickets_productId");

            migrationBuilder.RenameIndex(
                name: "IX_Worktickets_FromId",
                table: "Worktickets",
                newName: "IX_Worktickets_fromId");

            migrationBuilder.RenameIndex(
                name: "IX_Worktickets_DispatcherId",
                table: "Worktickets",
                newName: "IX_Worktickets_dispatcherId");

            migrationBuilder.RenameColumn(
                name: "weight",
                table: "Products",
                newName: "Weight");

            migrationBuilder.AddColumn<DateTime>(
                name: "Last_modify_date",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Last_modify_userId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Registered_date",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Registrator_userId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Last_modify_userId",
                table: "Products",
                column: "Last_modify_userId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Registrator_userId",
                table: "Products",
                column: "Registrator_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_Last_modify_userId",
                table: "Products",
                column: "Last_modify_userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_Registrator_userId",
                table: "Products",
                column: "Registrator_userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Worktickets_Products_productId",
                table: "Worktickets",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Worktickets_Users_dispatcherId",
                table: "Worktickets",
                column: "dispatcherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Worktickets_Users_requesterId",
                table: "Worktickets",
                column: "requesterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Worktickets_Warehouses_fromId",
                table: "Worktickets",
                column: "fromId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Worktickets_Warehouses_toId",
                table: "Worktickets",
                column: "toId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_Last_modify_userId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_Registrator_userId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Worktickets_Products_productId",
                table: "Worktickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Worktickets_Users_dispatcherId",
                table: "Worktickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Worktickets_Users_requesterId",
                table: "Worktickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Worktickets_Warehouses_fromId",
                table: "Worktickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Worktickets_Warehouses_toId",
                table: "Worktickets");

            migrationBuilder.DropIndex(
                name: "IX_Products_Last_modify_userId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Registrator_userId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Last_modify_date",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Last_modify_userId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Registered_date",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Registrator_userId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "toId",
                table: "Worktickets",
                newName: "ToId");

            migrationBuilder.RenameColumn(
                name: "requesterId",
                table: "Worktickets",
                newName: "RequesterId");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Worktickets",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "priority",
                table: "Worktickets",
                newName: "Priority");

            migrationBuilder.RenameColumn(
                name: "palQty",
                table: "Worktickets",
                newName: "PalQty");

            migrationBuilder.RenameColumn(
                name: "goodsQty",
                table: "Worktickets",
                newName: "GoodsQty");

            migrationBuilder.RenameColumn(
                name: "fromId",
                table: "Worktickets",
                newName: "FromId");

            migrationBuilder.RenameColumn(
                name: "dispatcherId",
                table: "Worktickets",
                newName: "DispatcherId");

            migrationBuilder.RenameIndex(
                name: "IX_Worktickets_toId",
                table: "Worktickets",
                newName: "IX_Worktickets_ToId");

            migrationBuilder.RenameIndex(
                name: "IX_Worktickets_requesterId",
                table: "Worktickets",
                newName: "IX_Worktickets_RequesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Worktickets_productId",
                table: "Worktickets",
                newName: "IX_Worktickets_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Worktickets_fromId",
                table: "Worktickets",
                newName: "IX_Worktickets_FromId");

            migrationBuilder.RenameIndex(
                name: "IX_Worktickets_dispatcherId",
                table: "Worktickets",
                newName: "IX_Worktickets_DispatcherId");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Products",
                newName: "weight");

            migrationBuilder.AddForeignKey(
                name: "FK_Worktickets_Products_ProductId",
                table: "Worktickets",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Worktickets_Users_DispatcherId",
                table: "Worktickets",
                column: "DispatcherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Worktickets_Users_RequesterId",
                table: "Worktickets",
                column: "RequesterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Worktickets_Warehouses_FromId",
                table: "Worktickets",
                column: "FromId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Worktickets_Warehouses_ToId",
                table: "Worktickets",
                column: "ToId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
