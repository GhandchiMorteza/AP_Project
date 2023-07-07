using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using DataAccess.Models;
using DataAccess;

namespace Postal_Management_System.Pages;

public partial class EmployeeRegisteration : Page
{

    public EmployeeRegisteration()
    {
        InitializeComponent();
    }

    private void EmployeeRegisterBtn_OnClick(object sender, RoutedEventArgs e)
    {
        /*
        if (!Regex.IsMatch(FirstName.Text, @"^[a-zA-Z]{3,32}$"))
        {
            MessageBox.Show("نام باید حداقل 3 حرف و حداکثر 32 حرف باشد و فقط متشکل از حروف باشد و کاراکتر یا عدد نداشته باشد");
            return;
        }
        if (!Regex.IsMatch(LastName.Text, @"^[a-zA-Z]{3,32}$"))
        {
            MessageBox.Show("نام خانوادگی باید حداقل 3 حرف و حداکثر 32 حرف باشد و فقط متشکل از حروف باشد و کاراکتر یا عدد نداشته باشد");
            return;
        }
        if (!Regex.IsMatch(PersonalId.Text, @"^\d{5}$") || PersonalId.Text[2] != '9') 
        {
            MessageBox.Show("کد پرسنلی باید فقط شامل 5 عدد باشد و عدد سوم آن 9 باشد");
            return;
        }
        if (String.IsNullOrWhiteSpace(UserName.Text))
        {
            MessageBox.Show("نام کاربری نمی تواند خالی باشد");
        }
        if (!Regex.IsMatch(Email.Text, @"^[a-zA-Z]{3,32}@[a-zA-Z]{3,32}\.[a-zA-Z]{2,3}$"))
        {
            MessageBox.Show("ایمیل وارد شده، صحیح نمی باشد");
            return;
        }
        if (!Regex.IsMatch(Password.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,32}$"))
        {
            MessageBox.Show("رمز عبور باید بین 8 تا 32 کاراکتر باشد، همچنین باید شامل حداقل یک حرف بزرگ، یک حرف کوچک و یک عدد باشد ");
            return;
        }
        if (Password.Text != PasswordRepeat.Text)
        {
            MessageBox.Show("رمز تکرار شده مطابقت ندارد");
            return;
        }
        */

        var emp = new DataAccess.Models.Employee()
        {
            Id = EmployeeDataAccess.GetNextId(),
            Name = FirstName.Text,
            LastName = LastName.Text,
            UserName = UserName.Text,
            Password = Password.Text,
            personalIdNo = PersonalId.Text
        };
        
        EmployeeDataAccess.AddEmployee(emp);
        NavigationService?.Navigate(new Uri("/Pages/StartLoginPage.xaml", UriKind.Relative));
    }
}