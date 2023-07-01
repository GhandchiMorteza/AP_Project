namespace DataAccess.Models;

public interface IUser
{
    int id { get; set; }
    string name { get; set; }
    string lastName { get; set; }
    string userName { get; set; }
    string password { get; set; }

    string GetBasicInfo();
}