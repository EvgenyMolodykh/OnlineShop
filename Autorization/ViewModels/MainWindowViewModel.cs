using WeatherAppWPF.Views.Home;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WeatherAppWPF.ViewModels
{
    public partial class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand? HomeCommand { get; set; }

        private HomeViewViewModel homeViewModel;

        public HomeViewViewModel HomeViewModel
        {
            get { return homeViewModel; }
            set { 
                homeViewModel = value;
                OnPropertyChanged();
            }
        }
        public MainWindowViewModel()
        {
            HomeCommand = new RelayCommand(OpenHomeView, CanOpenHomeView);
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
