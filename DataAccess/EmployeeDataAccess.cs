using DataAccess.Models;

namespace DataAccess;

public class EmployeeDataAccess
{
    public List<Employee> Employees { get; set; } = new List<Employee>();

    public EmployeeDataAccess()
    {
        ReadEmployees();
    }

    private void ReadEmployees()
    {
        var emp1 = new Employee()
        {
            id = 1,
            name = "علی",
            lastName = "حسینی",
            password = "sdfj1523",
            personalIdNo = "40044",
            userName = "jdsfkj"
        };
        
        var emp2 = new Employee()
        {
            id = 2,
            name = "غلامی",
            lastName = "فاطمی",
            password = "kjfj1541",
            personalIdNo = "40172",
            userName = "werew"
        };
        
        Employees.Add(emp1);
        Employees.Add(emp2);
    }

    private void AddEmployee(Employee employee)
    {
        Employees.Add(employee);
    }

    public void RemoveEmployee(int id)
    {
        var temp = Employees.First(x => x.id == id);
        Employees.Remove(temp);
    }

    public void EditEmployee(Employee employee)
    {
        var temp = Employees.First(x => x.id == employee.id);
        var index = Employees.IndexOf(temp);
        Employees[index] = employee;
    }

    public int GetNextId()
    {
        var index = Employees.Any() ? Employees.Max(x => x.id) + 1 : 1;
        return index;
    }
}