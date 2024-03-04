using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            calculateButton.Click += CalculateButton_Click;
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            var firstNumber = Convert.ToInt32(firstNumberTextBox.Text);
            var secondNumber = Convert.ToInt32(secondNumberTextBox.Text);

            var total = firstNumber + secondNumber;

            resultLabel.Content = total.ToString();
        }
    }
}