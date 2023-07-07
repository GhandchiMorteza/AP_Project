using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using DataAccess;
using DataAccess.Models;

namespace Postal_Management_System;

public partial class StartLoginPage : Page
{
    public ObservableCollection<Employee> Employees = new();
    public ObservableCollection<Customer> Customers = new();

    public StartLoginPage()
    {
        InitializeComponent();
        FillData();
    }

    private void FillData()
    {
        Employees = EmployeeDataAccess.Employees;
        Customers = CustomerDataAccess.Customers;
    }

    private void LoginBtn_OnClick(object sender, RoutedEventArgs e)
    {
        var isEmployee = false;
        var isCustomer = false;

        IUser user;
        foreach (var employee in Employees)
        {
            if (employee.UserName == UserName.Text)
            {
                isEmployee = true;
                if (employee.Password != Password.Text)
                {
                    MessageBox.Show("رمز وارد شده غلط است");
                    return;
                }
                EmployeeDataAccess.CurrentEmployee = employee;
                break;
            }
        }

        if (isEmployee == false)
        {
            foreach (var customer in Customers)
            {
                if (customer.UserName != UserName.Text) continue;
                isCustomer = true;
                if (customer.Password != Password.Text)
                {
                    MessageBox.Show("رمز وارد شده غلط است");
                    return;
                }
                CustomerDataAccess.CurrentCustomer = customer;
                break;
            }
        }

        if (isEmployee)
            NavigationService?.Navigate(new Uri("/Pages/Employee/EmployeePanelPage.xaml", UriKind.Relative));
        else if (isCustomer)
            NavigationService?.Navigate(new Uri("/Pages/Customer/CustomerPanelPage.xaml", UriKind.Relative));
        else
            MessageBox.Show("نام کاربری وارد شده، وجود ندارد");
    }


    private void RegisterEmployeeBtn_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new Uri("/Pages/EmployeeRegisteration.xaml", UriKind.Relative));
    }
}