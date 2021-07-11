using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace LibraryManagement
{
    //
    public partial class FrmEmployees : Window
    {
        byte[] imageBytes = null;

        const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\LibraryManagement\LibraryManagement\db\Library.mdf;Integrated Security=True;Connect Timeout=30";
        private lsAllEmployeesItem employee;
        public FrmEmployees(lsAllEmployeesItem Employee)
        {
            employee = Employee;
            InitializeComponent();
            lsAllMembers.ItemsSource = getAllMembersFromDB();
            lblEmployeeName.Content = Employee.Info1;
            lblEmployeeWalletBalance.Content = Employee.Info7 + "$";
            lsAllBooks.ItemsSource = GetAllBooksFromDB();
            lsBorrowedBooks.ItemsSource = GetAllBorrowingsFromDB();
            edtEmail.Text = employee.Info3;
            edtUserName.Text = employee.Info1;
            edtPhoneNumber.Text = employee.Info4;
            lsAvailableBooks.ItemsSource = GetAvailablebooksFromDB();
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
        public List<lsAllBorrowingsItem> GetAllBorrowingsFromDB()
        {
            List<lsAllBorrowingsItem> borrowings = new List<lsAllBorrowingsItem>();
            try
            {
                SqlConnection con = new SqlConnection(CONNECTION_STRING);
                con.Open();
                string qry = "select * from tblBorrowings";
                SqlCommand command = new SqlCommand(qry, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    borrowings.Add(new lsAllBorrowingsItem()
                    {
                        Info0 = (int)reader.GetInt32(0),
                        Info1 = (string)reader.GetString(1),
                        Info2 = (string)reader.GetString(2),
                        Info3 = (string)reader.GetString(3),
                        Info4 = (string)reader.GetString(4),


                    });
                }
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            return borrowings;
        }
        public List<lsAllBooksItem> GetAllBooksFromDB()
        {
            List<lsAllBooksItem> books = new List<lsAllBooksItem>();
            try
            {
                SqlConnection con = new SqlConnection(CONNECTION_STRING);
                con.Open();
                string qry = "select * from tblBooks";
                SqlCommand command = new SqlCommand(qry, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    books.Add(new lsAllBooksItem
                    {
                        Info0 = (int)reader.GetInt32(0),
                        Info1 = (string)reader.GetString(1),
                        Info2 = (string)reader.GetString(2),
                        Info3 = (string)reader.GetString(3),
                        Info4 = (string)reader.GetString(4),
                        Info5 = reader.GetInt32(5)

                    });
                }
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            return books;
        }
        public List<lsAllBooksItem> GetAvailablebooksFromDB()
        {
            List<lsAllBooksItem> books = new List<lsAllBooksItem>();
            try
            {
                SqlConnection con = new SqlConnection(CONNECTION_STRING);
                con.Open();
                string qry = "select * from tblBooks where count>0";
                SqlCommand command = new SqlCommand(qry, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    books.Add(new lsAllBooksItem
                    {
                        Info0 = (int)reader.GetInt32(0),
                        Info1 = (string)reader.GetString(1),
                        Info2 = (string)reader.GetString(2),
                        Info3 = (string)reader.GetString(3),
                        Info4 = (string)reader.GetString(4),
                        Info5 = reader.GetInt32(5)

                    });
                }
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            return books;
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

        private void BtnApplyChanges_OnClick(object sender, RoutedEventArgs e)
        {

            TextBox tbUserName = (TextBox)edtUserName.Template.FindName("edtEditableRoundedTextBox", edtUserName);
            PasswordBox tbPassword = (PasswordBox)edtPassword.Template.FindName("edt", edtPassword);
            TextBox tbphonenumber = (TextBox)edtPhoneNumber.Template.FindName("edtEditableRoundedTextBox", edtPhoneNumber);
            TextBox tbemail = (TextBox)edtEmail.Template.FindName("edtEditableRoundedTextBox", edtEmail);

            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            con.Open();


            if (tbPassword.Password == employee.Info2)
            {
                if (checkName(tbUserName.Text))
                {
                    string qry = "update tblEmployees set name='" + tbUserName.Text + "' where name='" + employee.Info1 + "'";
                    SqlCommand command = new SqlCommand(qry, con);
                    command.ExecuteNonQuery();

                }
                
                if (checkPhoneNumber(tbphonenumber.Text))
                {
                    string qry = "update tblEmployees set phoneNumber='" + tbphonenumber.Text + "' where name='" + employee.Info1 + "'";
                    SqlCommand command = new SqlCommand(qry, con);
                    command.ExecuteNonQuery();
                }
                
                if (checkMail(tbemail.Text))
                {
                    string qry = "update tblEmployees set email='" + tbemail.Text + "' where name='" + employee.Info1 + "'";
                    SqlCommand command = new SqlCommand(qry, con);
                    command.ExecuteNonQuery();
                }

                if (imageBytes != null)
                {
                    string qry = "UPDATE tblEmployees SET picture=@pic where name='" + employee.Info1 + "'";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.CommandText = qry;
                    cmd.Parameters.AddWithValue("@pic", imageBytes);
                    cmd.ExecuteNonQuery();
                }

            }

            con.Close();







        }
        public bool checkName(string name)
        {
            string nameRegex = @"^[a-z]{3,32}$";
            Regex regex = new Regex(nameRegex);
            if (regex.IsMatch(name)) return true;
            else return false;

        }
        public bool checkMail(string email)
        {
            string emailRegex = @"^[a-zA-Z0-9_-]{1,32}@[a-zA-Z0-9]{1,8}\.[a-zA-Z]{1,3}$";
            Regex regex = new Regex(emailRegex);
            if (regex.IsMatch(email)) return true;
            else return false;

        }

        public bool checkPhoneNumber(string phone)
        {
            string phoneregex = @"^[0]{1}[9]{1}[0-9]{9}$";
            Regex regex = new Regex(phoneregex);
            if (regex.IsMatch(phone)) return true;
            else return false;

        }

        public bool checkPassword(string password)
        {
            string passwordRegex = @"^(?=.*[A-Z])[a-zA-Z0-9]{8,32}$";
            Regex regex = new Regex(passwordRegex);
            if (regex.IsMatch(password)) return true;
            else return false;

        }
        public byte[] readImage()
        {
            string path;
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Select Image",
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "image |*.png",
            };

            if (fileDialog.ShowDialog() == true)
            {
                path = fileDialog.FileName;
                FileStream imgFile = new FileStream(path, FileMode.Open, FileAccess.Read);
                byte[] imgBytes = new byte[imgFile.Length];
                imgFile.Read(imgBytes, 0, imgBytes.Length);
                imgFile.Close();
                return imgBytes;
            }
            else
            {
                return null;
            }
        }
        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            imageBytes = readImage();
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

    public class lsAllEmployeesItem
    {
        public int Info0 { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
        public string Info4 { get; set; }
        public string Info5 { get; set; }
        public string Info6 { get; set; }
        public string Info7 { get; set; }
    }
    public class lsAllBooksItem
    {
        public int Info0 { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
        public string Info4 { get; set; }
        public int Info5 { get; set; }

    }
    public class lsAllBorrowingsItem
    {
        public int Info0 { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
        public string Info4 { get; set; }


    }

}
