using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hip_Hop_Pizza_and_Wangs.Migrations
{
    public partial class FifthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "OrderTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OrderTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Credit" },
                    { 2, "Debit" },
                    { 3, "Phone" }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Uid" },
                values: new object[] { new DateTime(2024, 4, 18, 19, 42, 45, 252, DateTimeKind.Local).AddTicks(3980), "1" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Uid" },
                values: new object[] { new DateTime(2024, 4, 18, 19, 42, 45, 253, DateTimeKind.Local).AddTicks(9425), "2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderTypes");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Type", "Uid" },
                values: new object[] { new DateTime(2024, 4, 13, 13, 30, 50, 607, DateTimeKind.Local).AddTicks(8261), "Pick up", "" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Type", "Uid" },
                values: new object[] { new DateTime(2024, 4, 13, 13, 30, 50, 609, DateTimeKind.Local).AddTicks(2361), "Delivery", "" });
        }
    }
}
