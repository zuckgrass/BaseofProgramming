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
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Prac3
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
        private void AboutDev_Click(object sender, RoutedEventArgs e)
        {
            DevWindow devWindow = new DevWindow();
            Hide();
            devWindow.Show();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        DataTable dT=new DataTable();
        int count = 0;
        string Connection = @"Data Source=DESKTOP-EN4LANA; initial Catalog=Prac3; Integrated Security=True";
        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string password;
            if (Password.Visibility == Visibility.Visible)
                password = Password.Password;
            else
                password = Pass.Text;
            SqlConnection sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                String strQ = "SELECT * FROM Main WHERE Login='" + login + "';";
                SqlDataAdapter Data = new SqlDataAdapter(strQ, sqlConn);
                dT.Clear();
                try
                {
                    Data.Fill(dT);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (dT.Rows.Count == 0)
                {
                    MessageBox.Show("Такого користувача нe знайдено");
                }
                else
                {
                    bool Status = Convert.ToBoolean(dT.Rows[0][4]);
                    bool Restriction = Convert.ToBoolean(dT.Rows[0][5]);
                    if (!Status || Restriction)
                    {
                        MessageBox.Show("Цей користувач заблокований " +
                                        "aдміністратором системи!"+
                                        "Запросіть у нього дозвіл!");
                    }
                    else
                    {
                        if ((dT.Rows[0][2].ToString() == login) && (dT.Rows[0][3].ToString() == password))
                        {
                            if (login == "ADMIN")
                            {
                                Administration ad = new Administration();
                                Hide();
                                ad.Show();
                            }
                            else
                            {
                                StreamWriter log=new StreamWriter("Login");
                                log.WriteLine(login);
                                log.Close();
                                UserFormWPF userFormWPF = new UserFormWPF();
                                Hide();
                                userFormWPF.Show();
                            }
                        }
                        else
                        {
                            count++;
                            Password.Password = "";
                            String s = "Невірно введений пароль! " +
                            "Помилкове введення No" + count;
                            MessageBox.Show(s);
                            if (count == 3)
                                System.Windows.Application.Current.Shutdown();
                        }
                    }
                }
            }
            sqlConn.Close();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Registration regWindow = new Registration();
            Hide();
            regWindow.Show();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Open.Visibility=Visibility.Hidden;
            Close.Visibility=Visibility.Visible;
            Password.Password=Pass.Text;
            Pass.Visibility=Visibility.Hidden;
            Password.Visibility=Visibility.Visible;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close.Visibility=Visibility.Hidden;
            Open.Visibility=Visibility.Visible;
            Pass.Text = Password.Password;
            Pass.Visibility=Visibility.Visible;
            Password.Visibility = Visibility.Hidden;
        }
    }
}

