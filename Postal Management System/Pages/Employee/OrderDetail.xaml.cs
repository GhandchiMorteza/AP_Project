using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using DataAccess;
using DataAccess.Models;

namespace Postal_Management_System.Pages.Employee;

public partial class OrderDetail : Page
{
    public OrderDetail()
    {
        InitializeComponent();
    }
    
    private void RadioButton_Checked(object sender, RoutedEventArgs e)
    {
    }

    private void PriceBtn_OnClick(object sender, RoutedEventArgs e)
    {
        var valid = Valid();
        if (!valid)
            return;
        
        var price = CalculatePrice();
        MessageBox.Show("هزینه سفارش: " + price + "هزار تومان");
    }

    private bool Valid()
    {
        if (string.IsNullOrWhiteSpace(LocSend.Text) || string.IsNullOrWhiteSpace(LocGive.Text))
        {
            MessageBox.Show("آدرس وارد کنید");
            return false;
        }

        if (string.IsNullOrWhiteSpace(Weight.Text))
        {
            MessageBox.Show("وزن وارد کنید");
            return false;
        }
        if (double.TryParse(Weight.Text, out var number))
        {
            if (!(number > 0))
            {
                MessageBox.Show("وزن صحیح وارد کنید");
                return false;
            }
        }
        else
        {
            MessageBox.Show("وزن صحیح وارد کنید");
            return false;
        }
        
        if (!Regex.IsMatch(PhoneNo.Text, @"^09\d{9}$"))
        {
            MessageBox.Show("شماره تماس صحیح نمی باشد");
            return false;
        }

        return true;
    }

    private double CalculatePrice()
    {
        
        double mul = 1;
        const double basePrice = 10;
        switch (Type.SelectedIndex)
        {
            case 1:
                mul += 0.5;
                break;
            case 2:
                mul += 1;
                break;
        }

        if ((bool) Expensive.IsChecked)
        {
            mul += 1;
        }
        if (Convert.ToDouble(Weight.Text) > 0.5)
        {
            mul += (Convert.ToDouble(Weight.Text) - 0.5) / 0.5 * 0.2;
        }
        if (ExpressPostRadioButton.IsChecked == true)
        {
            mul += 0.5;
        }

        return basePrice * mul;
    }

    private void OrderBtn_OnClick(object sender, RoutedEventArgs e)
    {
        var valid = Valid();
        if (!valid)
            return;
        PackageDataAccess.AddPackage(new Package
        {
            Id = PackageDataAccess.GetNextId(),
            SenderAddress =  LocSend.Text,
            ReceiverAddress = LocGive.Text,
            ContainExpensive = (bool) Expensive.IsChecked,
            PhoneNo = PhoneNo.Text,
            packageType = (Package.PackageType) Enum.Parse(typeof(Package.PackageType), Type.Text),
            postType = (bool) ExpressPostRadioButton.IsChecked ? Package.PostType.Express : Package.PostType.Normal,
            Price = CalculatePrice()
        });
    }
}