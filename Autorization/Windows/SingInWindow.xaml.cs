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
            
            if (string.IsNullOrEmpty(RegLogin_TextBox.Text) && string.IsNullOrEmpty(RegPassword_TextBox.Text)) 
            {
                MessageBox.Show("Заполните поля входа");
                return;
            }

            var user = UserManagement.GetUser(RegLogin_TextBox.Text);
            if (user != null) {
                if (RegPassword_TextBox.Text == user.Password)
                { 
                    MessageBox.Show("Вы успешно авторизировались");
                    Close();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }
                else
                {
                    MessageBox.Show("Не верный пароль");
                    return;
                }
            }
            else { MessageBox.Show("Такого пользователя не существует"); }
        }
    }
}
