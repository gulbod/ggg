using System;
using System.Windows;
using System.Windows.Controls;

namespace PracticalWork2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InputI.Text) || string.IsNullOrWhiteSpace(InputX.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            if (!double.TryParse(InputI.Text, out double i) || !double.TryParse(InputX.Text, out double x))
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения.");
                return;
            }

            double result = 0;
            double fx = 0;

            if (shRadioButton.IsChecked == true)
            {
                fx = Math.Sinh(x);
            }
            else if (x2RadioButton.IsChecked == true)
            {
                fx = Math.Pow(x, 2);
            }
            else if (exRadioButton.IsChecked == true)
            {
                fx = Math.Exp(x);
            }

            if (i % 2 == 1 && x > 0)
            {
                result = i * Math.Sqrt(fx);
            }
            else if (i % 2 == 0 && x < 0)
            {
                result = (i / 2) * Math.Sqrt(Math.Abs(fx));
            }
            else
            {
                result = Math.Sqrt(Math.Abs(i * fx));
            }

            OutputResult.Text = result.ToString();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            InputI.Clear();
            InputX.Clear();
            OutputResult.Clear();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите выйти?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
