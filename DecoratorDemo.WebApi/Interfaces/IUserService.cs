using DecoratorDemo.WebApi.Dto;
using DecoratorDemo.WebApi.Models;

namespace DecoratorDemo.WebApi.Interfaces;

public interface IUserService
{
    Task CreateUser(UserDto dto);

    Task<List<UserModel>> GetUsers();
}
