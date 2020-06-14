using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace projeto.tcc.order.managament.data.Migrations
{
    public partial class OrderMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AssetsSegment",
                newName: "Type");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AssetsSegment",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "AssetsSegment",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Assets",
                nullable: false,
                defaultValue: new Guid("428e37f1-249c-474c-a54e-aaec710510ce"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("ee03296a-ab33-4bbe-89b3-54b1fe1353cc"));

            migrationBuilder.CreateTable(
                name: "OrderActive",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ActiveAmount = table.Column<int>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderActive", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Type = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValue: new Guid("0838cf1b-469a-48e0-a162-2f5ccce1649c")),
                    AssetId = table.Column<Guid>(nullable: false),
                    OrderTypeId1 = table.Column<int>(nullable: false),
                    OrderActiveId = table.Column<Guid>(nullable: true),
                    AssetsId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    OrderTypeId = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Assets_AssetsId",
                        column: x => x.AssetsId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_OrderActive_OrderActiveId",
                        column: x => x.OrderActiveId,
                        principalTable: "OrderActive",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_OrderType_OrderTypeId1",
                        column: x => x.OrderTypeId1,
                        principalTable: "OrderType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_AssetsId",
                table: "Order",
                column: "AssetsId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderActiveId",
                table: "Order",
                column: "OrderActiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderTypeId1",
                table: "Order",
                column: "OrderTypeId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderActive");

            migrationBuilder.DropTable(
                name: "OrderType");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "AssetsSegment",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AssetsSegment",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 1)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AssetsSegment",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Assets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("ee03296a-ab33-4bbe-89b3-54b1fe1353cc"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("428e37f1-249c-474c-a54e-aaec710510ce"));
        }
    }
}
