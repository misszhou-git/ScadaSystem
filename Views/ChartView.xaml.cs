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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Extensions.DependencyInjection;
using TulingScadaSystem.ViewModels;

namespace TulingScadaSystem.Views
{
    /// <summary>
    /// ChartView.xaml 的交互逻辑
    /// </summary>
    public partial class ChartView : UserControl
    {
        private readonly ChartViewModel _viewModel;

        public ChartView()
        {
            InitializeComponent();
            _viewModel = App.Current.Services.GetService<ChartViewModel>();
            DataContext = _viewModel;

            Loaded += ChartView_Loaded;
        }

        private void ChartView_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.InitPlot(WpfPlotShow);
        }
    }
}
