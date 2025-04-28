using Autorization.Models;
using Autorization.Repository;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Autorization.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private List<DayForecastModel> forecastsDays;

        public List<DayForecastModel> ForecastsDays
        {
            get { return forecastsDays; }
            set
            {
                forecastsDays = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel()
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
