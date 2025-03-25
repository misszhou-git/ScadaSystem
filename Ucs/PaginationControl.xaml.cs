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

namespace TulingScadaSystem.Ucs
{
    /// <summary>
    /// PaginationControl.xaml 的交互逻辑
    /// </summary>
    public partial class PaginationControl : UserControl
    {
        public PaginationControl()
        {
            InitializeComponent();
        }



        public int CurrentPage
        {
            get { return (int)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentPage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register("CurrentPage", typeof(int), typeof(PaginationControl), new PropertyMetadata(1));



        public int TotalPages
        {
            get { return (int)GetValue(TotalPagesProperty); }
            set { SetValue(TotalPagesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TotalPages.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalPagesProperty =
            DependencyProperty.Register("TotalPages", typeof(int), typeof(PaginationControl), new PropertyMetadata(1));


        // 命令：首页
        public ICommand GoToFirstPageCommand
        {
            get { return (ICommand)GetValue(GoToFirstPageCommandProperty); }
            set { SetValue(GoToFirstPageCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GoToFirstPageCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GoToFirstPageCommandProperty =
            DependencyProperty.Register("GoToFirstPageCommand", typeof(ICommand), typeof(PaginationControl));



        // 命令：上一页
        public ICommand GoToPreviousPageCommand
        {
            get { return (ICommand)GetValue(GoToPreviousPageCommandProperty); }
            set { SetValue(GoToPreviousPageCommandProperty, value); }
        }
        public static readonly DependencyProperty GoToPreviousPageCommandProperty =
            DependencyProperty.Register("GoToPreviousPageCommand", typeof(ICommand), typeof(PaginationControl));

        // 命令：下一页
        public ICommand GoToNextPageCommand
        {
            get { return (ICommand)GetValue(GoToNextPageCommandProperty); }
            set { SetValue(GoToNextPageCommandProperty, value); }
        }
        public static readonly DependencyProperty GoToNextPageCommandProperty =
            DependencyProperty.Register("GoToNextPageCommand", typeof(ICommand), typeof(PaginationControl));

        // 命令：最后一页
        public ICommand GoToLastPageCommand
        {
            get { return (ICommand)GetValue(GoToLastPageCommandProperty); }
            set { SetValue(GoToLastPageCommandProperty, value); }
        }
        public static readonly DependencyProperty GoToLastPageCommandProperty =
            DependencyProperty.Register("GoToLastPageCommand", typeof(ICommand), typeof(PaginationControl));
    }
}
