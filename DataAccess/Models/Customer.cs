namespace DataAccess.Models;

public class Customer: IUser
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string nationalCode { get; set; }
    public string Email { get; set; }
    public string PhoneNo { get; set; }
    public string Password { get; set; }
    
    public string GetBasicInfo()
    {
        var finalStr = Name + ' ' + LastName + 
                       "\nUsername: " + UserName +
                       "\nNational Code: " + nationalCode +
                       "\nEmail: " + Email +
                       "\nPhone Number: " + PhoneNo +
                       "\nPassword: " + Password;
        return finalStr;
    }
}