using System;
using System.Windows;
using System.Windows.Controls;

namespace Postal_Management_System;

public partial class StartLoginPage : Page
{
    public StartLoginPage()
    {
        InitializeComponent();
    }

    private void LoginBtn_OnClick(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new Uri("/Pages/Employee/EmployeePanelPage.xaml", UriKind.Relative));
    }

    private void RegisterEmployeeBtn_OnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}