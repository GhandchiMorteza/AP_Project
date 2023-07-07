using System;
using System.Windows;
using System.Windows.Controls;
using DataAccess;

namespace Postal_Management_System.Pages.Employee;

public partial class OrderRegistration : Page
{
    public OrderRegistration()
    {
        InitializeComponent();
    }

    private void NationalCodeBtn_OnClick(object sender, RoutedEventArgs e)
    {
        var exist = false;
        foreach (var customer in CustomerDataAccess.Customers)
        {
            if (customer.nationalCode == NationalCode.Text)
            {
                CustomerDataAccess.CurrentCustomer = customer;
                exist = true;
                break;
            }
        }

        if (!exist)
        {
            MessageBox.Show("این مشتری ثبت نام نکرده، لطفا اول ثبت نام کنید");
            
            NavigationService?.Navigate(new Uri("/Pages/Employee/RegisterCustomerPage.xaml", UriKind.Relative));
        }
    }
}