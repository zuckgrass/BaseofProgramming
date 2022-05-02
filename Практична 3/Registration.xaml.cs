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
using System.Data.SqlClient;

namespace Prac3
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }
        string Connection = @"Data Source=DESKTOP-EN4LANA; initial Catalog=Prac3; Integrated Security=True";
        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            String nameReg = NameField.Text;
            String surnameReg = SurnameField.Text;
            String loginReg = loginRegField.Text;
            String passwdReg = passwdRegField.Text;
            String passwdReg2 = passwdRegField2.Text;
            String strQ;
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    if ((passwdReg == passwdReg2) && (loginReg != "") && (passwdReg != ""))
                    {
                        Boolean flag = RestrictionFunc(passwdReg);
                        if (flag == true)
                        {
                            strQ = "INSERT INTO Main ";
                            strQ += "VALUES ('" + nameReg + "', '" + surnameReg + "', '" + loginReg + "', '" + passwdReg + "', 'False', 'True'); ";
                            SqlCommand Com = new SqlCommand(strQ, sqlConn);
                            Com.ExecuteNonQuery();
                            MessageBox.Show("Обліковий запис створено успішно!");
                        }
                        else
                            MessageBox.Show("У паролі немає літер верхнього або нижнього регістрів, або арифметичних знаків! Спробуйте знову!");
                    }
                    else
                    {
                        MessageBox.Show("Обліковий запис не створено. Спробуйте ще раз!");
                    }
                }
                catch
                {
                    MessageBox.Show("Користувач з таким логіном вже існує у системі!");
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

    }
}
