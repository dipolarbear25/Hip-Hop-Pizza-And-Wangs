using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hip_Hop_Pizza_and_Wangs.Migrations
{
    public partial class seventhcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNum",
                table: "Orders",
                type: "text",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "PhoneNum" },
                values: new object[] { new DateTime(2024, 4, 19, 19, 38, 35, 585, DateTimeKind.Local).AddTicks(81), "9319990000" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "PhoneNum" },
                values: new object[] { new DateTime(2024, 4, 19, 19, 38, 35, 586, DateTimeKind.Local).AddTicks(3710), "9319990000" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PhoneNum",
                table: "Orders",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "PhoneNum" },
                values: new object[] { new DateTime(2024, 4, 19, 16, 45, 40, 235, DateTimeKind.Local).AddTicks(5723), 9319990000L });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "PhoneNum" },
                values: new object[] { new DateTime(2024, 4, 19, 16, 45, 40, 236, DateTimeKind.Local).AddTicks(8924), 9319990000L });
        }
    }
}
