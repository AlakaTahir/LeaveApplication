using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveApplication.Migrations.Migrations
{
    public partial class Addedresumptiondatetotoleaveapplicationentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ResumptionDate",
                table: "LeaveApplicationInfos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResumptionDate",
                table: "LeaveApplicationInfos");
        }
    }
}
