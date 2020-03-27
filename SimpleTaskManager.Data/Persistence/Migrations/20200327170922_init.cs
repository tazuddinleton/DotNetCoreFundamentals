using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleTaskManager.Data.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedById = table.Column<int>(nullable: false),
                    AssignedById = table.Column<int>(nullable: true),
                    AssignedToId = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "AssignedById", "AssignedToId", "CreatedAt", "CreatedById", "Description", "LastUpdated", "Priority", "Status", "Title" },
                values: new object[] { 1, null, null, new DateTime(2020, 3, 27, 23, 9, 21, 806, DateTimeKind.Local).AddTicks(8810), 1, "Description 1", new DateTime(2020, 3, 27, 23, 9, 21, 808, DateTimeKind.Local).AddTicks(64), 2, 1, "Test 1" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "AssignedById", "AssignedToId", "CreatedAt", "CreatedById", "Description", "LastUpdated", "Priority", "Status", "Title" },
                values: new object[] { 2, null, null, new DateTime(2020, 3, 27, 23, 9, 21, 809, DateTimeKind.Local).AddTicks(4552), 1, "Description 2", new DateTime(2020, 3, 27, 23, 9, 21, 809, DateTimeKind.Local).AddTicks(4581), 2, 1, "Test 2" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "AssignedById", "AssignedToId", "CreatedAt", "CreatedById", "Description", "LastUpdated", "Priority", "Status", "Title" },
                values: new object[] { 3, null, null, new DateTime(2020, 3, 27, 23, 9, 21, 809, DateTimeKind.Local).AddTicks(4693), 1, "Description 3", new DateTime(2020, 3, 27, 23, 9, 21, 809, DateTimeKind.Local).AddTicks(4695), 2, 1, "Test 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
