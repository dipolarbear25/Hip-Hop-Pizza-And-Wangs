using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hip_Hop_Pizza_and_Wangs.Migrations
{
    public partial class sixthcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Uid" },
                values: new object[] { new DateTime(2024, 4, 19, 16, 45, 40, 235, DateTimeKind.Local).AddTicks(5723), "zN5lhMboI3Sv4UwtErkrlHlvPfn2" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 19, 16, 45, 40, 236, DateTimeKind.Local).AddTicks(8924));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                column: "CreatedOn",
                value: new DateTime(2024, 4, 18, 19, 42, 45, 253, DateTimeKind.Local).AddTicks(9425));
        }
    }
}
