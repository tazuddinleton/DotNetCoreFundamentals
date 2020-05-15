using Microsoft.EntityFrameworkCore.Migrations;

namespace EnrollmentApp.Persistence.Migrations
{
    public partial class CourseViewAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE OR ALTER VIEW CourseStat
                AS
                SELECT * FROM Courses"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.CourseStat");
        }
    }
}
