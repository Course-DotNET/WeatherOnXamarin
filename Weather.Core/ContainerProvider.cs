using System;
using Autofac;

namespace Weather.Core
{
    public static class ContainerProvider
    {
        internal static IContainer Container { get; set; }

        public static T Resolve<T>() where T : class => Container.Resolve<T>();

        public static object Resolve(Type type) => Container.Resolve(type);


    }
}