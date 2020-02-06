using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore.WebApi.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AssignedTo = table.Column<Guid>(nullable: false),
                    PlannedStartDate = table.Column<DateTime>(nullable: false),
                    PlannedEndDate = table.Column<DateTime>(nullable: false),
                    ActualStartDate = table.Column<DateTime>(nullable: true),
                    ActualEndDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Owner = table.Column<Guid>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
