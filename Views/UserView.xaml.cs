using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using TulingScadaSystem.ViewModels;

namespace TulingScadaSystem.Views
{
    /// <summary>
    /// UserView.xaml 的交互逻辑
    /// </summary>
    public partial class UserView : UserControl
    {
        public UserView()
        {
            InitializeComponent(); 
            InitData();
        }

        private void InitData()
        {
            DataContext = App.Current.Services.GetService<UserViewModel>();
        }
    }
}
