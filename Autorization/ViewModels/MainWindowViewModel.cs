using WeatherAppWPF.Views.Home;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WeatherAppWPF.Views.Location;

namespace WeatherAppWPF.ViewModels
{
    public partial class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand? HomeCommand { get; set; }
        public ICommand? LocationCommand { get; set; }

        private HomeViewViewModel homeViewModel;

        public HomeViewViewModel HomeViewModel
        {
            get { return homeViewModel; }
            set { 
                homeViewModel = value;
                OnPropertyChanged();
            }
        }


        private LocationViewViewModel locationViewViewModel;

        public LocationViewViewModel LocationViewViewModel
        {
            get { return locationViewViewModel; }
            set
            {
                locationViewViewModel = value;
                OnPropertyChanged();
            }
        }


        public MainWindowViewModel()
        {
            HomeCommand = new RelayCommand(OpenHomeView, CanOpenHomeView);
            LocationCommand = new RelayCommand(OpenLocationView, CanOpenLocationView);
        }



        private bool CanOpenLocationView(object arg)
        {
            return true;
        }

        private void OpenLocationView(object obj)
        {
            LocationViewViewModel = new LocationViewViewModel();
        }



        private bool CanOpenHomeView(object arg)
        {
            return true;
        }

        private void OpenHomeView(object obj)
        {
            HomeViewModel = new HomeViewViewModel();
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
