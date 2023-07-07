namespace DataAccess.Models;

public class Employee: IUser
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public  string personalIdNo { get; set; }
    public string Email { get; set; }

    public string GetBasicInfo()
    {
        var finalStr = Name + ' ' + LastName + 
                       "\nUsername: " + UserName + 
                       "\nPersonal Id Number" + personalIdNo +
                       "\nPassword: " + Password +
                       "\nEmail: " + Email;
        return finalStr;
    }
}