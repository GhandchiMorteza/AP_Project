using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Postal_Management_System.Pages.Employee;

public partial class EmployeePanelPage : Page
{
    public EmployeePanelPage()
    {
        InitializeComponent();
    }

    private void MenuListBoxItem_Click(object sender, MouseButtonEventArgs e)
    {
        var listBoxItem = (ListBoxItem)sender;
        var textBlock = (TextBlock)listBoxItem.Content;
        var selectedItem = textBlock.Text;

        switch (selectedItem)
        {
            case "ثبت نام مشتری":
                EmployeePanelFrame.Navigate(new Uri("/Pages/Employee/RegisterCustomerPage.xaml", UriKind.Relative));
                break;
            case "ثبت سفارش":
                EmployeePanelFrame.Navigate(new Uri("/Pages/Employee/OrderRegistration.xaml", UriKind.Relative));
                break;
            case "گزارش گیری از سفارشات":
                EmployeePanelFrame.Navigate(new Uri("/Pages/Employee/OrdersReporting.xaml", UriKind.Relative));
                break;
            case "نمایش اطلاعات بسته":
                EmployeePanelFrame.Navigate(new Uri("/Pages/Employee/PackageDeliveryEmail.xaml", UriKind.Relative));
                break;
            case " ایمیل تحویل شدن بسته":
                EmployeePanelFrame.Navigate(new Uri("/Pages/Employee/PackageInfo.xaml", UriKind.Relative));
                break;
        }
    }


}