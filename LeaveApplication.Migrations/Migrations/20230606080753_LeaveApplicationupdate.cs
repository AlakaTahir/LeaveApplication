using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveApplication.Migrations.Migrations
{
    public partial class LeaveApplicationupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "LeaveApplicationInfos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "LeaveApplicationInfos");
        }
    }
}
