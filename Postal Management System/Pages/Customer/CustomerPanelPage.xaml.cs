using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Postal_Management_System.Pages.Customer;

public partial class CustomerPanelPage : Page
{
    public CustomerPanelPage()
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
            case "گزارش گیری از سفارشات":
                CustomerPanelFrame.Navigate(new Uri("/Pages/Customer/CustomerOrdersReporting.xaml", UriKind.Relative));
                break;
            case "نمایش اطلاعات بسته":
                CustomerPanelFrame.Navigate(new Uri("/Pages/Customer/CustomerPackagerInfo.xaml", UriKind.Relative));
                break;
            case "کیف پول":
                CustomerPanelFrame.Navigate(new Uri("/Pages/Customer/Wallet.xaml", UriKind.Relative));
                break;
            case "تغییر نام کاربری و رمز عبور":
                CustomerPanelFrame.Navigate(new Uri("/Pages/Customer/ChangeUserPass.xaml", UriKind.Relative));
                break;
        }
    }
}