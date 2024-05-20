using DecoratorDemo.WebApi.Interfaces;
using DecoratorDemo.WebApi.Models;

namespace DecoratorDemo.WebApi.Repository;

public static class StaticUserRepository
{
    public static int LastIdGenerated { get; set; } = 0;

    public static IQueryable<UserModel>? Users { get; set; }

    public static void UpdateLastIdGenerated()
    {
        LastIdGenerated = LastIdGenerated + 1;
    }

    internal static void Commit()
    {
        throw new NotImplementedException();
    }

    internal static void CreateRepository()
    {
        Users = new List<UserModel>().AsQueryable();
    }
}
