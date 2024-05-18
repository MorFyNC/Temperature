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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Temperature.Data;
using static Temperature.FilterWindow;

namespace Temperature
{
    /// <summary>
    /// Логика взаимодействия для FilterWindow.xaml
    /// </summary>
    public partial class FilterWindow : Window
    {
        public WeatherStatus? filter { get; set; }
        public Sort? sort { get; set; }
        public FilterWindow(WeatherStatus? Filter, Sort? Sort, Nullable<bool> isChecked = false)
        {
            InitializeComponent();
            isReversed.IsChecked = isChecked;
            FilterCB.ItemsSource = Data.DataContext.weatherStatuses;
            SortCB.ItemsSource = Data.DataContext.Sorts;
            FilterCB.SelectedItem = Filter;
            SortCB.SelectedItem = Sort;
        }

        private void FilterClear(object sender, RoutedEventArgs e)
        {
            filter = null;
            FilterCB.SelectedItem = null;
        }

        private void SortClear(object sender, RoutedEventArgs e)
        {
            SortCB.SelectedItem = null;
            sort = null;
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            filter = (WeatherStatus?)FilterCB.SelectedItem;
            sort = (Sort?)SortCB.SelectedItem;
            Close();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
