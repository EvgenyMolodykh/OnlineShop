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
            var SingInWindow = new SingInWindow();
            SingInWindow.Show();
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            var RegistrationWindow = new RegistrationWindow();
            RegistrationWindow.Show();
        }
    }
}