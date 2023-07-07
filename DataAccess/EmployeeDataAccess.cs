using System.Collections.ObjectModel;
using DataAccess.Models;

namespace DataAccess;

public static class EmployeeDataAccess
{
    public static ObservableCollection<Employee> Employees { get; set; } = new();
    public static Employee CurrentEmployee = new();
    private static string Path = @"./DBEmployees.csv";


    static EmployeeDataAccess()
    {
        ReadEmployees();
    }

    private static void ReadEmployees()
    {
        using var reader = new StreamReader(Path);
        Employees.Clear();
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(",");

            var emp = new Employee
            {
                Id = Convert.ToInt32(values[0]),
                Name = values[1],
                LastName = values[2],
                UserName = values[3],
                Password = values[4],
                personalIdNo = values[5],
                Email = values[6]
            };
            Employees.Add(emp);
        }
    }

    private static void SaveEmployees()
    {
        using var writer = new StreamWriter(Path);
        foreach (var employee in Employees)
        {
            var id = employee.Id.ToString();
            var name = employee.Name;
            var lastName = employee.LastName;
            var userName = employee.UserName;
            var password = employee.Password;
            var personalIdNo = employee.personalIdNo;
            var email = employee.Email;
            var line = string.Join(",", id, name, lastName, userName, password, personalIdNo, email);
            writer.WriteLine(line);
        }
    }

    public static void AddEmployee(Employee employee)
    {
        Employees.Add(employee);
        SaveEmployees();
    }

    public static void RemoveEmployee(int id)
    {
        var temp = Employees.First(x => x.Id == id);
        Employees.Remove(temp);
        SaveEmployees();
    }

    public static void EditEmployee(Employee employee)
    {
        var temp = Employees.First(x => x.Id == employee.Id);
        var index = Employees.IndexOf(temp);
        Employees[index] = employee;
        SaveEmployees();
    }

    public static int GetNextId()
    {
        var index = Employees.Any() ? Employees.Max(x => x.Id) + 1 : 1;
        return index;
    }
}