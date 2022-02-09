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
        public Window3()
        {
            InitializeComponent();
            player = 1;
        }

        private void GoMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }
        private void CheckWin()
        {
            if (ComboBox1.SelectedIndex != -1)
            {
                //рядки
                if (ComboBox1.SelectedIndex == ComboBox2.SelectedIndex && ComboBox2.SelectedIndex == ComboBox3.SelectedIndex)
                {
                    if (ComboBox3.SelectedIndex == ComboBox4.SelectedIndex && ComboBox4.SelectedIndex == ComboBox5.SelectedIndex)
                    {
                        MessageBox.Show("You win!");
                    }
                }
            }
            if (ComboBox6.SelectedIndex != -1)
            {
                if (ComboBox6.SelectedIndex == ComboBox7.SelectedIndex && ComboBox7.SelectedIndex == ComboBox8.SelectedIndex)
                {
                    if (ComboBox8.SelectedIndex == ComboBox9.SelectedIndex && ComboBox9.SelectedIndex == ComboBox10.SelectedIndex)
                    {
                        MessageBox.Show("You win!");
                    }
                }
            }
            if (ComboBox11.SelectedIndex != -1)
            {
                if (ComboBox11.SelectedIndex == ComboBox12.SelectedIndex && ComboBox12.SelectedIndex == ComboBox13.SelectedIndex)
                {
                    if (ComboBox13.SelectedIndex == ComboBox14.SelectedIndex && ComboBox14.SelectedIndex == ComboBox15.SelectedIndex)
                    {
                        MessageBox.Show("You win!");
                    }
                }
            }
            if (ComboBox16.SelectedIndex != -1)
            {
                if (ComboBox16.SelectedIndex == ComboBox17.SelectedIndex && ComboBox17.SelectedIndex == ComboBox18.SelectedIndex)
                {
                    if (ComboBox18.SelectedIndex == ComboBox19.SelectedIndex && ComboBox19.SelectedIndex == ComboBox20.SelectedIndex)
                    {
                        MessageBox.Show("You win!");
                    }
                }
            }
            if (ComboBox21.SelectedIndex != -1)
            {
                if (ComboBox21.SelectedIndex == ComboBox22.SelectedIndex && ComboBox22.SelectedIndex == ComboBox23.SelectedIndex)
                {
                    if (ComboBox23.SelectedIndex == ComboBox24.SelectedIndex && ComboBox24.SelectedIndex == ComboBox25.SelectedIndex)
                    {
                        MessageBox.Show("You win!");
                    }
                }
            }
            //стовпчики
            if (ComboBox1.SelectedIndex != -1)
            {
                if (ComboBox1.SelectedIndex == ComboBox6.SelectedIndex && ComboBox6.SelectedIndex == ComboBox11.SelectedIndex)
                {
                    if (ComboBox11.SelectedIndex == ComboBox16.SelectedIndex && ComboBox16.SelectedIndex == ComboBox21.SelectedIndex)
                    {
                        MessageBox.Show("You win!");
                    }
                }
            }
            if (ComboBox2.SelectedIndex != -1)
            {
                if (ComboBox2.SelectedIndex == ComboBox7.SelectedIndex && ComboBox7.SelectedIndex == ComboBox12.SelectedIndex)
                {
                    if (ComboBox12.SelectedIndex == ComboBox17.SelectedIndex && ComboBox17.SelectedIndex == ComboBox22.SelectedIndex)
                    {
                        MessageBox.Show("You win!");
                    }
                }
            }
            if (ComboBox3.SelectedIndex != -1)
            {
                if (ComboBox3.SelectedIndex == ComboBox8.SelectedIndex && ComboBox8.SelectedIndex == ComboBox13.SelectedIndex)
                {
                    if (ComboBox13.SelectedIndex == ComboBox18.SelectedIndex && ComboBox18.SelectedIndex == ComboBox23.SelectedIndex)
                    {
                        MessageBox.Show("You win!");
                    }
                }
            }
            if (ComboBox4.SelectedIndex != -1)
            {
                if (ComboBox4.SelectedIndex == ComboBox9.SelectedIndex && ComboBox9.SelectedIndex == ComboBox14.SelectedIndex)
                {
                    if (ComboBox14.SelectedIndex == ComboBox19.SelectedIndex && ComboBox19.SelectedIndex == ComboBox24.SelectedIndex)
                    {
                        MessageBox.Show("You win!");
                    }
                }
            }
            if (ComboBox5.SelectedIndex != -1)
            {
                if (ComboBox5.SelectedIndex == ComboBox10.SelectedIndex && ComboBox10.SelectedIndex == ComboBox15.SelectedIndex)
                {
                    if (ComboBox15.SelectedIndex == ComboBox20.SelectedIndex && ComboBox20.SelectedIndex == ComboBox25.SelectedIndex)
                    {
                        MessageBox.Show("You win!");
                    }
                }
            }
            //діагоналі
            if (ComboBox1.SelectedIndex != -1)
            {
                if (ComboBox1.SelectedIndex == ComboBox7.SelectedIndex && ComboBox7.SelectedIndex == ComboBox13.SelectedIndex)
                {
                    if (ComboBox13.SelectedIndex == ComboBox19.SelectedIndex && ComboBox19.SelectedIndex == ComboBox25.SelectedIndex)
                    {
                        MessageBox.Show("You win!");
                    }
                }
            }
            if (ComboBox5.SelectedIndex != -1)
            {
                if (ComboBox5.SelectedIndex == ComboBox9.SelectedIndex && ComboBox9.SelectedIndex == ComboBox13.SelectedIndex)
                {
                    if (ComboBox13.SelectedIndex == ComboBox17.SelectedIndex && ComboBox17.SelectedIndex == ComboBox21.SelectedIndex)
                    {
                        MessageBox.Show("You win!");
                    }
                }
            }
        }
        private int player;
        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ComboBox CB = (ComboBox)e.Source;
            //ListBoxItem item = (ListBoxItem)CB.SelectedItem;
            //string Elem = item.Content.ToString();
            //MessageBox.Show(Elem);
            switch (player)
            {
                case 1:
                    sender.GetType().GetProperty("IsEnabled").SetValue(sender, false);
                    player = 2;
                    Label1.Content = "Зараз ходять нулики";
                    break;
                case 2:
                    sender.GetType().GetProperty("IsEnabled").SetValue(sender, false);
                    player = 1;
                    Label1.Content = "Зараз ходять хрестики";
                    break;

            }
            CheckWin();
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            ComboBox1.SelectedIndex = -1;
            ComboBox1.GetType().GetProperty("IsEnabled").SetValue(ComboBox1, true);
            ComboBox2.SelectedIndex = -1;
            ComboBox2.GetType().GetProperty("IsEnabled").SetValue(ComboBox2, true);
            ComboBox3.SelectedIndex = -1;
            ComboBox3.GetType().GetProperty("IsEnabled").SetValue(ComboBox3, true);
            ComboBox4.SelectedIndex = -1;
            ComboBox4.GetType().GetProperty("IsEnabled").SetValue(ComboBox4, true);
            ComboBox5.SelectedIndex = -1;
            ComboBox5.GetType().GetProperty("IsEnabled").SetValue(ComboBox5, true);
            ComboBox6.SelectedIndex = -1;
            ComboBox6.GetType().GetProperty("IsEnabled").SetValue(ComboBox6, true);
            ComboBox7.SelectedIndex = -1;
            ComboBox7.GetType().GetProperty("IsEnabled").SetValue(ComboBox7, true);
            ComboBox8.SelectedIndex = -1;
            ComboBox8.GetType().GetProperty("IsEnabled").SetValue(ComboBox8, true);
            ComboBox9.SelectedIndex = -1;
            ComboBox9.GetType().GetProperty("IsEnabled").SetValue(ComboBox9, true);
            ComboBox10.SelectedIndex = -1;
            ComboBox10.GetType().GetProperty("IsEnabled").SetValue(ComboBox10, true);
            ComboBox11.SelectedIndex = -1;
            ComboBox11.GetType().GetProperty("IsEnabled").SetValue(ComboBox11, true);
            ComboBox12.SelectedIndex = -1;
            ComboBox12.GetType().GetProperty("IsEnabled").SetValue(ComboBox12, true);
            ComboBox13.SelectedIndex = -1;
            ComboBox13.GetType().GetProperty("IsEnabled").SetValue(ComboBox13, true);
            ComboBox14.SelectedIndex = -1;
            ComboBox14.GetType().GetProperty("IsEnabled").SetValue(ComboBox14, true);
            ComboBox15.SelectedIndex = -1;
            ComboBox15.GetType().GetProperty("IsEnabled").SetValue(ComboBox15, true);
            ComboBox16.SelectedIndex = -1;
            ComboBox16.GetType().GetProperty("IsEnabled").SetValue(ComboBox16, true);
            ComboBox17.SelectedIndex = -1;
            ComboBox17.GetType().GetProperty("IsEnabled").SetValue(ComboBox17, true);
            ComboBox18.SelectedIndex = -1;
            ComboBox18.GetType().GetProperty("IsEnabled").SetValue(ComboBox18, true);
            ComboBox19.SelectedIndex = -1;
            ComboBox19.GetType().GetProperty("IsEnabled").SetValue(ComboBox19, true);
            ComboBox20.SelectedIndex = -1;
            ComboBox20.GetType().GetProperty("IsEnabled").SetValue(ComboBox20, true);
            ComboBox21.SelectedIndex = -1;
            ComboBox21.GetType().GetProperty("IsEnabled").SetValue(ComboBox21, true);
            ComboBox22.SelectedIndex = -1;
            ComboBox22.GetType().GetProperty("IsEnabled").SetValue(ComboBox22, true);
            ComboBox23.SelectedIndex = -1;
            ComboBox23.GetType().GetProperty("IsEnabled").SetValue(ComboBox23, true);
            ComboBox24.SelectedIndex = -1;
            ComboBox24.GetType().GetProperty("IsEnabled").SetValue(ComboBox24, true);
            ComboBox25.SelectedIndex = -1;
            ComboBox25.GetType().GetProperty("IsEnabled").SetValue(ComboBox25, true);
        }
    }
}
