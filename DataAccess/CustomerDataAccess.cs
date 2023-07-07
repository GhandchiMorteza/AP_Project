using System.Collections.ObjectModel;
using DataAccess.Models;

namespace DataAccess;

public static class CustomerDataAccess
{
    public static ObservableCollection<Customer> Customers { get; set; } = new();
    public static Customer CurrentCustomer = new();
    private static string Path = @"./DBECustomers.csv";

    static CustomerDataAccess()
    {
        ReadCustomers();
    }

    private static void ReadCustomers()
    {
        using var reader = new StreamReader(Path);
        Customers.Clear();
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(",");

            var customer = new Customer
            {
                Id = Convert.ToInt32(values[0]),
                Name = values[1],
                LastName = values[2],
                UserName = values[3],
                nationalCode = values[4],
                Email = values[5],
                PhoneNo = values[6],
                Password = values[7]
            };
            Customers.Add(customer);
        }
    }

    private static void SaveCustomers()
    {
        using var writer = new StreamWriter(Path);
        foreach (var customer in Customers)
        {
            var id = customer.Id.ToString();
            var name = customer.Name;
            var lastName = customer.LastName;
            var userName = customer.UserName;
            var nationalCode = customer.nationalCode;
            var email = customer.Email;
            var phoneNo = customer.PhoneNo;
            var password = customer.Password;
            var line = string.Join(",", id, name, lastName, userName, nationalCode, email, phoneNo,password);
            writer.WriteLine(line);
        }

    }

    public static void AddCustomer(Customer customer)
    {
        Customers.Add(customer);
        SaveCustomers();
    }

    public static void RemoveCustomer(int id)
    {
        var temp = Customers.First(x => x.Id == id);
        Customers.Remove(temp);
        SaveCustomers();    }

    public static void EditCustomer(Customer customer)
    {
        var temp = Customers.First(x => x.Id == customer.Id);
        var index = Customers.IndexOf(temp);
        Customers[index] = customer;
        SaveCustomers();
    }

    public static int GetNextId()
    {
        var index = Customers.Any() ? Customers.Max(x => x.Id) + 1 : 1;
        return index;
    }
}