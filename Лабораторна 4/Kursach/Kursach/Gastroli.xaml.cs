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
using System.Data;
using System.Data.SqlClient;

namespace Kursach
{
    /// <summary>
    /// Interaction logic for Gastroli.xaml
    /// </summary>
    public partial class Gastroli : Window
    {
        public Gastroli()
        {
            InitializeComponent();
            StreamReader group = new StreamReader("Group");
            string Group = group.ReadLine().Trim();
            SqlConnection sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            string strQ1;
            strQ1 = "SELECT Name FROM Groups WHERE IDGroup = '" + Group + "'; ";
            SqlCommand Com = new SqlCommand(strQ1, sqlConn);
            Com.ExecuteNonQuery();
            lmem.Content = "Гастролі гурту " + Com.ExecuteScalar().ToString();
            group.Dispose();
            group.Close();
            InitDataTable(Group);
        }
        string Connection = @"Data Source=DESKTOP-EN4LANA; initial Catalog=Bands; Integrated Security=True";
        DataTable dT = new DataTable("Гастролі групи");
        DataTable dT1 = new DataTable("Міста гастролів групи");
        public void InitDataTable(string Group)
        {
            SqlConnection sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlDataAdapter Data = new SqlDataAdapter("SELECT Name, CONVERT(varchar, Start, 104), CONVERT(varchar, Finish, 104), AvPrice FROM Gastroli WHERE IDGroup='"+Group+"';", sqlConn);
                dT.Clear();
                Data.Fill(dT);
                dataGrid.ItemsSource = dT.DefaultView;
                SqlDataAdapter Data1 = new SqlDataAdapter("SELECT cit.Name FROM Gastroli "+
                                                          "gas LEFT JOIN GasConCit gcc "+
                                                          "ON gas.IDGastroli=gcc.IDGastroli "+
                                                          "Left JOIN City cit "+
                                                          "ON cit.IDCity=gcc.IDCity "+
                                                          "Where gas.IDGastroli='"+Group+"'; ", sqlConn);
                dT1.Clear();
                Data1.Fill(dT1);
                Cities.ItemsSource = dT1.DefaultView;
            }
            sqlConn.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw=new MainWindow();
            Hide();
            mw.Show();
        }
    }
}
