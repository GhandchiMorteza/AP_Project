using DataAccess.Models;

namespace DataAccess;

public class CustomerDataAccess
{
    public List<Customer> Customers { get; set; } = new List<Customer>();

    public CustomerDataAccess()
    {
        ReadCustomers();
    }

    private void ReadCustomers()
    {
        var customer1 = new Customer()
        {
            id = 1,
            name = "علی",
            lastName = "حسینی",
            password = "sdfj1523",
            nationalCode = "0036984572",
            email = "alihos@gmail.com",
            phoneNo = "09125654856",
            userName = "jdsfkj"
        };
        
        var customer2 = new Customer()
        {
            id = 2,
            name = "غلامی",
            lastName = "فاطمی",
            password = "kjfj1541",
            nationalCode = "0025754572",
            email = "gholamfat@gmail.com",
            phoneNo = "09195474856",
            userName = "werew"
        };
        
        Customers.Add(customer1);
        Customers.Add(customer2);
    }

    private void AddCustomer(Customer customer)
    {
        Customers.Add(customer);
    }

    public void RemoveCustomer(int id)
    {
        var temp = Customers.First(x => x.id == id);
        Customers.Remove(temp);
    }

    public void EditCustomer(Customer customer)
    {
        var temp = Customers.First(x => x.id == customer.id);
        var index = Customers.IndexOf(temp);
        Customers[index] = customer;
    }

    public int GetNextId()
    {
        var index = Customers.Any() ? Customers.Max(x => x.id) + 1 : 1;
        return index;
    }
}