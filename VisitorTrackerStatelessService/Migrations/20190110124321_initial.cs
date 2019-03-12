using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VisitorTrackerStatelessService.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    VisitorName = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    From = table.Column<string>(nullable: true),
                    IdNumber = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Purpose = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    VisitorImage = table.Column<string>(nullable: true),
                    VisitTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visitors");
        }
    }
}
