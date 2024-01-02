using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoEFMvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ContosoEFMVC.Test
{
    public class TestFixture
    {
        public TestFixture()
        {
            var services = new ServiceCollection();

            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.test.json", false)
            .Build();

            services.AddDbContext<SchoolContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SchoolConnection")));

            services.AddLogging(builder =>
            {
                builder.AddConsole();
            });

            ServiceProvider = services.BuildServiceProvider();
        }
        public ServiceProvider ServiceProvider { get; private set; }
    }
}