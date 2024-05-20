using DecoratorDemo.WebApi.Interfaces;
using DecoratorDemo.WebApi.Repository;

namespace DecoratorDemo.WebApi.Models;

public class UserModel : IUser
{
    private static readonly DateTime _insertDate = DateTime.Now;

    public UserModel(string name, string email)
    {
        InsertDate = _insertDate;
        Name = name;
        Email = email;
    }

    public int Id { get; set; }
    public DateTime InsertDate { get; set; }

    public string Name { get; set; }
    public string Email { get; set; }

    public UserModel GenerateId()
    {
        Id = StaticUserRepository.LastIdGenerated + 1;
        return this;
    }
}
