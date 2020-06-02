using System.ComponentModel;
using System.Runtime.CompilerServices;
using Weather.Services;

namespace Weather.WPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private OpenWeatherApiService _service;

        public string Data { get; set; }

        public MainViewModel(OpenWeatherApiService service)
        {
            _service = service;
            Init();
        }

        public async void Init()
        {
            var result = await _service.GetCurrentWeather("Kharkiv");
            Data = $"Temperature in {result.Name} is {result.MainData.Temperature} degree.";
            OnPropertyChanged(nameof(Data));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}