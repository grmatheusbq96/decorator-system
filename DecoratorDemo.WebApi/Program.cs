using DecoratorDemo.WebApi.Decorators;
using DecoratorDemo.WebApi.Interfaces;
using DecoratorDemo.WebApi.Repository;
using DecoratorDemo.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddKeyedSingleton<IUserService, UserService>("deepest-implementation");
builder.Services.AddKeyedSingleton<IUserService, FirstUserServiceDacorator>("first-layer-decorator");
builder.Services.AddKeyedSingleton<IUserService, SecondUserServiceDecorator>("second-layer-decorator");

builder.Services.AddSingleton<IUserRepository, UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
