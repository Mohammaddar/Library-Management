using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace LibraryManagement
{

    public partial class FrmEmployees : Window
    {
        const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\LibraryManagement\LibraryManagement\db\Library.mdf;Integrated Security=True;Connect Timeout=30";
        public FrmEmployees()
        {
            InitializeComponent();
            lsAllMembers.ItemsSource = getAllMembersFromDB();
        }

        private void rbBooks_Checked(object sender, RoutedEventArgs e)
        {
            if (tabEmployees != null)
            {
                tabEmployees.SelectedIndex = 0;
            }
        }

        private void rbMembers_Checked(object sender, RoutedEventArgs e)
        {
            tabEmployees.SelectedIndex = 1;
        }

        private void rbWallet_Checked(object sender, RoutedEventArgs e)
        {
            tabEmployees.SelectedIndex = 2;
        }

        private void rbInfo_Checked(object sender, RoutedEventArgs e)
        {
            tabEmployees.SelectedIndex = 3;
        }

        private void btnListMembersItemMore_Click(object sender, RoutedEventArgs e)
        {

        }

        public List<lsAllMembersItem> getAllMembersFromDB()
        {
            List<lsAllMembersItem> members = new List<lsAllMembersItem>();
            try
            {
                SqlConnection con = new SqlConnection(CONNECTION_STRING);
                con.Open();
                string qry = "select * from tblMembers";
                SqlCommand command = new SqlCommand(qry, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    members.Add(new lsAllMembersItem
                    {
                        Info0 = (int)reader["id"],
                        Info1 = (string)reader["name"],
                        Info2 = (string)reader["password"],
                        Info3 = (string)reader["email"],
                        Info4 = (string)reader["phoneNumber"],
                    });
                }
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            return members;
        }
    }
    public class lsAllMembersItem
    {
        public int Info0 { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
        public string Info4 { get; set; }
    }
}
