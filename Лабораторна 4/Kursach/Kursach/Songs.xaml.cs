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
using System.IO;

namespace Kursach
{
    /// <summary>
    /// Interaction logic for Songs.xaml
    /// </summary>
    public partial class Songs : Window
    {
        public Songs()
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
            lmem.Content = "Репертуар гурту " + Com.ExecuteScalar().ToString();
            InitDataTable(Group);
        }
        string Connection = @"Data Source=DESKTOP-EN4LANA; initial Catalog=Bands; Integrated Security=True";
        DataTable dT = new DataTable("Музичні групи");
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }
        public void InitDataTable(string Group)
        {
            SqlConnection sqlConn = new SqlConnection(Connection);
            sqlConn.Open();
            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                SqlDataAdapter Data = new SqlDataAdapter("SELECT Son.Name, mem.MemberName, mem1.MemberName, CONVERT(varchar, Release, 104) FROM Songs " +
                                                        "Son Left JOIN Members mem ON Son.Composer=mem.IDMember " +
                                                        "Left JOIN Members mem1 ON Son.SongWriter=mem1.IDMember " +
                                                        "WHERE Son.IDGroup='"+Group+"'; ", sqlConn);
                //dT.Clear();
                Data.Fill(dT);
                dataGrid.ItemsSource = dT.DefaultView;
            }
            sqlConn.Close();
        }

    }
}
