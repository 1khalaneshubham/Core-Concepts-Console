namespace CoreConceptsSuite.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public DateTime JoinDate { get; set; }

    public override string ToString()
        => $"ID: {Id}, Name: {Name}, Dept: {Department}, Salary: ${Salary:N2}, Joined: {JoinDate:yyyy-MM-dd}";
}