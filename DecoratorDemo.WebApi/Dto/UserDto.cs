using DecoratorDemo.WebApi.Interfaces;

namespace DecoratorDemo.WebApi.Dto;

public class UserDto : IUser
{
    public string Name { get; set; }
    public string Email { get; set; }
}
