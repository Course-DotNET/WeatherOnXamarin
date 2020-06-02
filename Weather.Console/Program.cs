using System;
using System.Threading.Tasks;
using Autofac;
using Weather.Core;
using Weather.Services;

namespace Weather.ConsoleApp
{
    class Program : IUserSettings
    {
        static async Task Main(string[] args)
        {
            ContainerProviderInitializer.RegisterDependencies(builder =>
            {
                builder.RegisterType<UserSettings>().As<IUserSettings>();
            });
            var result = await ContainerProvider.Resolve<OpenWeatherApiService>().GetCurrentWeather("Kharkiv");
            Console.WriteLine($"Temperature in {result.Name} is {result.MainData.Temperature} degree.");
            Console.ReadLine();
        }

         public bool IsMetric { get; } = true;
    }

    public class UserSettings : IUserSettings
    {
        public bool IsMetric { get; } = false;
    }
}
