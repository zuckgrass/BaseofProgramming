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
using System.Windows.Navigation;
using System.Data.SqlClient;
using System.Data;

namespace Prac3
{
    /// <summary>
    /// Interaction logic for Admenistration.xaml
    /// </summary>
    public partial class Administration : Window
    {
        DataBase dataBase = new DataBase();
        
        public Administration()
        {
            InitializeComponent();
            UpdateDataTable();
        }
        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            //RealAdminPasswd.Text = ""; RealAdminPasswd.IsEnabled = ;
            //NewAdminPasswd.Text = ""; NewAdminPasswd.IsEnabled = false;
            //NewAdminPasswd2.Text = ""; NewAdminPasswd2.IsEnabled = false;
            //Prev.IsEnabled = false; Next.IsEnabled = false;
            //UpdatePasswd.IsEnabled = false;
            //AddUser.IsEnabled = false;
            //CorrectStatusBtn.IsEnabled = false;
            //CorrectRestrictionBtn.IsEnabled = false;
            //dT.Clear();
            //dataGrid.ItemsSource = dT.DefaultView;
            //UsersLogins.Items.Clear();
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }

        string Connection = @"Data Source=DESKTOP-EN4LANA; initial Catalog=Prac3; Integrated Security=True";

        private void UpdatePasswd_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            String strQ;
            String NewPass = NewAdminPasswd.Text;
            String NewPass2 = NewAdminPasswd2.Text;
            if ((NewPass != "") && (NewPass == NewPass2))
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    strQ = "UPDATE Main SET Password ='" + NewPass + "'WHERE Login = 'ADMIN'; ";
                    SqlCommand Com = new SqlCommand(strQ, sqlConn);
                    Com.ExecuteNonQuery();
                    MessageBox.Show("Пароль оновлено успішно!");
                }
            }
            sqlConn.Close();
        }

        DataTable dT = new DataTable("Користувачі системи");

        public void UpdateDataTable()
        {
            SqlConnection sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlDataAdapter Data = new SqlDataAdapter("SELECT Name, Surname, Login, Status, Restriction FROM Main", sqlConn);
                dT.Clear();
                Data.Fill(dT);
                dataGrid.ItemsSource = dT.DefaultView;
            }
            int Len = dT.Rows.Count;
            UsersLogins.Items.Clear();
            for (int i = 0; i < Len; i++)
            {
                UsersLogins.Items.Add(dT.Rows[i][2].ToString());
            }
            sqlConn.Close();
        }

        int index = 0;

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            if (index > 0)
            {
                index--;
                UserNameSelected.Content = dT.Rows[index][0].ToString();
                UserSurnameSelected.Content = dT.Rows[index][1].ToString();
                UserLoginSelected.Content = dT.Rows[index][2].ToString();
                UserStatusSelected.Content = dT.Rows[index][3].ToString();
                UserRestrictionSelected.Content = dT.Rows[index][4].ToString();
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            int LenTable = dT.Rows.Count;
            if (index < LenTable - 1)
            {
                index++;
                UserNameSelected.Content = dT.Rows[index][0].ToString();
                UserSurnameSelected.Content = dT.Rows[index][1].ToString();
                UserLoginSelected.Content = dT.Rows[index][2].ToString();
                UserStatusSelected.Content = dT.Rows[index][3].ToString();
                UserRestrictionSelected.Content = dT.Rows[index][4].ToString();
            }
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            String strQ;
            String UserLogin = AddingUserLogin.Text;
            try
            {
                if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    strQ = "INSERT INTO Main (Name, Surname, Login, Status, Restriction) values('', '', '" + UserLogin + "', 1, 0); ";
                    SqlCommand Com = new SqlCommand(strQ, sqlConn);
                    Com.ExecuteNonQuery();
                }
                UpdateDataTable();
            }
            catch
            {
                MessageBox.Show("Користувача не додано! Можливо такий в базі вже є!");
            }
            sqlConn.Close();
        }

        private void CorrectStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            String strQ;
            bool UserStatus = (bool)ChangeActive.IsChecked;
            try
            {
                if (UsersLogins.SelectedValue == null)
                    MessageBox.Show("Choose user login!");
                else if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    strQ = "UPDATE Main SET Status ='" + UserStatus + "' WHERE Login='" + UsersLogins.SelectedValue.ToString() + "';";
                    SqlCommand Com = new SqlCommand(strQ, sqlConn);
                    Com.ExecuteNonQuery();
                }
                sqlConn.Close();
                UpdateDataTable();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Цей статус вже встановлено");
            }
        }

        private void CorrectRestrictionBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            String strQ;
            bool UserRestriction = (bool)ChangeRestriction.IsChecked;
            try
            {
                if (UsersLogins.SelectedValue == null)
                    MessageBox.Show("Choose user login!");
                else if (sqlConn.State == System.Data.ConnectionState.Open)
                {
                    strQ = "UPDATE Main SET Restriction ='" + UserRestriction + "' WHERE Login = '" + UsersLogins.SelectedValue.ToString() + "'; ";
                    SqlCommand Com = new SqlCommand(strQ, sqlConn);
                    Com.ExecuteNonQuery();
                }
                sqlConn.Close();
                UpdateDataTable();
            }
            catch
            {
                MessageBox.Show("Це обмеження вже встановлено");
            }
        }

        private void ExitFromSystem_Click(object sender, RoutedEventArgs e)
        {
            UserNameSelected.Content = "";
            UserSurnameSelected.Content = "";
            UserLoginSelected.Content = "";
            UserStatusSelected.Content = "";
            UserRestrictionSelected.Content = "";
            NewAdminPasswd.Text = ""; 
            NewAdminPasswd2.Text = ""; 
            dT.Clear();
            dataGrid.ItemsSource = dT.DefaultView;
            UsersLogins.Items.Clear();
            System.Windows.Application.Current.Shutdown();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Open.Visibility = Visibility.Hidden;
            Close.Visibility = Visibility.Visible;
            NewPass.Password = NewAdminPasswd.Text;
            NewAdminPasswd.Visibility = Visibility.Hidden;
            NewPass.Visibility = Visibility.Visible;
            NewPass1.Password = NewAdminPasswd2.Text;
            NewAdminPasswd2.Visibility = Visibility.Hidden;
            NewPass1.Visibility = Visibility.Visible;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close.Visibility = Visibility.Hidden;
            Open.Visibility = Visibility.Visible;
            NewAdminPasswd.Text = NewPass.Password;
            NewAdminPasswd.Visibility = Visibility.Visible;
            NewPass.Visibility = Visibility.Hidden;
            NewAdminPasswd2.Text = NewPass1.Password;
            NewAdminPasswd2.Visibility = Visibility.Visible;
            NewPass1.Visibility = Visibility.Hidden;
        }
    }        
}
