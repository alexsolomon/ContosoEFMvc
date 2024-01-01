using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoEFMvc.Migrations
{
    /// <inheritdoc />
    public partial class GetEnrollmentDetailsSP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE Procedure GetEnrollmentDetails
                                @studentName varchar(50)
                                AS
                                select 
                                Student.FirstMidName as StudentName,
                                Course.Title as CourseTitle
                                from 
                                Enrollment
                                inner join Student on Enrollment.StudentID = Student.ID
                                inner join Course on Enrollment.CourseID = Course.CourseID
                                where Student.FirstMidName = @studentName
                                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop procedure GetEnrollmentDetails");
        }
    }
}
