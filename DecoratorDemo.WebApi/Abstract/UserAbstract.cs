using DecoratorDemo.WebApi.Dto;
using DecoratorDemo.WebApi.Interfaces;
using DecoratorDemo.WebApi.Models;

namespace DecoratorDemo.WebApi.Abstract;

public abstract class UserAbstract([FromKeyedServices("deepest-implementation")] IUserService userService) : IUserService
{
    private readonly IUserService _userService = userService;

    public async Task CreateUser(UserDto dto)
    {
        await _userService.CreateUser(dto);
    }

    public Task<List<UserModel>> GetUsers() => _userService.GetUsers();

    public abstract Task<List<UserModel>> GetUser_DecoratorPart(List<UserModel> users);
    public abstract Task CreateUser_DecoratorPart(UserDto dto);
}
