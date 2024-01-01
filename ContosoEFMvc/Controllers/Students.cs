using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ContosoEFMvc.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ContosoEFMvc.Controllers
{
    [Route("[controller]")]
    public class Students : Controller
    {
        private readonly ILogger<Students> _logger;
        private readonly SchoolContext _context;


        public Students(ILogger<Students> logger, SchoolContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            DbInitializer.Initialize(_context);
            var enrollmentDetails = await _context.EnrollmentDetails.ToListAsync();
            var enrollmentDetailsSp = await _context.GetEnrollmentDetails("Carson").ToListAsync();
            return View(await _context.Students.ToListAsync());
        }
    }
}