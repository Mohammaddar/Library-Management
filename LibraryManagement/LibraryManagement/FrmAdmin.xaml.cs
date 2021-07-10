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
    /// <summary>
    /// Interaction logic for FrmAdmin.xaml
    /// </summary>
    public partial class FrmAdmin : Window
    {
        List<lsAllMembersItem> employeeslist = new List<lsAllMembersItem>();

        public FrmAdmin()
        {
            const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\LibraryManagement\LibraryManagement\db\Library.mdf;Integrated Security=True;Connect Timeout=30";
            InitializeComponent();
            List<lsAllMembersItem> lsAllBooksItems = new List<lsAllMembersItem>();
            List<lsAllMembersItem> lsAllMembersItems = new List<lsAllMembersItem>();
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            string balance = "";
            using (connection)
            {
                SqlCommand command1 = new SqlCommand(
                    "SELECT * FROM tblEmployees;",
                    connection);
                SqlCommand command2 = new SqlCommand(
                    "SELECT * FROM tblBooks;",
                    connection);
                SqlCommand command3 = new SqlCommand(
                    "SELECT * FROM tblAdmins;",
                    connection);
                connection.Open();

                SqlDataReader reader = command1.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lsAllMembersItems.Add(new lsAllMembersItem
                        {
                            Info0 = reader.GetInt32(0),
                            Info1 = reader.GetString(1),
                            Info2 = reader.GetString(3),
                            Info3 = reader.GetString(4),
                            Info4 = reader.GetString(6)
                        });

                    }
                    reader.Close();

                }
                else
                {
                    //age list khali bood to front 1 text block bezar textesham bezar nothing to show.
                }
                reader = command2.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lsAllBooksItems.Add(new lsAllMembersItem
                        {
                            Info0 = reader.GetInt32(0),
                            Info1 = reader.GetString(1),
                            Info2 = reader.GetString(2),
                            Info3 = reader.GetString(3),
                            Info4 = reader.GetString(4)
                        });

                    }
                    reader.Close();

                }
                else
                {
                    //age list khali bood to front 1 text block bezar textesham bezar nothing to show.
                }
                reader = command3.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        balance = reader.GetString(3);
                    }
                    reader.Close();

                }
                else
                {
                    //age list khali bood to front 1 text block bezar textesham bezar nothing to show.
                }


            }

            lsEmployees.ItemsSource = lsAllMembersItems;
            lsBooks.ItemsSource = lsAllBooksItems;
            lblLibraryBlalnce.Content = balance + "$";
            employeeslist = lsAllMembersItems;
        }


        private void rbEmployees_Checked(object sender, RoutedEventArgs e)
        {
            if (tabAdmin != null)
            {
                tabAdmin.SelectedIndex = 0;
            }
        }

        private void rbBooks_Checked(object sender, RoutedEventArgs e)
        {
            tabAdmin.SelectedIndex = 1;
        }

        private void rbWallet_Checked(object sender, RoutedEventArgs e)
        {
            tabAdmin.SelectedIndex = 2;
        }

        private void btnApplyChanges(object sender, RoutedEventArgs e)
        {

        }

        private void btnListEmployeesItemRemove_Click(object sender, RoutedEventArgs e)
        {
            const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\LibraryManagement\LibraryManagement\db\Library.mdf;Integrated Security=True;Connect Timeout=30";

            ListBox lsAllEmployees_inner = (ListBox)lsEmployees.Template.FindName("EmployeesListbox", lsEmployees);
            int removed_index = lsAllEmployees_inner.SelectedIndex;
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            con.Open();

            string qry = "DELETE FROM tblEmployees WHERE id='" + employeeslist[removed_index].Info0 + "'";
            SqlCommand command = new SqlCommand(qry, con);
            command.ExecuteNonQuery();
            con.Close();

            //set the table after remove

            List<lsAllMembersItem> lsAllMembersItems = new List<lsAllMembersItem>();
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            using (connection)
            {
                SqlCommand command1 = new SqlCommand(
                    "SELECT * FROM tblEmployees;",
                    connection);

                connection.Open();

                SqlDataReader reader = command1.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lsAllMembersItems.Add(new lsAllMembersItem
                        {
                            Info0 = reader.GetInt32(0),
                            Info1 = reader.GetString(1),
                            Info2 = reader.GetString(3),
                            Info3 = reader.GetString(4),
                            Info4 = reader.GetString(6)
                        });

                    }
                    reader.Close();

                }
                else
                {
                    //age list khali bood to front 1 text block bezar textesham bezar nothing to show.
                }

            }

            lsEmployees.ItemsSource = lsAllMembersItems;


        }

        private void tabAdmin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class lsEmployeesItem
    {
        public int Info0 { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
        public string Info4 { get; set; }
    }
}