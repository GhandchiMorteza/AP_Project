namespace DataAccess.Models;

public class Customer: IUser
{
    public int id { get; set; }
    public string name { get; set; }
    public string lastName { get; set; }
    public string userName { get; set; }
    public string nationalCode { get; set; }
    public string email { get; set; }
    public string phoneNo { get; set; }
    public string password { get; set; }
    
    public string GetBasicInfo()
    {
        var finalStr = name + ' ' + lastName + 
                       "\nUsername: " + userName +
                       "\nNational Code: " + nationalCode +
                       "\nEmail: " + email +
                       "\nPhone Number: " + phoneNo +
                       "\nPassword: " + password;
        return finalStr;
    }
}