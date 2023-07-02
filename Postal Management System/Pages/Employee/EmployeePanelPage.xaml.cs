using System;
using System.Windows;
using System.Windows.Controls;

namespace Postal_Management_System.Pages.Employee;

public partial class EmployeePanelPage : Page
{
    public EmployeePanelPage()
    {
        InitializeComponent();
    }

    private void RegisterCustomerBtn_OnClick(object sender, RoutedEventArgs e)
    {
        EmployeePanelFrame.Navigate(new Uri("/Pages/Employee/RegisterCustomerPage.xaml", UriKind.Relative));
    }
}