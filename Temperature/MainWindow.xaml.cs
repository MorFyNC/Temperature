using System.Text;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Temperature.Data;

namespace Temperature
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Weather> weatherList;
        private Sort sort;
        private WeatherStatus? filter;
        private Nullable<bool> isReversed;
        public MainWindow()
        {
            InitializeComponent();
            weatherList = Data.DataContext.Weathers;
            lstView.ItemsSource = weatherList;
        }

        private void DeleteWeather(object sender, RoutedEventArgs e)
        {
            var weather = (Weather)lstView.SelectedItem;
            if (weather == null) return;
            weatherList.Remove(weather);
            lstView.Items.Refresh();
        }

        private void FilterSortButtonClick(object sender, RoutedEventArgs e)
        {
            weatherList = Data.DataContext.Weathers;

            FilterWindow filterWindow = new(filter, sort, isReversed);
            filterWindow.ShowDialog();

            if (filterWindow.DialogResult != true) return;
            sort = filterWindow.sort;
            filter = filterWindow.filter;
            isReversed = filterWindow.isReversed.IsChecked;

            if (sort != null) weatherList = sort.SortingFunc.Invoke(weatherList);
            if (filter != null) weatherList = weatherList.Where(x => x.WeatherStatus == filter).ToList();
            if (isReversed != null && isReversed == true) weatherList.Reverse();

            lstView.ItemsSource = weatherList;
            lstView.Items.Refresh();
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
            if(addWindow.DialogResult != true) return;
            Data.DataContext.Weathers.Add(addWindow.NewWeather);
            weatherList = Data.DataContext.Weathers;
            if (sort != null) weatherList = sort.SortingFunc.Invoke(weatherList);
            if (filter != null) weatherList = weatherList.Where(x => x.WeatherStatus == filter).ToList();
            if (isReversed != null && isReversed == true) weatherList.Reverse(); 
            lstView.ItemsSource = weatherList;
            lstView.Items.Refresh();
        }

        private void OutputButtonClick(object sender, RoutedEventArgs e)
        {
            OutputWindow outputWindow = new OutputWindow();
            outputWindow.Show();
        }
    }
}