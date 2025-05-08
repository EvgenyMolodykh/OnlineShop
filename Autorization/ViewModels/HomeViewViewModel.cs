using WeatherAppWPF.Models;
using WeatherAppWPF.Repository;

namespace WeatherAppWPF.ViewModels
{
    public class HomeViewViewModel : ViewModelBase
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
  
    }
}
