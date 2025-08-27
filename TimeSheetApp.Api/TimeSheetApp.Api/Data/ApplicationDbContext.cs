using Microsoft.EntityFrameworkCore;
using TimeSheetApp.Api.Model;

namespace TimeSheetApp.Api.Data
{
   
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

            public DbSet<Employee> Employees { get; set; }
            public DbSet<TimeSheet> Timesheets { get; set; }
        }
    
}
