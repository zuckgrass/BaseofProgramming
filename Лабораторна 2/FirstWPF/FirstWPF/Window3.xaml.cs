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

namespace FirstWPF
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        static int M = 5;
        public Window3()
        {
            InitializeComponent();
            initControls();
            player = 1;
        }

        private void GoToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }
        static ComboBox[,] ArrComb;
        private void initControls()
        {
            this.Title = "Хрестики нулики";
            this.ResizeMode = ResizeMode.NoResize;
            this.Background = new SolidColorBrush(Colors.PeachPuff);
            Grid myGrid = new Grid();
            myGrid.Width = 400;
            myGrid.Height = 320;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = false;
            ArrComb = new ComboBox[M, M];
            Button GoToMain = new Button();
            GoToMain.Width = 160;
            GoToMain.Height = 64;
            GoToMain.Content = "GoToMain";
            GoToMain.Background=new SolidColorBrush(Colors.OrangeRed);
            GoToMain.FontSize = 12;
            //GoToMain.FontFamily= "Arial Black";
            Button Restart = new Button();
            Restart.Width = 160;
            Restart.Height = 64;
            Restart.Content = "Restart";
            Restart.Background = new SolidColorBrush(Colors.LimeGreen);
            for (int i = 0; i < M; i++)
                for (int j = 0; j < M; j++)
                {
                    ArrComb[i, j] = new ComboBox();
                    ArrComb[i, j].SelectionChanged += ComboBox1_SelectionChanged;
                    ArrComb[i, j].Items.Add("x");
                    ArrComb[i, j].Items.Add("o");
                    ArrComb[i, j].SelectedIndex = -1;
                }
            RowDefinition[] rows = new RowDefinition[M+1];
            ColumnDefinition[] cols = new ColumnDefinition[M];
            for (int i = 0; i < M+1; i++)
            {
                rows[i] = new RowDefinition();
                myGrid.RowDefinitions.Add(rows[i]);
            }
            
            for (int i = 0; i < M; i++)
            {
                cols[i] = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(cols[i]);
            }
            for (int i = 0; i < M; i++)
                for (int j = 0; j < M; j++)
                {
                    Grid.SetRow(ArrComb[i, j], i);
                    Grid.SetColumn(ArrComb[i, j], j);
                }
            Grid.SetRow(GoToMain, M);
            Grid.SetColumn(GoToMain, 0);
            Grid.SetColumnSpan(GoToMain, 2);
            Grid.SetRow(Restart, M);
            Grid.SetColumn(Restart, 3);
            Grid.SetColumnSpan(Restart, 2);
            for (int i = 0; i < M; i++)
                for (int j = 0; j < M; j++)
                {
                    myGrid.Children.Add(ArrComb[i, j]);
                }
            myGrid.Children.Add(GoToMain);
            myGrid.Children.Add(Restart);
            GoToMain.Click += GoToMain_Click;
            Restart.Click += Restart_Click;
            this.Content = myGrid;
            this.Show();
        }

        private void CheckWin()
        {
            bool flag=false;
            bool status;
            //рядки
            for (int i=0; i<M; i++)
            {
                flag = true; status = true;   
                for(int j=1; j<M; j++)
                {
                    if (ArrComb[i, j - 1].SelectedIndex != -1 && ArrComb[i, j-1].SelectedIndex == ArrComb[i, j].SelectedIndex)
                        status = true;
                    else
                        status = false;
                    flag &= status;
                }
                if (flag)
                { 
                    MessageBox.Show("You win!"); 
                }
                    
            }
            //стовпці
            for (int j = 0; j < M; j++)
            {
                flag = true; status = true;
                for (int i = 1; i < M; i++)
                {
                    if (ArrComb[i - 1, j].SelectedIndex != -1 && ArrComb[i-1, j].SelectedIndex == ArrComb[i, j].SelectedIndex)
                        status = true;
                    else
                        status = false;
                    flag &= status;
                }
                if (flag)
                {
                    MessageBox.Show("You win!");
                }
            }
            //головна діагональ
            for (int i=1; i<M; i++)
            {
                flag = true; status = true;
                if (ArrComb[i - 1, i - 1].SelectedIndex != -1 && ArrComb[i - 1, i - 1].SelectedIndex == ArrComb[i, i].SelectedIndex)
                    status = true;
                else
                    status = false;
                flag &= status;
            }
            if (flag)
            {
                MessageBox.Show("You win!");
            }
            //побічна діагональ
            for (int i=1; i<M; i++)
            {
                flag = true; status = true;
                if (ArrComb[i - 1, M - i - 1].SelectedIndex != -1 && ArrComb[i - 1, M-i-2].SelectedIndex == ArrComb[i, M-i-1].SelectedIndex)
                    status = true;
                else
                    status = false;
                flag &= status;
            }
            if (flag)
            {
                MessageBox.Show("You win!");
            }
        }
        private int player;
        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (player)
            {
                case 1:
                    sender.GetType().GetProperty("IsEnabled").SetValue(sender, false);
                    player = 2;
                    MessageBox.Show("Зараз ходять нулики");
                    break;
                case 2:
                    sender.GetType().GetProperty("IsEnabled").SetValue(sender, false);
                    player = 1;
                    MessageBox.Show("Зараз ходять хрестики");
                    break;
            }
            CheckWin();
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            
            for (int i = 0; i < M; i++)
                for (int j = 0; j < M; j++)
                {
                    ArrComb[i,j].SelectionChanged-= ComboBox1_SelectionChanged;
                    ArrComb[i, j].SelectedIndex = -1;
                    ArrComb[i, j].GetType().GetProperty("IsEnabled").SetValue(ArrComb[i, j], true);
                    ArrComb[i, j].SelectionChanged += ComboBox1_SelectionChanged;
                }
        }
    }
}