using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Weather.Core;
using Weather.Models;
using Weather.Services;
using Xamarin.Forms;

namespace Weather.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public OpenWeatherApiService ApiService => ContainerProvider.Resolve<OpenWeatherApiService>();

        private CurrentWeatherData _currentWeatherData;
        public CurrentWeatherData CurrentWeatherData
        {
            get => this._currentWeatherData;
            set
            {
                this._currentWeatherData = value;
                base.OnPropertyChanged();
            }
        }

        private ThreeHourForecast _threeHourForecast;
        public ThreeHourForecast ThreeHourForecast
        {
            get => this._threeHourForecast;
            set
            {
                this._threeHourForecast = value;
                base.OnPropertyChanged();
            }
        }

        private DailyForecast _dailyForecast;
        public DailyForecast DailyForecast
        {
            get => this._dailyForecast;
            set
            {
                this._dailyForecast = value;
                base.OnPropertyChanged();
            }
        }

        private DailyWeatherData _selecterDailyWeatherData;
        public DailyWeatherData SelectedDailyWeatherData
        {
            get => this._selecterDailyWeatherData;
            set
            {
                this._selecterDailyWeatherData = value;
                base.OnPropertyChanged();

                if (this._selecterDailyWeatherData != null)
                {
                    this.UpdateHourlyData();
                }
            }
        }
        public ObservableCollection<ThreeHourWeatherData> HourlyData { get; set; }

        public string City { get; set; }
        public ItemDetailViewModel(string city = null)
        {
            City = city;
            Task.Run(async () => await LoadData());
        }

        private async Task LoadData()
        {
            IsBusy = true;

            try
            {
                this.CurrentWeatherData = await ApiService.GetCurrentWeather(City);
                this.ThreeHourForecast = await ApiService.GetThreeHourForecast(City);
                this.DailyForecast = await ApiService.GetDailyForecast(City);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }


        private void UpdateHourlyData()
        {
            var firstItem = this.ThreeHourForecast.Items.FirstOrDefault(item => item.CalculationLocalTime.Date == this.SelectedDailyWeatherData.CalculationTime.Date);
            var index = firstItem != null ? this.ThreeHourForecast.Items.IndexOf(firstItem) : 0;
            var items = this.ThreeHourForecast.Items.GetRange(index, 8);
            this.HourlyData = new ObservableCollection<ThreeHourWeatherData>(items);
            base.OnPropertyChanged(nameof(this.HourlyData));
        }
    }
}
