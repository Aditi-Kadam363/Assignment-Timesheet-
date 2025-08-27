namespace TimeSheetApp.Api.Model
{
    public class TimeSheet
    {
        public int TimesheetId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public int HoursWorked { get; set; }
        public string TaskDescription { get; set; } = "";

        public Employee? Employee { get; set; }
    }
}
