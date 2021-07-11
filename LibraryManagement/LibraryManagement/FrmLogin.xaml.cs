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
    /// Interaction logic for FrmLogin.xaml
    /// </summary>
    public partial class FrmLogin : Window
    {
        const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\LibraryManagement\LibraryManagement\db\Library.mdf;Integrated Security=True;Connect Timeout=30";
        public FrmLogin()
        {
            InitializeComponent();

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox tbUserName = (TextBox)edtUserName.Template.FindName("edt", edtUserName);
                PasswordBox tbPassword = (PasswordBox)edtPassword.Template.FindName("edt", edtPassword);
                if ((bool)rbAdmin.IsChecked)
                {
                    if (tbUserName.Text == "admin")
                    {
                        if (tbPassword.Password == "AdminLib123")
                        {
                            FrmAdmin frmAdmin = new FrmAdmin();
                            frmAdmin.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Username or Password is wrong.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username or Password is wrong.");

                    }
                }

                if ((bool)rbEmployee.IsChecked)
                {

                    List<lsAllEmployeesItem> lsAllEmployees = new List<lsAllEmployeesItem>();
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
                                lsAllEmployees.Add(new lsAllEmployeesItem
                                {
                                    Info0 = reader.GetInt32(0),
                                    Info1 = reader.GetString(1),
                                    Info2 = reader.GetString(2),
                                    Info3 = reader.GetString(3),
                                    Info4 = reader.GetString(4),
                                    //Info5 = reader.GetString(5),
                                    Info6 = reader.GetString(6),
                                    Info7 = reader.GetString(7)

                                });

                            }
                            reader.Close();

                        }

                        bool logined = false;
                        foreach (var employee in lsAllEmployees)
                        {
                            if (employee.Info1 == tbUserName.Text)
                            {
                                if (employee.Info2 == tbPassword.Password)
                                {
                                    logined = true;
                                    FrmEmployees frmEmployees = new FrmEmployees(employee);
                                    frmEmployees.Show();
                                    this.Close();
                                }
                            }
                        }

                        if (logined)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Username or Password is wrong.");

                        }


                    }


                }

                if ((bool)rbMember.IsChecked)
                {

                    List<lsAllMembersItem> lsAllmembers = new List<lsAllMembersItem>();
                    SqlConnection connection = new SqlConnection(CONNECTION_STRING);

                    using (connection)
                    {
                        SqlCommand command1 = new SqlCommand(
                            "SELECT * FROM tblMembers;",
                            connection);

                        connection.Open();

                        SqlDataReader reader = command1.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                lsAllmembers.Add(new lsAllMembersItem
                                {
                                    Info0 = reader.GetInt32(0),
                                    Info1 = reader.GetString(1),
                                    Info2 = reader.GetString(2),

                                });

                            }
                            reader.Close();

                        }

                        bool logined = false;
                        foreach (var member in lsAllmembers)
                        {
                            if (member.Info1 == tbUserName.Text)
                            {
                                if (member.Info2 == tbPassword.Password)
                                {
                                    logined = true;
                                    FrmMembers frmMembers = new FrmMembers(member.Info1);
                                    frmMembers.Show();
                                    this.Close();
                                }
                            }
                        }

                        if (logined)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Username or Password is wrong.");

                        }


                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

    }
}
