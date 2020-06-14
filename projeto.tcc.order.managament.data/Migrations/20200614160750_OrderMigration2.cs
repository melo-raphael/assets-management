using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace projeto.tcc.order.managament.data.Migrations
{
    public partial class OrderMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderType_OrderTypeId1",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_OrderTypeId1",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderTypeId1",
                table: "Order");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Order",
                nullable: false,
                defaultValue: new Guid("8a7a86d0-e236-46a8-9e8b-ccbb3d2d7b67"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("0838cf1b-469a-48e0-a162-2f5ccce1649c"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Assets",
                nullable: false,
                defaultValue: new Guid("5b095d01-947c-403f-9bbd-da2a86350ddf"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("428e37f1-249c-474c-a54e-aaec710510ce"));

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderTypeId",
                table: "Order",
                column: "OrderTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderType_OrderTypeId",
                table: "Order",
                column: "OrderTypeId",
                principalTable: "OrderType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderType_OrderTypeId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_OrderTypeId",
                table: "Order");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Order",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("0838cf1b-469a-48e0-a162-2f5ccce1649c"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("8a7a86d0-e236-46a8-9e8b-ccbb3d2d7b67"));

            migrationBuilder.AddColumn<int>(
                name: "OrderTypeId1",
                table: "Order",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Assets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("428e37f1-249c-474c-a54e-aaec710510ce"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("5b095d01-947c-403f-9bbd-da2a86350ddf"));

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderTypeId1",
                table: "Order",
                column: "OrderTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderType_OrderTypeId1",
                table: "Order",
                column: "OrderTypeId1",
                principalTable: "OrderType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
