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
using System.Data;

namespace FirstWPF
{
    /// <summary>
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        public Window5()
        {
            InitializeComponent();
            initControls();
        }
        Button[,] textButton;
        TextBox text;
        private void initControls()
        {
            this.Title = "Калькулятор";
            //this.ResizeMode = ResizeMode.NoResize;
            this.Background = new SolidColorBrush(Colors.PeachPuff);
            Grid myGrid = new Grid();
            myGrid.Width = 450;
            myGrid.Height = 420;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = false;
            textButton = new Button[5, 4];
            text = new TextBox();
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 4; j++)
                {
                    textButton[i, j] = new Button();
                    textButton[i, j].Click += Button_Click;
                }
            textButton[0, 0].Content = "GoToMain";
            textButton[0, 1].Content = "=";
            textButton[0, 2].Content = "C";
            textButton[0, 3].Content = "del";
            textButton[1, 0].Content = "7";
            textButton[1, 1].Content = "8";
            textButton[1, 2].Content = "9";
            textButton[1, 3].Content = "/";
            textButton[2, 0].Content = "4";
            textButton[2, 1].Content = "5";
            textButton[2, 2].Content = "6";
            textButton[2, 3].Content = "*";
            textButton[3, 0].Content = "1";
            textButton[3,1].Content = "2";
            textButton[3,2].Content = "3";
            textButton[3,3].Content = "-";
            textButton[4, 0].Content = "+/-";
            textButton[4, 1].Content = "0";
            textButton[4, 2].Content = ".";
            textButton[4, 3].Content = "+";
            RowDefinition[] rows = new RowDefinition[6];
            ColumnDefinition[] cols = new ColumnDefinition[4];
            for (int i = 0; i < 6; i++)
            {
                rows[i] = new RowDefinition();
                myGrid.RowDefinitions.Add(rows[i]);
            }

            for (int i = 0; i < 4; i++)
            {
                cols[i] = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(cols[i]);
            }
            Grid.SetRow(text, 0);
            Grid.SetColumn(text, 0);
            Grid.SetColumnSpan(text, 4);
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 4; j++)
                {
                    Grid.SetRow(textButton[i, j], i+1);
                    Grid.SetColumn(textButton[i, j], j);
                }
            myGrid.Children.Add(text);
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 4; j++)
                {
                    myGrid.Children.Add(textButton[i, j]);
                }
            this.Content = myGrid;
            this.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string textButton = ((Button)e.OriginalSource).Content.ToString();
                if (textButton == "C")
                {
                    text.Text = null;
                }
                else if (textButton == "del")
                {
                    text.Text = text.Text.Substring(0, text.Text.Length - 1);
                }
                else if (textButton == "=")
                {
                    text.Text = new DataTable().Compute(text.Text, null).ToString();
                }
                else if (textButton == "+/-")
                {
                    text.Text = new DataTable().Compute(text.Text + "*(-1)", null).ToString();
                }
                else if (textButton == "GoToMain")
                {
                    MainWindow mw = new MainWindow();
                    Hide();
                    mw.Show();
                }
                else
                {
                    text.Text += textButton;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введіть формулу правильно");
            }
        }
        
    }
}
