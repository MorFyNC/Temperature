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

namespace Temperature
{
    /// <summary>
    /// Логика взаимодействия для OutputWindow.xaml
    /// </summary>
    public partial class OutputWindow : Window
    {
        public OutputWindow()
        {
            InitializeComponent();
            GetMax();
            GetMin();
            GetAverage();
            GetRepeats();
            GetExtremums();
        }

        void GetMax()
        {
            MaxTempLbl.Content = $"Max temp: {Data.DataContext.Weathers.Max(x => x.Temperature)}";
        }

        void GetMin()
        {
            MinTempLbl.Content = $"Min temp: {Data.DataContext.Weathers.Min(x => x.Temperature)}";
        }

        void GetAverage()
        {
            AvgTempLbl.Content = $"Avg temp: {Data.DataContext.Weathers.Average(x => x.Temperature)}";
        }

        void GetRepeats()
        {
            var lst = Data.DataContext.Weathers;
            var d = lst.GroupBy(x => x.Temperature).ToDictionary(x => x.Key, x => x.Count());
            var m = d.FirstOrDefault(x => x.Value == d.Values.Max()).Key;
            List<Weather> Res = lst.Where(x => x.Temperature == m).ToList();
            RepeatsLstView.ItemsSource = Res;
            RepeatsLstView.Items.Refresh();
        }

        void GetExtremums()
        {
            var lst = Data.DataContext.Weathers;
            List<Extremum> Res = [];
            for (int i = 0; i < Data.DataContext.Weathers.Count - 1; i++)
            {
                if (Math.Abs(lst[i].Temperature - lst[i + 1].Temperature) > 10)
                {
                    Res.Add(new Extremum(lst[i], lst[i+1]));
                }
            }
        }
    }
}
