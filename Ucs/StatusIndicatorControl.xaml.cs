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
    /// StatusIndicatorControl.xaml 的交互逻辑
    /// </summary>
    public partial class StatusIndicatorControl : UserControl
    {
        public StatusIndicatorControl()
        {
            InitializeComponent();
        }


            
        public Brush ButtonBackground
        {
            get { return (Brush)GetValue(ButtonBackgroundProperty); }
            set { SetValue(ButtonBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonBackgroundProperty =
            DependencyProperty.Register("ButtonBackground", typeof(Brush), typeof(StatusIndicatorControl), new PropertyMetadata(Brushes.Green));



        public bool IsIndeterminate
        {
            get { return (bool)GetValue(IsIndeterminateProperty); }
            set { SetValue(IsIndeterminateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsIndeterminate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsIndeterminateProperty =
            DependencyProperty.Register("IsIndeterminate", typeof(bool), typeof(StatusIndicatorControl), new PropertyMetadata(false));
            

        public string StatusText
        {
            get { return (string)GetValue(StatusTextProperty); }
            set { SetValue(StatusTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StatusText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatusTextProperty =
            DependencyProperty.Register("StatusText", typeof(string), typeof(StatusIndicatorControl), new PropertyMetadata(string.Empty));


    }
}
