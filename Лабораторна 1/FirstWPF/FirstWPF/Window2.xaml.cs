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
using System.IO;

namespace FirstWPF
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }
        static StreamReader Spysok;
        static StreamWriter NewSpysok;
        static string passSpysok = @"C:\Users\38099\Desktop\Роботи\Основи програмування\Лаб1\список студентів.txt";
        static string passNewSp = @"C:\Users\38099\Desktop\Роботи\Основи програмування\Лаб1\новий список.txt";

        public static void DeleteStu(string passNewSp, int Number, string passSpysok)
        {
            StreamReader Spy = new StreamReader(passSpysok);
            StreamWriter NewSpy = new StreamWriter(passNewSp);
            int i = 1;
            while (!Spy.EndOfStream)
            {
                string[] Line = Spy.ReadLine().Split('_', '\n', StringSplitOptions.RemoveEmptyEntries);
                if (int.Parse(Line[0]) != Number)
                {
                    NewSpy.WriteLine(Line[0]+"_"+Line[1]+"_"+Line[2]);
                }
                else
                {
                    i=0;
                }
            }
            if (i == 1)
            {
                MessageBox.Show("Немає такого номеру заліковки у списку");

            }
            Spy.Close();
            NewSpy.Close();
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            ChangeStreamReader(passNewSp, passSpysok);
            int n = int.Parse(TextBox1.Text);
            DeleteStu(passNewSp, n, passSpysok);
        }
        public static void AddStu(string passNewSp, string passSpysok, int num, string pip, string group)
        {
            StreamReader Spy = new StreamReader(passSpysok);
            StreamWriter NewSpy = new StreamWriter(passNewSp);
            while (!Spy.EndOfStream)
            { 
                string[] Line = Spy.ReadLine().Split('_', '\n', StringSplitOptions.RemoveEmptyEntries);
                if(num!=int.Parse(Line[0]))
                    NewSpy.WriteLine(Line[0] + "_" + Line[1] + "_" + Line[2]);
            }
            NewSpy.WriteLine(num+"_"+pip+"_"+group);
            Spy.Close();
            NewSpy.Close();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            ChangeStreamReader(passNewSp, passSpysok);
            int num=int.Parse(Num.Text);
            string pip=PIP.Text;
            string grup = Grup.Text;
            AddStu(passNewSp, passSpysok, num, pip, grup);
        }
        public void ChangeStreamReader(string passNewSp, string passSpysok)
        {
            StreamWriter Spys = new StreamWriter(passSpysok);
            StreamReader NewSpys = new StreamReader(passNewSp);
            while (!NewSpys.EndOfStream)
            {
                string[] Line = NewSpys.ReadLine().Split('_', '\n', StringSplitOptions.RemoveEmptyEntries);
                Spys.WriteLine(Line[0] + "_" + Line[1] + "_" + Line[2]);
            }
            Spys.Close();
            NewSpys.Close();
        }
    }
}
