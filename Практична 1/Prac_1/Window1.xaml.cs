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
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Prac_1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Stopwatch stopWatch;
        TimeSpan ts;
        double t0, t1;
        int count = 0;
        public Window1()
        {
            InitializeComponent();
            Label1.Content = "плагіатор";
            stopWatch = new Stopwatch();
            stopWatch.Start();
            t0 = 0;
            
        }
        private void GoToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }
        
        static string pass = @"C:\Users\38099\Desktop\Роботи\Основи програмування\Практична 1\статистика.txt";
        
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            StreamWriter result = new StreamWriter("Result.txt", true);
            ts = stopWatch.Elapsed;
            if (count > 0 && count<9)
            {
                t1 = ts.TotalSeconds;
                result.Write((Math.Round(t1 - t0, 2)).ToString()+" ");
                t0 = t1;
            }
            else
                t0 = ts.TotalSeconds;
            count++;
            result.Close();
        }
        int i = 0;

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            Label3.Content = TextBox.Text;
            Label2.Content = "Кількість введених символів: " + TextBox.Text.Length;
        }
       
        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            count = 0;
            int n;
            if (ComboBox1.SelectedIndex == 0)
            {
                n = 3;
            }
            else if (ComboBox1.SelectedIndex == 1)
            {
                n = 5;
            }
            else
            {
                n = 0;
            }
            string keyword = Label1.Content.ToString();
            string input = TextBox.Text;
            if (i<n)
            {
                double[] t = new double[TextBox.Text.Length];
                int o = 0;
                TextBox.Text = "";
                i++;
                if (input==keyword)
                {
                    StreamReader resl = new StreamReader("Result.txt");
                    string[] Line = resl.ReadLine().Split(' ', '\n', StringSplitOptions.RemoveEmptyEntries);
                    double matspod = 0;
                    for (int i = 0; i < keyword.Length - 1; i++)
                    {
                        matspod += Convert.ToDouble(Line[i]);
                    }
                    matspod = matspod / (keyword.Length - 1);
                    double sqmatspod = 0;
                    for (int i = 0; i < keyword.Length - 1; i++)
                    {
                        sqmatspod += Math.Pow(Convert.ToDouble(Line[i]), 2);
                    }
                    sqmatspod = sqmatspod / (keyword.Length - 1);
                    double dyspers = sqmatspod - Math.Pow(matspod, 2);
                    StreamWriter student = new StreamWriter(@"C:\Users\38099\Desktop\Роботи\Основи програмування\Практична 1\коефстьюдента.txt", true);
                    int f = 0;
                    for (int j = 0; j < keyword.Length-1; j++)
                    {
                        t[o] = Math.Abs((Convert.ToDouble(Line[i]) - matspod) / (Math.Sqrt(dyspers) ));
                        if (t[o] > 2.31)
                        {
                            MessageBox.Show("Один з елементів незначущий, спроба не зарахована. Щось ви занадто повільні!");
                            f = 1;
                            i--;
                        }
                        student.Write(t[o] + " ");
                        o++;
                    }
                    if (f == 0)
                    {
                        StreamWriter statist = new StreamWriter(pass, true);
                        for (int j = 0; j < keyword.Length - 1; j++)
                        {
                            statist.Write(Line[j] + " ");
                        }
                        statist.WriteLine();
                        statist.Close();
                        StreamWriter MatSpod = new StreamWriter(@"C:\Users\38099\Desktop\Роботи\Основи програмування\Практична 1\матсподівання.txt", true);
                        MatSpod.WriteLine(matspod + " " + dyspers);
                        MatSpod.Close();
                        //StreamWriter dysp = new StreamWriter(@"C:\Users\38099\Desktop\Роботи\Основи програмування\Практична 1\дисперсія.txt", true);
                        //dysp.Write(dyspers + " ");
                        //dysp.Close();
                    }
                    student.WriteLine();
                    student.Close();
                    resl.Close();
                }
            }
            StreamWriter result = new StreamWriter("Result.txt", false);
            result.Write("");
            result.Close();
        }
    }
}
