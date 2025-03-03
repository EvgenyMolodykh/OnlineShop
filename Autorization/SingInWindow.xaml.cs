using System.Windows;

namespace Autorization
{
    public partial class SingInWindow : Window
    {
        public SingInWindow()
        {
            InitializeComponent();
            SingIn_Button.Click += SingIn_Button_Click;
        }

        private void SingIn_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
