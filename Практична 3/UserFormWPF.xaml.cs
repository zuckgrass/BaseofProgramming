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
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Prac3
{
    /// <summary>
    /// Interaction logic for UserFormWPF.xaml
    /// </summary>
    public partial class UserFormWPF : Window
    {
        public UserFormWPF()
        {
            InitializeComponent();
            StreamReader log = new StreamReader(@"C:\Users\38099\Desktop\Роботи\Основи програмування\Prac 3\Prac3(1)\bin\Debug\Login");
            string login = log.ReadLine().Trim();
            Login.Text = login.ToString();
            log.Close();
            log.Dispose();
            dT = new DataTable("Користувачі системи");
        }
        DataTable dT; 
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            NewNameField.Text = ""; 
            NewSurnameField.Text = ""; 
            NewPasswdField.Text = ""; 
            NewPasswdField2.Text = ""; 
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }

        private void ExitFromSystem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        string Connection = @"Data Source=DESKTOP-EN4LANA; initial Catalog=Prac3; Integrated Security=True";
        private void UpdateDataBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            String newname = NewNameField.Text;
            String newsurname = NewSurnameField.Text;
            String login = Login.Text.ToString();
            String newpasswd = NewPasswdField.Text;
            String newpasswd2 = NewPasswdField2.Text;
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                string strq = "SELECT * FROM Main WHERE Login='" + Login.Text + "';";
                SqlDataAdapter Data = new SqlDataAdapter(strq, sqlConn);
                dT.Clear();
                Data.Fill(dT);
                String strQ;
                if ((newpasswd == newpasswd2) && (newpasswd != ""))
                {
                    Boolean flag = RestrictionFunc(newpasswd);
                    if (Convert.ToBoolean(dT.Rows[0][5]) == false)
                    {
                        if (flag == true)
                        {
                            strQ = "UPDATE Main SET Name='" + newname + "', ";
                            strQ += "Surname='" + newsurname + "', ";
                            strQ += "Password='" + newpasswd + "' ";
                            strQ += "WHERE Login='" + login + "';";
                            SqlCommand Com = new SqlCommand(strQ, sqlConn);
                            Com.ExecuteNonQuery();
                            MessageBox.Show("Зміни облікового запису виконані успішно!");
                        }
                        else
                            MessageBox.Show("У паролі немає літер верхнього або нижнього регістрів, або арифметичних знаків! Спробуйте знову!");
                    }
                    else
                        MessageBox.Show("Адміністратор обмежив дії цього акаунту!");
                }
                else
                {
                    MessageBox.Show("Введено пустий пароль або новий пароль повторно введено некоректно!");
                }
            }
            sqlConn.Close();
        }

        Boolean RestrictionFunc(String Pass)
        {
            int Count1, Count2, Count3;
            int LenPass = Pass.Length;
            Count1 = Count2 = Count3 = 0;
            for (int i = 0; i < LenPass; i++)
            {
                if ((Convert.ToInt32(Pass[i]) >= 65) && (Convert.ToInt32(Pass[i]) <= 65 + 25))
                    Count1++;
                if ((Convert.ToInt32(Pass[i]) >= 97) && (Convert.ToInt32(Pass[i]) <= 97 + 25))
                    Count2++;
                if ((Pass[i] == '+') || (Pass[i] == '-') || (Pass[i] == '*') || (Pass[i] == '/'))
                    Count3++;
            }
            if (Count1 * Count2 * Count3 == 0)
                return false;
            else
                return true;
        }

        private bool RestrictionFuncLogin(string login)
        {
            SqlConnection sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            string strQ1, strQ2;
            strQ1 = "SELECT Restriction FROM Main WHERE Login = '" + login + "';";
            SqlCommand Com = new SqlCommand(strQ1, sqlConn);
            Com.ExecuteNonQuery();
            strQ2 = "SELECT Status FROM Main WHERE Login = '" + login + "';";
            Com = new SqlCommand(strQ2, sqlConn);
            Com.ExecuteNonQuery();
            if (strQ1 == "0" && strQ2=="0")
                return true;
            else
                return false;
        }
    }
}
