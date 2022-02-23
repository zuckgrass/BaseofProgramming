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
            initControls();
            
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }
        TextBox TextBox1;
        TextBox Num;
        TextBox PIP;
        TextBox Grup;
        private void initControls()
        {
            this.Title = "Список студентів";
            this.ResizeMode = ResizeMode.NoResize;
            this.Background = new SolidColorBrush(Colors.Lime);
            Grid myGrid = new Grid();
            myGrid.Width = 600;
            myGrid.Height = 315;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = false;
            Button Button1 = new Button();
            Button1.Width = 300;
            Button1.Height = 45;
            Button1.Content = "Додати студента";
            Button1.Background = new SolidColorBrush(Colors.LimeGreen);
            Button1.FontSize = 16;
            Button Button2 = new Button();
            Button2.Width = 300;
            Button2.Height = 45;
            Button2.Content = "Видалити студента";
            Button2.Background = new SolidColorBrush(Colors.OrangeRed);
            Button2.FontSize = 16;
            Label label1 = new Label();
            label1.FontSize = 16;
            label1.Width = 300;
            label1.Height = 45;
            label1.Content = "Введіть номер залікової: ";
            Label label2 = new Label();
            label2.FontSize = 16;
            label2.Width = 300;
            label2.Height = 45;
            label2.Content = "Введіть номер залікової: ";
            Label label3 = new Label();
            label3.FontSize = 16;
            label3.Width = 300;
            label3.Height = 45;
            label3.Content = "Прізвище/ім'я/по-батькові: ";
            Label label4 = new Label();
            label4.FontSize = 16;
            label4.Width = 300;
            label4.Height = 45;
            label4.Content = "Номер групи: ";
            Num=new TextBox();
            Num.FontSize = 16;
            Num.Width = 300;
            Num.Height = 45;
            Grup = new TextBox();
            Grup.FontSize = 16;
            Grup.Width = 300;
            Grup.Height = 45;
            PIP = new TextBox();
            PIP.FontSize = 16;
            PIP.Width = 300;
            PIP.Height = 45;
            TextBox1 = new TextBox();
            TextBox1.FontSize = 16;
            TextBox1.Width = 300;
            TextBox1.Height = 45;
            Button GoToMain = new Button();
            GoToMain.Width = 300;
            GoToMain.Height = 45;
            GoToMain.Content = "GoToMain";
            GoToMain.Background = new SolidColorBrush(Colors.Crimson);
            GoToMain.FontSize = 16;                                                                                                     
            Button1.Click += Button1_Click;
            Button2.Click += Button2_Click;
            GoToMain.Click += ExitBtn_Click;
            RowDefinition[] rows = new RowDefinition[7];
            ColumnDefinition[] cols = new ColumnDefinition[2];
            for (int i = 0; i < 7; i++)
            {
                rows[i] = new RowDefinition();
                myGrid.RowDefinitions.Add(rows[i]);
            }
            for (int i = 0; i < 2; i++)
            {
                cols[i] = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(cols[i]);
            }
            Grid.SetRow(Button1, 0);
            Grid.SetColumn(Button1, 0);
            myGrid.Children.Add(Button1);
            Grid.SetRow(Button2, 0);
            Grid.SetColumn(Button2, 1);
            myGrid.Children.Add(Button2);
            Grid.SetRow(label1, 1);
            Grid.SetColumn(label1, 0);
            myGrid.Children.Add(label1);
            Grid.SetRow(label2, 1);
            Grid.SetColumn(label2, 1);
            myGrid.Children.Add(label2);
            Grid.SetRow(label3, 3);
            Grid.SetColumn(label3, 0);
            myGrid.Children.Add(label3);
            Grid.SetRow(label4, 5);
            Grid.SetColumn(label4, 0);
            myGrid.Children.Add(label4);
            Grid.SetRow(Num, 2);
            Grid.SetColumn(Num, 0);
            myGrid.Children.Add(Num);
            int getNum () => int.Parse(Num.Text);
            Grid.SetRow(PIP, 4);
            Grid.SetColumn(PIP, 0);
            myGrid.Children.Add(PIP);
            Grid.SetRow(Grup, 6);
            Grid.SetColumn(Grup, 0);
            myGrid.Children.Add(Grup);
            Grid.SetRow(TextBox1, 2);
            Grid.SetColumn(TextBox1, 1);
            myGrid.Children.Add(TextBox1);
            Grid.SetRow(GoToMain, 6);
            Grid.SetColumn(GoToMain, 1);
            myGrid.Children.Add(GoToMain);
            this.Content = myGrid; 
            this.Show();
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
