using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Weather.Models;
using Weather.Views;

namespace Weather.ViewModels
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