using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveApplication.Migrations.Migrations
{
    public partial class LeaveApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessTypeInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessTypeInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveApplicationInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    LeaveTypeInfoId = table.Column<Guid>(nullable: false),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    BonusAmount = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    NoOfDays = table.Column<int>(nullable: false),
                    IsReviewed = table.Column<bool>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveApplicationInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveTypeInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DaysAllowed = table.Column<int>(nullable: false),
                    IsBonusApplicable = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypeInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecallInformations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    LeaveApplicationInfoId = table.Column<Guid>(nullable: false),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    NoOfDays = table.Column<int>(nullable: false),
                    IsReviewed = table.Column<bool>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecallInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccessTypeInfoId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Division = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    Branch = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessTypeInfos");

            migrationBuilder.DropTable(
                name: "LeaveApplicationInfos");

            migrationBuilder.DropTable(
                name: "LeaveTypeInfos");

            migrationBuilder.DropTable(
                name: "RecallInformations");

            migrationBuilder.DropTable(
                name: "UserInfos");
        }
    }
}
