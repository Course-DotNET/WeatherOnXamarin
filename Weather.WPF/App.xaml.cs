using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using Weather.Core;
using Weather.Services;
using Weather.WPF.ViewModels;

namespace Weather.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ContainerProviderInitializer.RegisterDependencies(builder =>
            {

                builder.RegisterType<UserSettings>().As<IUserSettings>();
                builder.RegisterType<MainViewModel>();
            });
        }
    }
}
