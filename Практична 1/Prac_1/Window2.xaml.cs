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

namespace Prac_1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Stopwatch stopWatch;
        TimeSpan ts;
        double t0, t1;
        int count = 0, h = 0, m=0;
        public Window2()
        {
            InitializeComponent();
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

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            StreamWriter result = new StreamWriter("Result.txt", true);
            ts = stopWatch.Elapsed;
            if (count > 0 && count < 9)
            {
                t1 = ts.TotalSeconds;
                result.Write((Math.Round(t1 - t0, 2)).ToString() + " ");
                t0 = t1;
            }
            else
                t0 = ts.TotalSeconds;
            count++;
            result.Close();
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            NumCount.Content = text.Text.Length;
        }

        private void text_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
            if (i<n)
            {
                i++;
                StreamReader resultpro = new StreamReader("Result.txt");
                string[] Line = new string[8];
                Line = resultpro.ReadLine().Split(' ', '\n', StringSplitOptions.RemoveEmptyEntries);
                resultpro.Close();
                StreamWriter statistic1 = new StreamWriter(@"C:\Users\38099\Desktop\Роботи\Основи програмування\Практична 1\статистика1.txt", true);
                if (text.Text == "плагіатор")
                {
                    NumCount.Content = h++;
                    foreach (var item in Line)
                    {
                        statistic1.Write(item + " ");
                    }
                    statistic1.WriteLine();
                    statistic1.Close();
                    Statistic_();
                }
                statistic1.Close();
                text.IsEnabled = true;
                NumCount.Content = 0;
            }
            else
            {
                NumCount.Content = 0;
                text.IsEnabled = false;
            }
            text.Text = string.Empty;
            StreamWriter resultprotec = new StreamWriter("Result.txt", false);
            resultprotec.Write(string.Empty);
            resultprotec.Close();
        }
        int i = 0;
        private void Statistic_()
        {
            StreamWriter Statistic_PRO = new StreamWriter(@"Statistic1.txt", true);
            double e = 0; int j = 0, length;
            int attempt = int.Parse(ComboBox1.Text);
            double[] M = new double[attempt];
            double[] S = new double[attempt];
            double[] S_2 = new double[attempt];
            double[] t = new double[attempt];
            StreamReader statistic = new StreamReader(@"C:\Users\38099\Desktop\Роботи\Основи програмування\Практична 1\статистика1.txt");
            foreach (var line in statistic.ReadLine().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
            {
                double[] y = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => double.Parse(x)).ToArray();
                length = y.Length;
                for (int i = 0; i < y.Length; i++)
                {
                    e += y[i];
                }
                M[j] = 1.0 * e / (y.Length+1);
                e = 0;
                for (int i = 0; i < y.Length; i++)
                {
                    e += Math.Pow(y[i] - M[j], 2);
                }
                S_2[j] = 1.0 * e / y.Length;
                S[j] = Math.Sqrt(S_2[j]);
                Statistic_PRO.WriteLine(M[j] + " " + S[j]);
                j++;
                int o = 0;
                int g = 0;
                while (o != y.Length)
                {
                    t[o] = Math.Abs((y[o] - M[j]) / (S[j] / Math.Sqrt(y.Length - 1)));
                    if (t[o] > 1.860)
                    {
                        y = null;
                        break;
                    }
                    else g = 1;
                    o++;
                }
                if (g == 1) Statistic_PRO.Write(M[j] + " " + S[j] + "\n");
                Statistic_PRO.Close();
            }
            statistic.Close();
            StreamReader Matspod = new StreamReader(@"C:\Users\38099\Desktop\Роботи\Основи програмування\Практична 1\матсподівання.txt");
            j = 0; int r = 0, k = 0;
            double[] Fisher = new double[attempt];
            double[] S_ = new double[attempt];
            double[] t_ = new double[attempt];
            double[] P = new double[attempt];
            double[] P1 = new double[attempt];
            double[] P2 = new double[attempt];
            int success = 0;
            int c = 0;
            while (!Matspod.EndOfStream && c<attempt)
            {
                ProvT.Content = "";
                string line = Matspod.ReadLine();
                string[] Elem2 = line.Split(' ', '\n', StringSplitOptions.RemoveEmptyEntries);
                double Smax = Math.Pow(double.Parse(Elem2[1]), 2);
                double Smin = Math.Pow(S[c], 2);
                if ( Smax <= Smin)
                {
                    Smin = Math.Pow(double.Parse(Elem2[1]), 2);
                    Smax = Math.Pow(S[c], 2)*1.0;
                }
                //SMax.Content = Smax;
                //SMin.Content = Smin;
                Fisher[c] = Smax / Smin;
                //Proverka.Content = Fisher[c];
                if (Fisher[c] > 4.74 && S[c]!=0)
                    Dysp.Content = "Дисперсії вибірок: неоднорідні";
                else
                {
                    Dysp.Content = "Дисперсії вибірок: однорідні";
                    success++;
                }
                S_[c] = Math.Sqrt((Math.Pow(double.Parse(Elem2[1]), 2) + Math.Pow(S[c], 2)) * (text.Text.Length - 1) / (2 * text.Text.Length - 1));
                t_[c] = Math.Abs(double.Parse(Elem2[0]) + M[c]) / (S_[c] * Math.Sqrt(2.0 / text.Text.Length));
                //ProvT.Content = t_[j];
                if (t_[c] > 21)
                {
                    MessageBox.Show("не випадкова", "розбіжність");
                }
                else
                {
                    MessageBox.Show("випадкова", "розбіжність");
                    r++;
                }
                k++;
                P[c] = Math.Round(1.0 * r / k,5);
                PIdentify.Content = "Р ідентифікація: " + P[c];
                P1[c] = 1 - success / k;
                P1Field.Content = "Помилка 1-го роду: " + P1[c];
                P2[c] = success / k;
                P2Field.Content = "Помилка 2-го роду: " + P2[c];
                c++;
            }
            Matspod.Close();
        }
    }
}
