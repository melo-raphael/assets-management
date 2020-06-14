using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace projeto.tcc.order.managament.data.Migrations
{
    public partial class OrderMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Assets_AssetsId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_AssetsId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "AssetsId",
                table: "Order");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Order",
                nullable: false,
                defaultValue: new Guid("e0645829-6560-4e0a-9612-31481197f553"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("8a7a86d0-e236-46a8-9e8b-ccbb3d2d7b67"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Assets",
                nullable: false,
                defaultValue: new Guid("9f905251-9a5e-4b29-9ea9-49a85eee4cbe"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("5b095d01-947c-403f-9bbd-da2a86350ddf"));

            migrationBuilder.CreateIndex(
                name: "IX_Order_AssetId",
                table: "Order",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Assets_AssetId",
                table: "Order",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Assets_AssetId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_AssetId",
                table: "Order");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Order",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("8a7a86d0-e236-46a8-9e8b-ccbb3d2d7b67"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("e0645829-6560-4e0a-9612-31481197f553"));

            migrationBuilder.AddColumn<Guid>(
                name: "AssetsId",
                table: "Order",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Assets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("5b095d01-947c-403f-9bbd-da2a86350ddf"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("9f905251-9a5e-4b29-9ea9-49a85eee4cbe"));

            migrationBuilder.CreateIndex(
                name: "IX_Order_AssetsId",
                table: "Order",
                column: "AssetsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Assets_AssetsId",
                table: "Order",
                column: "AssetsId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
