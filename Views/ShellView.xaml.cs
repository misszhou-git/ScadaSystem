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
using CommunityToolkit.Mvvm.Messaging;
using MahApps.Metro.Controls;
using Microsoft.Extensions.DependencyInjection;
using TulingScadaSystem.Messages;
using TulingScadaSystem.Services;
using TulingScadaSystem.ViewModels;

namespace TulingScadaSystem.Views
{
    /// <summary>
    /// ShellView.xaml 的交互逻辑
    /// </summary>
    public partial class ShellView : MetroWindow
    {
        private UserSession _userSession;

        public ShellView(UserSession userSession)
        {
            _userSession = userSession;
            InitializeComponent();
            InitData();
            InitChangeLoginAndWindowView();
        }

        private void InitChangeLoginAndWindowView()
        {
            // 获取登录界面
            container.Content =  App.Current.Services.GetService<LoginView>();

            // 如果登录成功，则跳转到主界面上(来自于 LoginViewModel 的消息注册）
            WeakReferenceMessenger.Default.Register<LoginMessage>(this, (sender, arg) =>
            {
                container.Content = App.Current.Services.GetService<MainView>();
                Width = 1200;
                Height = 800;
                // 设置窗体弹出的坐标位置
                SetWindowLocation();
            });

            // 用户切换
            WeakReferenceMessenger.Default.Register<LogoutMessage>(this, (sender, arg) =>
            {
                _userSession.CurrentUser = new Models.User()
                {

                    UserName = "test",
                    Password = "test"
                };

                container.Content = App.Current.Services.GetService<LoginView>();
                Width = 800;
                Height = 450;
                // 设置窗体弹出的坐标位置
                SetWindowLocation();
            });
        }

        private void SetWindowLocation()
        {
            Left = (SystemParameters.WorkArea.Width - Width) / 3;
            Top = (SystemParameters.WorkArea.Height - Height) / 3;  
        }

        private void InitData()
        {
            DataContext = App.Current.Services.GetService<ShellViewModel>();
        }


    }
}
