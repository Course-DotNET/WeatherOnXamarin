using System;
using Autofac;
using Weather.Services;

namespace Weather.Core
{
    public static class ContainerProviderInitializer
    {
        private static ContainerBuilder _builder = new ContainerBuilder();

        private static void Build()
        {
            ContainerProvider.Container?.Dispose();
            ContainerProvider.Container = _builder.Build();
        }

        //Public implementation for ASP.Net
        public static void RegisterDefaultDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<OpenWeatherApiService>();
        }

        public static void RegisterDependencies(Action<ContainerBuilder> registration = null)
        {
            RegisterDefaultDependencies(_builder);
            registration?.Invoke(_builder);
            Build();
        }

    }
}