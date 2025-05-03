using System.ComponentModel;

namespace WeatherAppWPF.ViewModels
{
    class HourlyForecastViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private HourlyForecastViewModel hourlyForecastViewModel;

        //public HourlyForecastViewModel() 
        //{
        //    get => WeatherDataStorage.GetAll();
        //    set
        //    {
        //        forecastsDays = value;
        //        OnPropertyChanged();
        //    }

        //}


        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
