using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoEFMvc.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ContosoEFMvc.Data
{
    public static class SchoolContextExtensions
    {
        public static IQueryable<EnrollmentDetailSP> GetEnrollmentDetails(this SchoolContext context, string studentName)
        {
            return context.Database.SqlQueryRaw<EnrollmentDetailSP>($"EXECUTE GetEnrollmentDetails @studentName", new SqlParameter("studentName", studentName));
        }
    }
}