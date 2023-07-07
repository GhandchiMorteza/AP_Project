namespace DataAccess.Models;

public interface IUser
{
    int Id { get; set; }
    string Name { get; set; }
    string LastName { get; set; }
    string UserName { get; set; }
    string Password { get; set; }

    string GetBasicInfo();
}