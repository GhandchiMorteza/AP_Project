using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using DataAccess;
using DataAccess.Models;
using System.Net;
using System.Net.Mail;

    
namespace Postal_Management_System.Pages.Employee;

public partial class RegisterCustomerPage : Page
{
    public RegisterCustomerPage()
    {
        InitializeComponent();
    }

    private void CustomerRegisterBtn_OnClick(object sender, RoutedEventArgs e)
    {
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
        if (!Regex.IsMatch(NationalCode.Text, @"^00\d{8}$"))
        {
            MessageBox.Show("کدملی وارد شده صحیح نمی باشد");
            return;
        }
        if (!Regex.IsMatch(Email.Text, @"^[a-zA-Z]{3,32}@[a-zA-Z]{3,32}\.[a-zA-Z]{2,3}$"))
        {
            MessageBox.Show("ایمیل وارد شده، صحیح نمی باشد");
            return;
        }
        if (!Regex.IsMatch(PhoneNo.Text, @"^09\d{9}$"))
        {
            MessageBox.Show("شماره تماس صحیح نمی باشد");
            return;
        }
        
        var userName = GenerateUsername();
        var password = GeneratePassword();
        
        var customer = new DataAccess.Models.Customer()
        {
            Id = CustomerDataAccess.GetNextId(),
            Name = FirstName.Text,
            LastName = LastName.Text,
            UserName = userName,
            Password = password,
            nationalCode = NationalCode.Text,
            PhoneNo = PhoneNo.Text,
            Email = Email.Text
        };
        
        CustomerDataAccess.AddCustomer(customer);
        MessageBox.Show("ثبت نام با موقیت انجام شد\n" + "نام کاربری: \n" + userName + "\n پسورد: \n" + password);


        // Sender's email address and password
        string senderEmail = "projectap85@gmail.com";
        string senderPassword = "Zxc@159753";

        // Recipient's email address
        string recipientEmail = Email.Text;

        // Create a new MailMessage
        MailMessage mail = new MailMessage(senderEmail, recipientEmail);

        // Set the subject and body of the email
        mail.Subject = "رمز و نام کاربری سامانه پست";
        mail.Body = "نام کاربری: \n" + userName + "\n پسورد: \n" + password;

        // Create a new SmtpClient and set its properties
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.EnableSsl = true;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

        try
        {
            smtpClient.Send(mail);
            MessageBox.Show("رمز و نام کاربری به ایمیل شما با موفقیت ارسال شد");
        }
        catch (Exception ex)
        {
            MessageBox.Show("موفق به ارسال رمز و نام کاربری به ایمیل شما نشدیم، علتش: \n" + ex.Message);
        }
        
        mail.Dispose();
        smtpClient.Dispose();
    }

    private static string GenerateUsername()
    {
        var random = new Random();
        var username = "";
    
        while (CustomerDataAccess.Customers.Any(c => c.UserName == username))
        {
            var randomNumber = random.Next(0, 10000);
            username = "user" + randomNumber;
        }
    
        return username;
    }

    private static string GeneratePassword()
    {
        var random = new Random();
        var password = "";
        
        for (var i = 0; i < 8; i++)
        {
            var digit = random.Next(0, 10);
            password += digit.ToString();
        }
        
        return password;
    }
}