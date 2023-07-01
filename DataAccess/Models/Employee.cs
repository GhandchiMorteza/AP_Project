namespace DataAccess.Models;

public class Employee: IUser
{
    public int id { get; set; }
    public string name { get; set; }
    public string lastName { get; set; }
    public string userName { get; set; }
    public string password { get; set; }
    public  string personalIdNo { get; set; }

    public string GetBasicInfo()
    {
        var finalStr = name + ' ' + lastName + 
                       "\nUsername: " + userName + 
                       "\nPersonal Id Number" + personalIdNo +
                       "\nPassword: " + password;
        return finalStr;
    }
}