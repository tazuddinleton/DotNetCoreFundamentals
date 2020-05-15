using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace EnrollmentApp.Persistence.Migrations
{
    public partial class CourseViewAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = File.ReadAllText("G:\\DotNetCoreFundamentals\\DotNetCoreFundamentals\\" +
                "EnrollmentApp\\EntityFrameworkFeatures\\ViewStoredProceduresRawSql\\CourseView.sql");
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.CourseStat");
        }
    }
}
