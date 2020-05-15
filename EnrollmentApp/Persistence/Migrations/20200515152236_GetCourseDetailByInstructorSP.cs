using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace EnrollmentApp.Persistence.Migrations
{
    public partial class GetCourseDetailByInstructorSP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = File.ReadAllText("G:\\DotNetCoreFundamentals\\DotNetCoreFundamentals\\EnrollmentApp\\" +
                "EntityFrameworkFeatures\\ViewStoredProceduresRawSql\\GetCourseDetailByInstructor.sql");
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE GetCourseByInstructor");
        }
    }
}
