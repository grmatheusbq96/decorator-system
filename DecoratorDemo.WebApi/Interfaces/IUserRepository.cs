using DecoratorDemo.WebApi.Dto;
using DecoratorDemo.WebApi.Models;

namespace DecoratorDemo.WebApi.Interfaces;

public interface IUserRepository
{
    public Task<IQueryable<UserModel>> GetAll();

    UserModel CreateUser(UserDto dto);
}
