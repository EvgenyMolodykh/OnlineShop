using System.Windows;

namespace Autorization
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Register_Button.Click += Register_Button_Click; 
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            var RegistrationWindow = new RegistrationWindow();
            RegistrationWindow.Show();
        }
    }
}