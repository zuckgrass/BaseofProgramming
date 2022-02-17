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
using System.IO;

namespace Prac_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            string pass = @"C:\Users\38099\Desktop\Роботи\Основи програмування\Практична 1\статистика.txt";
            StreamWriter statistics = new StreamWriter(@"Result.txt");
            statistics.Write(string.Empty);
            statistics.Close();
            StreamWriter statistic = new StreamWriter(pass);
            statistic.Write(string.Empty);
            statistic.Close();
            StreamWriter matspod = new StreamWriter(@"C:\Users\38099\Desktop\Роботи\Основи програмування\Практична 1\матсподівання.txt");
            matspod.Write(string.Empty);
            matspod.Close();
            StreamWriter dyspers = new StreamWriter(@"C:\Users\38099\Desktop\Роботи\Основи програмування\Практична 1\дисперсія.txt");
            dyspers.Write(string.Empty);
            dyspers.Close();
            StreamWriter st1 = new StreamWriter(@"C:\Users\38099\Desktop\Роботи\Основи програмування\Практична 1\статистика1.txt");
            st1.Write(string.Empty);
            st1.Close();
            StreamWriter mt1 = new StreamWriter(@"C:\Users\38099\Desktop\Роботи\Основи програмування\Практична 1\матсподівання1.txt");
            mt1.Write(string.Empty);
            mt1.Close();
            StreamWriter ds1 = new StreamWriter(@"C:\Users\38099\Desktop\Роботи\Основи програмування\Практична 1\дисперсія1.txt");
            ds1.Write(string.Empty);
            ds1.Close();
            StreamWriter st = new StreamWriter(@"C:\Users\38099\Desktop\Роботи\Основи програмування\Практична 1\коефстьюдента.txt");
            st.Write(string.Empty);
            st.Close();
            StreamWriter prost = new StreamWriter("Statistic1.txt");
            prost.Write(string.Empty);
            prost.Close();
            System.Windows.Application.Current.Shutdown();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1;
            w1 = new Window1();
            Hide();
            w1.Show();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Window2 w2;
            w2 = new Window2();
            Hide();
            w2.Show();
        }
    }
}
