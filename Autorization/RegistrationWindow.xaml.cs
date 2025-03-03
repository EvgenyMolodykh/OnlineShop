using System.Windows;

namespace Autorization
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            Registration_Button.Click += Registration_Button_Click;
        }

        private void Registration_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
