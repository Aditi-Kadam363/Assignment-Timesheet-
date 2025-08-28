using Microsoft.AspNetCore.Mvc;
using TimeSheetApp.Api.Data;
using TimeSheetApp.Api.Model;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public EmployeeController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
        return Ok("Employee Registered Successfully");
    }


    [HttpPost("login")]
    public IActionResult Login([FromBody] Employee emp)
    {
        var employee = _context.Employees
            .FirstOrDefault(e => e.Email == emp.Email && e.Password == emp.Password);

        if (employee == null) return Unauthorized("Invalid Credentials");
        return Ok(employee);
    }
}
