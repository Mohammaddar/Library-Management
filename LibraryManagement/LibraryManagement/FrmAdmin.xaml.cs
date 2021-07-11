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
        const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\LibraryManagement\LibraryManagement\db\Library.mdf;Integrated Security=True;Connect Timeout=30";
        private string balance;
        public FrmAdmin()
        {
            try
            {
                InitializeComponent();
                List<lsAllMembersItem> lsAllBooksItems = new List<lsAllMembersItem>();
                List<lsAllMembersItem> lsAllMembersItems = new List<lsAllMembersItem>();
                SqlConnection connection = new SqlConnection(CONNECTION_STRING);
                balance = "";
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
                        reader.Close();

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
                        reader.Close();
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
                        reader.Close();
                    }


                }

                lsEmployees.ItemsSource = lsAllMembersItems;
                lsBooks.ItemsSource = lsAllBooksItems;
                lblLibraryBlalnce.Content = balance + "$";
                employeeslist = lsAllMembersItems;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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
            const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\LibraryManagement\LibraryManagement\db\Library.mdf;Integrated Security=True;Connect Timeout=30";

            ListBox lsAllEmployees_inner = (ListBox)lsEmployees.Template.FindName("EmployeesListbox", lsEmployees);
            try
            {
                int removed_index = lsAllEmployees_inner.SelectedIndex;
                SqlConnection con = new SqlConnection(CONNECTION_STRING);
                con.Open();

                string qry = "DELETE FROM tblEmployees WHERE id='" + employeeslist[removed_index].Info0 + "'";
                SqlCommand command = new SqlCommand(qry, con);
                command.ExecuteNonQuery();
                con.Close();

                //set the table after remove

                List<lsAllMembersItem> employeesList = new List<lsAllMembersItem>();
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
                            employeesList.Add(new lsAllMembersItem
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
                connection.Close();
                lsEmployees.ItemsSource = employeesList;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }


        }

        private void tabAdmin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnIncreaseBalance_Click(object sender, RoutedEventArgs e)
        {
            TextBox tbIncreaseBalance = (TextBox)edtIncreaseBalance.Template.FindName("edt", edtIncreaseBalance);
            if (tbIncreaseBalance.Text != "")
            {
                new FrmPayment(this, int.Parse(tbIncreaseBalance.Text), "admin").Show();
            }
            else
            {
                MessageBox.Show("Please specify the amount you want to increase your balance");
            }
        }

        public void updateTabWallet()
        {
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            SqlCommand command3 = new SqlCommand(
                    "SELECT * FROM tblAdmins;",
                    connection);
            connection.Open();
            SqlDataReader reader3 = command3.ExecuteReader();
            if (reader3.HasRows)
            {
                while (reader3.Read())
                {
                    lblLibraryBlalnce.Content = reader3.GetString(3);
                }
                reader3.Close();

            }
        }

        private void edt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender.GetHashCode() == ((TextBox)edtIncreaseBalance.Template.FindName("edt", edtIncreaseBalance)).GetHashCode())
            {
                TextBox tbIncreaseBalance = (TextBox)edtIncreaseBalance.Template.FindName("edt", edtIncreaseBalance);
                tbIncreaseBalance.Text = new string(tbIncreaseBalance.Text.Where(c => char.IsDigit(c)).ToArray());
            }
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPaySalaries_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int sumOfSalaries = 0;
                List<lsAllEmployeesItem> employeess = new List<lsAllEmployeesItem>();
                employeess = GetAllEmployeesfromdb();
                SqlConnection connection2 = new SqlConnection(CONNECTION_STRING);
                using (connection2)
                {
                    connection2.Open();
                    SqlCommand command3 = new SqlCommand(
                        "SELECT * FROM tblAdmins;",
                        connection2);

                    SqlDataReader reader = command3.ExecuteReader();

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
                        reader.Close();
                    }

                }
                foreach (var employee in employeess)
                {
                    sumOfSalaries += int.Parse(employee.Info6);
                }

                if (sumOfSalaries <= int.Parse(balance))
                {
                    foreach (var employee in employeess)
                    {
                        int temp = int.Parse(employee.Info6) + int.Parse(employee.Info7);

                        SqlConnection con = new SqlConnection(CONNECTION_STRING);
                        con.Open();

                        string qry = "update tblEmployees set balance='" + temp.ToString() + "' where name='" +
                                     employee.Info1 + "'";
                        SqlCommand command = new SqlCommand(qry, con);
                        command.ExecuteNonQuery();
                        con.Close();
                    }

                    SqlConnection connection = new SqlConnection(CONNECTION_STRING);
                    using (connection)
                    {
                        connection.Open();
                        SqlCommand command3 = new SqlCommand(
                            "SELECT * FROM tblAdmins;",
                            connection);

                        SqlDataReader reader = command3.ExecuteReader();

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
                            reader.Close();
                        }

                    }
                    SqlConnection connection1 = new SqlConnection(CONNECTION_STRING);

                    connection1.Open();

                    string query = "update tblAdmins set libraryBalance='" + (int.Parse(balance) - sumOfSalaries).ToString() + "' where name='" +
                                "admin" + "'";
                    SqlCommand cmd = new SqlCommand(query, connection1);
                    cmd.ExecuteNonQuery();
                    connection1.Close();
                    MessageBox.Show("Salaries Successfully Payed.");
                    SqlConnection connection4 = new SqlConnection(CONNECTION_STRING);
                    using (connection4)
                    {
                        connection4.Open();
                        SqlCommand command3 = new SqlCommand(
                            "SELECT * FROM tblAdmins;",
                            connection4);

                        SqlDataReader reader = command3.ExecuteReader();

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
                            reader.Close();
                        }

                    }
                    lblLibraryBlalnce.Content = balance + "$";
                }
                else
                {
                    MessageBox.Show("Balance is not enough.");
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private List<lsAllEmployeesItem> GetAllEmployeesfromdb()
        {

            List<lsAllEmployeesItem> employees = new List<lsAllEmployeesItem>();
            try
            {
                SqlConnection connection1 = new SqlConnection(CONNECTION_STRING);
                using (connection1)
                {
                    SqlCommand command1 = new SqlCommand(
                        "SELECT * FROM tblEmployees;",
                        connection1);

                    connection1.Open();

                    SqlDataReader reader = command1.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employees.Add(new lsAllEmployeesItem
                            {
                                Info0 = reader.GetInt32(0),
                                Info1 = reader.GetString(1),
                                Info2 = reader.GetString(2),
                                Info3 = reader.GetString(3),
                                Info4 = reader.GetString(4),
                                Info6 = reader.GetString(6),
                                Info7 = reader.GetString(7)

                            });

                        }

                        reader.Close();
                    }

                    return employees;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return employees;
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