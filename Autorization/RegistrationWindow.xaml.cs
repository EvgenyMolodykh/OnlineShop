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
            
            var login = RegLogin_TextBox.Text;
            var password = RegPassword_TextBox.Text;
            var confirmPassword = ConfirmPassword_TextBox.Text;

            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Логин не может быть пустым");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пароль не может быть пустым");
                return;
            }

            if (string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Поле подтверждения пароля не может быть пустым");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            RegisterUser();
        }

        private void RegisterUser()
        {
            MessageBox.Show("Вы успешно зарегестрировались");
        }
    }
}
