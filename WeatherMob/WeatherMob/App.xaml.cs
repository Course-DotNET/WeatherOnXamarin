using System;
using Autofac;
using Weather.Core;
using Weather.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Weather.Views;
using MainPage = Weather.Views.MainPage;

namespace Weather
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            ContainerProviderInitializer.RegisterDependencies(builder =>
            {
                builder.RegisterType<UserSettings>().As<IUserSettings>();
            });

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
