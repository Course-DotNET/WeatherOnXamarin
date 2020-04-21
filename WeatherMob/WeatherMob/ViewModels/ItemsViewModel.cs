using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using WeatherMob.Models;
using WeatherMob.Services;
using WeatherMob.Views;

namespace WeatherMob.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<string> Cities { get; set; }

        public ItemsViewModel()
        {
            Title = "Cities";
            Cities = new ObservableCollection<string>()
            {
                "Kyiv", "Kharkiv", "New York", "London"
            };

        }
    }
}