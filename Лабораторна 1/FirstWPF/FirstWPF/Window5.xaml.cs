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
            foreach(UIElement elem in GroupButton.Children)
            {
                if(elem is Button)
                {
                    ((Button)elem).Click += Button_Click;
                }
            }
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
                else if(textButton == "+/-")
                {
                    text.Text =new DataTable().Compute(text.Text+"*(-1)", null).ToString();
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
            catch(Exception ex)
            {
                MessageBox.Show("Введіть формулу правильно");
            }
        }
    }
}
