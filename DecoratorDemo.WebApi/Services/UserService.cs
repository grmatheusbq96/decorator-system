using DecoratorDemo.WebApi.Dto;
using DecoratorDemo.WebApi.Interfaces;
using DecoratorDemo.WebApi.Models;

namespace DecoratorDemo.WebApi.Services;

public class UserService(IUserRepository repo) : IUserService
{
    private readonly IUserRepository _repo = repo;

    public async Task CreateUser(UserDto dto)
    {
        _repo.CreateUser(dto);
    }

    public async Task<List<UserModel>> GetUsers()
    {
        var retorno = await _repo.GetAll();

        return retorno.ToList();
    }
}
