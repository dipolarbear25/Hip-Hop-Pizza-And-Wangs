using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hip_Hop_Pizza_and_Wangs.Migrations
{
    public partial class eighthcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "PhoneNum" },
                values: new object[] { new DateTime(2024, 4, 19, 19, 40, 5, 315, DateTimeKind.Local).AddTicks(2921), "931-999-0000" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "PhoneNum" },
                values: new object[] { new DateTime(2024, 4, 19, 19, 40, 5, 316, DateTimeKind.Local).AddTicks(7032), "931-999-0000" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
