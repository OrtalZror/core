using  שיעור_2.Models;
using  שיעור_2.Interfaces;
using   שיעור_2.Services;


namespace שיעור_2.Utilities
{
public static class Injection
{
    public static void AddTask(this IServiceCollection services)
    {
        services.AddSingleton<TaskInterface,TaskService>();
    }
       public static void AddUser(this IServiceCollection services)
    {
        services.AddSingleton<UserInterface,UserService>();
    }
}
}