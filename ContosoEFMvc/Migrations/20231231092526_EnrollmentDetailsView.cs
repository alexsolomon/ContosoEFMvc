using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoEFMvc.Migrations
{
    /// <inheritdoc />
    public partial class EnrollmentDetailsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW EnrollmentDetails
                                AS
                                select 
                                Student.FirstMidName as StudentName,
                                Course.Title as CourseTitle
                                from 
                                Enrollment
                                inner join Student on Enrollment.StudentID = Student.ID
                                inner join Course on Enrollment.CourseID = Course.CourseID
                                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW EnrollmentDetails");
        }
    }
}
