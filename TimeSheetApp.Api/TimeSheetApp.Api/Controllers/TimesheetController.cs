using Microsoft.AspNetCore.Mvc;
using TimeSheetApp.Api.Data;
using TimeSheetApp.Api.Model;

namespace TimeSheetApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimesheetController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TimesheetController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetTimesheets(int employeeId)
        {
            var sheets = _context.Timesheets.Where(t => t.EmployeeId == employeeId).ToList();
            return Ok(sheets);
        }

        [HttpPost]
        public IActionResult AddTimesheet([FromBody] TimeSheet sheet)
        {
            if (sheet == null) return BadRequest("Invalid timesheet");

            _context.Timesheets.Add(sheet);
            _context.SaveChanges();
            return Ok(sheet); 
        }


        [HttpPut("{id}")]
        public IActionResult UpdateTimesheet(int id, TimeSheet sheet)
        {
            var existing = _context.Timesheets.Find(id);
            if (existing == null) return NotFound();

            existing.Date = sheet.Date;
            existing.HoursWorked = sheet.HoursWorked;
            existing.TaskDescription = sheet.TaskDescription;
            _context.SaveChanges();
            return Ok("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTimesheet(int id)
        {
            var sheet = _context.Timesheets.Find(id);
            if (sheet == null) return NotFound();

            _context.Timesheets.Remove(sheet);
            _context.SaveChanges();
            return Ok("Deleted Successfully");
        }
    }
}
