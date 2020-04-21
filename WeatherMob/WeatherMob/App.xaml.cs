using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeatherMob.Services;
using WeatherMob.Views;

namespace WeatherMob
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

                DependencyService.Register<OpenWeatherApiService>();
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
