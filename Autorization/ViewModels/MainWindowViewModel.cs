using WeatherAppWPF.Views.Home;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WeatherAppWPF.Views.Location;

namespace WeatherAppWPF.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public ICommand? HomeCommand { get; set; }
        public ICommand? LocationCommand { get; set; }

        private ViewModelBase currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set { 
                currentViewModel = value;
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
            CurrentViewModel = new LocationViewViewModel();
        }

        private bool CanOpenHomeView(object arg)
        {
            return true;
        }

        private void OpenHomeView(object obj)
        {
            CurrentViewModel = new HomeViewViewModel();
        }
    }
}
