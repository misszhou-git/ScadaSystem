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
    /// Dialog.xaml 的交互逻辑
    /// </summary>
    public partial class Dialog : UserControl
    {
        public Dialog()
        {
            InitializeComponent();
        }

        public Dialog(string content)
        {
            InitializeComponent();
            textblock.Text = content;
        }

        public Dialog(string content,MessageBoxButton button = MessageBoxButton.OK)
        {
            InitializeComponent();
            textblock.Text = content;

            if(button == MessageBoxButton.YesNo)
            {
                stackPanelYesOrNo.Visibility = Visibility.Visible;
            }
            else
            {
                stackPanelOk.Visibility = Visibility;
            }
        }

    }
}
