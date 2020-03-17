using GalaSoft.MvvmLight.Messaging;
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

namespace MvvmLightDemo.View
{
    /// <summary>
    /// frmMain.xaml 的交互逻辑
    /// </summary>
    public partial class frmMain : Window
    {
        public frmMain()
        {
            InitializeComponent();
            Messenger.Default.Register<string>(this, "myMsg", ShowMsg);
            this.Unloaded += (sender , e) => Messenger.Default.Unregister(this);
        }

        private void ShowMsg(string obj)
        {
            MessageBox.Show(obj);
        }
    }
}
