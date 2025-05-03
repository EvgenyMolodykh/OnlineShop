using WeatherAppWPF.Models;
using WeatherAppWPF.Repository;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WeatherAppWPF.ViewModels
{
    public class HomeViewViewModel : INotifyPropertyChanged
    {
        private List<DayForecastModel> forecastsDays;

        public List<DayForecastModel> ForecastsDays
        {
            get => forecastsDays; 
            set
            {
                forecastsDays = value;
                OnPropertyChanged();
            }
        }
        private DayForecastModel selectedDay;
        public DayForecastModel SelectedDay
        {
            get => selectedDay;
            set
            {
                selectedDay = value;
                OnPropertyChanged();
            }
        }

        public HomeViewViewModel()
        {
            ForecastsDays = WeatherDataStorage.GetAll();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop= "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        
    }
}
