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
        private lsAllEmployeesItem employee;
        List<lsAllMembersItem> allMembers;
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
            lsDelayedReturns.ItemsSource = getDelayedReturns();
            lsDelayedPays.ItemsSource = getDelayedPays();
        }

        private void rbWallet_Checked(object sender, RoutedEventArgs e)
        {
            tabEmployees.SelectedIndex = 2;
        }

        private void rbInfo_Checked(object sender, RoutedEventArgs e)
        {
            tabEmployees.SelectedIndex = 3;
            updateProfilePic();
        }

        public List<lsAllBorrowingsItem> GetAllBorrowingsFromDB()
        {
            List<lsAllBorrowingsItem> borrowings = new List<lsAllBorrowingsItem>();
            try
            {
                SqlConnection con = new SqlConnection(Utils.getConnectionString());
                con.Open();
                string qry = "select * from tblBorrowings";
                SqlCommand command = new SqlCommand(qry, con);
                SqlDataReader reader = command.ExecuteReader();
                int counter = 1;
                while (reader.Read())
                {
                    borrowings.Add(new lsAllBorrowingsItem()
                    {
                        Info0 = counter++,
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
                SqlConnection con = new SqlConnection(Utils.getConnectionString());
                con.Open();
                string qry = "select * from tblBooks";
                SqlCommand command = new SqlCommand(qry, con);
                SqlDataReader reader = command.ExecuteReader();
                int counter = 1;
                while (reader.Read())
                {
                    books.Add(new lsAllBooksItem
                    {
                        Info0 = counter++,
                        Info1 = (string)reader.GetString(1),
                        Info2 = (string)reader.GetString(2),
                        Info3 = (string)reader.GetString(3),
                        Info4 = reader.GetInt32(5)

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
                SqlConnection con = new SqlConnection(Utils.getConnectionString());
                con.Open();
                string qry = "select * from tblBooks where count>0";
                SqlCommand command = new SqlCommand(qry, con);
                SqlDataReader reader = command.ExecuteReader();
                int counter = 1;
                while (reader.Read())
                {
                    books.Add(new lsAllBooksItem
                    {
                        Info0 = counter++,
                        Info1 = (string)reader.GetString(1),
                        Info2 = (string)reader.GetString(2),
                        Info3 = (string)reader.GetString(3),
                        Info4 = reader.GetInt32(5)

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
                SqlConnection con = new SqlConnection(Utils.getConnectionString());
                con.Open();
                string qry = "select * from tblMembers";
                SqlCommand command = new SqlCommand(qry, con);
                SqlDataReader reader = command.ExecuteReader();
                int counter = 1;
                while (reader.Read())
                {
                    members.Add(new lsAllMembersItem
                    {
                        Info0 = counter++,
                        Info1 = (string)reader["name"],
                        Info2 = (string)reader["password"],
                        Info3 = (string)reader["email"],
                        Info4 = (string)reader["phoneNumber"],
                        Info7 = (string)reader["lastPayDate"],
                        Info9 = (int)reader["spareDays"],
                    });
                }
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            allMembers = members;
            return members;
        }
        private List<lsAllBorrowingsItem> getDelayedReturns()
        {
            int counter = 1;
            return GetAllBorrowingsFromDB().Where(i => !hasMoreBorrowingDays(i.Info4)).Select(i => new lsAllBorrowingsItem
            {
                Info0 = counter++,
                Info1 = i.Info1,
                Info2 = i.Info2,
                Info3 = i.Info3,
                Info4 = i.Info4,
            }).ToList();
        }
        private List<lsAllMembersItem> getDelayedPays()
        {
            int counter = 1;
            return getAllMembersFromDB().Where(i => !hasMoreMembershipDays(i.Info7, i.Info9)).Select(i => new lsAllMembersItem
            {
                Info0 = counter++,
                Info1 = i.Info1,
                Info2 = i.Info3,
                Info3 = i.Info4,
                Info4 = i.Info7,
            }).ToList();
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

        private void btnSetPic_Click(object sender, RoutedEventArgs e)
        {
            byte[] newImg = Utils.ReadImage();
            employee.Info5 = (newImg == null) ? employee.Info5 : newImg;
            updateProfilePic();
        }

        private void btnApplyChanges_Click(object sender, RoutedEventArgs e)
        {
            TextBox tbEmail = (TextBox)edtEmail.Template.FindName("edtEditableRoundedTextBox", edtEmail);
            TextBox tbPhoneNumber = (TextBox)edtPhoneNumber.Template.FindName("edtEditableRoundedTextBox", edtPhoneNumber);
            PasswordBox pbPassword = (PasswordBox)edtPassword.Template.FindName("edt", edtPassword);
            if (tbEmail.Text == "")
            {
                MessageBox.Show("Email can not be empty");
                return;
            }
            else
            if (tbPhoneNumber.Text == "")
            {
                MessageBox.Show("Phone Number can not be empty");
                return;
            }
            else
            if (pbPassword.Password == "")
            {
                MessageBox.Show("Password can not be empty");
                return;
            }
            else if (!RegexUtils.checkPassword(pbPassword.Password))
            {
                MessageBox.Show("Password is not valid");
                return;
            }
            else if (!RegexUtils.checkMail(tbEmail.Text))
            {
                MessageBox.Show("Email is not valid");
                return;
            }
            else if (!RegexUtils.checkPhoneNumber(tbPhoneNumber.Text))
            {
                MessageBox.Show("Phone Number is not valid");
                return;
            }
            updateEmployeeInDB(employee.Info1, tbEmail.Text, tbPhoneNumber.Text, pbPassword.Password);
        }
        private void btnListMembersItemMore_Click(object sender, RoutedEventArgs e)
        {
            ListBox lsAllMembers_inner = (ListBox)lsAllMembers.Template.FindName("lsAllMembers", lsAllMembers);
            int index = lsAllMembers_inner.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Please select a member");
                return;
            }
            string selectedMemberName = allMembers[index].Info1;
            new FrmMemberInfo(selectedMemberName).Show();
        }

        private void edtEditableRoundedTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (sender.GetHashCode() == ((TextBox)edtPhoneNumber.Template.FindName("edtEditableRoundedTextBox", edtPhoneNumber)).GetHashCode())
            {
                TextBox tbPhoneNumber = (TextBox)edtPhoneNumber.Template.FindName("edtEditableRoundedTextBox", edtPhoneNumber);
                tbPhoneNumber.Text = new string(tbPhoneNumber.Text.Where(c => char.IsDigit(c)).ToArray());
            }
        }

        private void updateProfilePic()
        {
            btnProfile.ApplyTemplate();
            Image imgProfile = (Image)btnProfile.Template.FindName("imgProfile", btnProfile);
            if (imgProfile != null && employee.Info5 != null)
            {
                imgProfile.Source = Utils.BytesToImage(employee.Info5);
            }
        }

        public void updateEmployeeInDB(string newName, string newEmail, string newPhone, string newPass)
        {
            MessageBox.Show(newName + " " + newEmail + " " + newPhone + " " + newPass + " ");
            string qry;
            if (employee.Info5 != null)
            {
                qry = "update tblEmployees set name=@newName,password=@newPass,email=@newEmail,phoneNumber=@newPhone,picture=@newPic" +
                      " where name=@oldName";
            }
            else
            {
                qry = "update tblEmployees set name=@newName,password=@newPass,email=@newEmail,phoneNumber=@newPhone" +
                      " where name=@oldName";
            }
            try
            {
                SqlConnection con = new SqlConnection(Utils.getConnectionString());
                SqlCommand command = new SqlCommand(qry, con);
                command.Parameters.Add(new SqlParameter("@newName", newName));
                command.Parameters.Add(new SqlParameter("@newPass", newPass));
                command.Parameters.Add(new SqlParameter("@newEmail", newEmail));
                command.Parameters.Add(new SqlParameter("@newPhone", newPhone));
                command.Parameters.Add(new SqlParameter("@oldName", employee.Info1));
                if (employee.Info5 != null)
                {
                    command.Parameters.Add(new SqlParameter("@newPic", employee.Info5));
                }
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                ///update employee
                employee.Info1 = newName;
                employee.Info2 = newPass;
                employee.Info3 = newEmail;
                employee.Info4 = newPhone;
                lblEmployeeName.Content = newName;
                ///
                MessageBox.Show("Changed successfuly");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                foreach (var er in ex.Errors)
                {
                    if (er.ToString().Contains("IX_EmpName"))
                    {
                        MessageBox.Show("This User Name has been taken");
                    }
                    else if (er.ToString().Contains("IX_EmpEmail"))
                    {
                        MessageBox.Show("There is already an account with this email");
                    }
                    else if (er.ToString().Contains("IX_EmpPhone"))
                    {
                        MessageBox.Show("There is already an account with this phone number");
                    }
                }
            }
        }
        private bool hasMoreBorrowingDays(string returnDate)
        {
            return (new DateTime(int.Parse(returnDate.Split('/')[0]),
                                 int.Parse(returnDate.Split('/')[1]),
                                 int.Parse(returnDate.Split('/')[2])) - DateTime.Now).TotalDays > 0;
        }
        private bool hasMoreMembershipDays(string lastPay, int spareDays)
        {
            string[] s = lastPay.Split('/');
            DateTime today = DateTime.Now;
            DateTime lastPayDate = new DateTime(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]));
            int remainingDays = (30 + spareDays) - (int)Math.Floor((today - lastPayDate).TotalDays);
            return remainingDays > 0;
        }

    }
    public class lsAllMembersItem
    {
        public int Info0 { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
        public string Info4 { get; set; }
        public byte[] Info5 { get; set; }
        public string Info6 { get; set; }
        public string Info7 { get; set; }
        public string Info8 { get; set; }
        public int Info9 { get; set; }
    }

    public class lsAllEmployeesItem
    {
        public int Info0 { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
        public string Info4 { get; set; }
        public byte[] Info5 { get; set; }
        public string Info6 { get; set; }
        public string Info7 { get; set; }
    }
    public class lsAllBooksItem
    {
        public int Info0 { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
        public int Info4 { get; set; }

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