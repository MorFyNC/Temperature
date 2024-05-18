using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Temperature.Data;

namespace Temperature
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public Weather NewWeather { get; set; }
        public AddWindow()
        {
            InitializeComponent();
            WeatherStatusCb.ItemsSource = Data.DataContext.weatherStatuses;
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            if (YearTb.Text is null || MonthTb.Text is null || DayTb.Text is null || TemperatureTb.Text is null ||
                WeatherStatusCb.SelectedItem is null)
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            DialogResult = true;

            NewWeather =
                new Weather(
                    new DateTime(Convert.ToInt32(YearTb.Text), Convert.ToInt32(MonthTb.Text),
                        Convert.ToInt32(DayTb.Text)), Convert.ToDecimal(TemperatureTb.Text),
                    (WeatherStatus)WeatherStatusCb.SelectedItem);
        }
    }
}
