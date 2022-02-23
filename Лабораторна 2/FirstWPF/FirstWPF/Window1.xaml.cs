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
//using System.Drawing.Size;

namespace FirstWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private int StartWidth;
        private int StartHeight;
        private int StartFontSize;
        public Window1()
        {
            InitializeComponent();
            StartWidth = (int)this.Width;
            StartHeight = (int)this.Height;
            StartFontSize = 36;
            myLabel.FontSize = StartFontSize;
        }

        private void MyWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double val = Math.Max(1.0 * StartWidth / this.Width,1.0 * StartHeight / this.Height);
            myLabel.FontSize = (int)(1.0 * StartFontSize / val);
        }

        private void GoToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }
    }
}
