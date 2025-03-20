using System.Windows;
using System.Windows.Controls;

namespace Autorization
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Register_Button.Click += Register_Button_Click;
            SingIn_Button.Click += SingIn_Button_Click;
            SingOut_Button.Click += SingOut_Button_Click;
            Loaded += MainWindow_Loaded;
            

            var data = new DayForecastModel() 
            { 
                DataTime = DateTime.Now,
                MaxTemperature =  5,
                MinTemperature = -2,
            };
            var data2 = new DayForecastModel()
            {
                DataTime = DateTime.Now,
                MaxTemperature = 10,
                MinTemperature = -5,
            };

            var data7 = new DayForecastModel()
            {
                DataTime = DateTime.Now,
                MaxTemperature = 7,
                MinTemperature = -7,
            };

            WeaterDays_ListBox.ItemsSource = new List<DayForecastModel>() {  data, data2, data2, data2, data2, data2, data7};
        }

        private void WeaterDay_Button(object sender, RoutedEventArgs e)
        {
            if (sender is Button button) 
            {

                var day = button.DataContext as DayForecastModel;
                if (day != null)
                {
                    Detals_StackPanel.DataContext = day;
                }
                return;
            }
            return;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var singInUser = UserStorage.GetSingInUser();
            if (singInUser != null)
            {
                Autorized();
            }
            else
            {
                UnAuthorized();
            }
        }
         private void SingOut_Button_Click(object sender, RoutedEventArgs e)
        {
            UserStorage.SingOut();
            UnAuthorized();
        }
        private void SingIn_Button_Click(object sender, RoutedEventArgs e)
        {
            
            var signInWindow = new SingInWindow();
            signInWindow.ShowDialog();
            Autorized();
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            var registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();
            var singInUser = UserStorage.GetSingInUser();
            if (singInUser != null)
            {
                Autorized();
            }
            else
            {
                UnAuthorized();
            }
        }
        private void Autorized()
        {
            LoginName_Label.Visibility = Visibility.Visible;
            PersonalDesk_Label.Visibility = Visibility.Visible;
            SingOut_Button.Visibility = Visibility.Visible;
            Register_Button.Visibility = Visibility.Collapsed;
            SingIn_Button.Visibility = Visibility.Collapsed;
            showLoggedUser();
        }
        private void UnAuthorized()
        {
            LoginName_Label.Visibility = Visibility.Collapsed;
            PersonalDesk_Label.Visibility = Visibility.Collapsed;
            SingOut_Button.Visibility = Visibility.Collapsed;
            Register_Button.Visibility = Visibility.Visible;
            SingIn_Button.Visibility = Visibility.Visible;
        }

        public void showLoggedUser() 

        {
            var users = UserStorage.GetAllUsers();
            var singInUser = users.FirstOrDefault(u => u.IsSingIn);

            if (singInUser == null|| !singInUser.IsSingIn)
            {
                LoginName_Label.Content = string.Empty;
            }
            else 
            {
               LoginName_Label.Content = singInUser.Login;
            }
        }
        
    }
}