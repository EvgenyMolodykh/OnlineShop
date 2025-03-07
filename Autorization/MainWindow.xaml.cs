using System.Windows;

namespace Autorization
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Register_Button.Click += Register_Button_Click;
            SingIn_Button.Click += SingIn_Button_Click;
        }

        private void SingIn_Button_Click(object sender, RoutedEventArgs e)
        {
            var signInWindow = new SingInWindow();
            Hide();
            signInWindow.ShowDialog();
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            LoginName_Label.Visibility = Visibility.Hidden;
            PersonalDesk_Label.Visibility = Visibility.Hidden;
            SingOut_Button.Visibility = Visibility.Hidden;
            SingIn_Button.Visibility = Visibility.Hidden;
            Register_Button.Visibility = Visibility.Hidden;

            var registrationWindow = new RegistrationWindow();
            Hide();
            registrationWindow.Show();
        }
    }
}