using System.Windows;

namespace Autorization
{

    public partial class MainWindow : Window
    {

        private UserStorage userStorage { get; } = new UserStorage();
        public MainWindow()
        {
            InitializeComponent();
            Register_Button.Click += Register_Button_Click;
            SingIn_Button.Click += SingIn_Button_Click;
            SingOut_Button.Click += SingOut_Button_Click;
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var singInUser = userStorage.GetSingInUser();
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
            userStorage.SingOut();
            UnAuthorized();
        }
        private void SingIn_Button_Click(object sender, RoutedEventArgs e)
        {
            Autorized();
            var signInWindow = new SingInWindow();
            signInWindow.ShowDialog();
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            var registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();
            var singInUser = userStorage.GetSingInUser();
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
            Register_Button.Visibility = Visibility.Hidden;
            SingIn_Button.Visibility = Visibility.Hidden;
        }
        private void UnAuthorized()
        {
            LoginName_Label.Visibility = Visibility.Hidden;
            PersonalDesk_Label.Visibility = Visibility.Hidden;
            SingOut_Button.Visibility = Visibility.Hidden;
            Register_Button.Visibility = Visibility.Visible;
            SingIn_Button.Visibility = Visibility.Visible;
        }

        
    }
}