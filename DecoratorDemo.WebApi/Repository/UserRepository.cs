using DecoratorDemo.WebApi.Dto;
using DecoratorDemo.WebApi.Interfaces;
using DecoratorDemo.WebApi.Models;

namespace DecoratorDemo.WebApi.Repository;

public class UserRepository : IUserRepository
{
    public async Task<IQueryable<UserModel>> GetAll()
    {
        if (StaticUserRepository.Users == null)
            StaticUserRepository.CreateRepository();

        return await Task.FromResult(StaticUserRepository.Users!);
    }

    public UserModel CreateUser(UserDto dto)
    {
        UserModel userToCreate = new(dto.Name, dto.Email);

        if (StaticUserRepository.Users == null)
            StaticUserRepository.CreateRepository();

        userToCreate.GenerateId();
        
        var userList = StaticUserRepository.Users!.ToList();
        userList.Add(userToCreate);

        StaticUserRepository.Users = userList.AsQueryable();
        StaticUserRepository.UpdateLastIdGenerated();
        //StaticUserRepository.Commit();

        return userToCreate;
    }
}
