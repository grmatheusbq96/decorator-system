using DecoratorDemo.WebApi.Abstract;
using DecoratorDemo.WebApi.Dto;
using DecoratorDemo.WebApi.Interfaces;
using DecoratorDemo.WebApi.Models;

namespace DecoratorDemo.WebApi.Decorators;

public class FirstUserServiceDacorator([FromKeyedServices("deepest-implementation")] IUserService userService) : UserAbstract(userService), IUserService
{
    public async Task CreateUser(UserDto dto)
    {
        await CreateUser_DecoratorPart(dto);
        await base.CreateUser(dto);
    }

    public override async Task CreateUser_DecoratorPart(UserDto dto)
    {
        Console.WriteLine("First layer did something with the current creating object, validation, cleanup, mapping...");
    }

    public async Task<List<UserModel>> GetUsers()
    {
        var retorno = await base.GetUsers();
        await GetUser_DecoratorPart(retorno);

        return retorno;
    }

    public override Task<List<UserModel>> GetUser_DecoratorPart(List<UserModel> users)
    {
        Console.WriteLine("First layer did something with the current object, validation, cleanup, mapping...");
        return Task.FromResult(users);
    }
}
