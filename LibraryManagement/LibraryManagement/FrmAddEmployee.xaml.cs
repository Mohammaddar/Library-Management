using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
using Microsoft.Win32;

namespace LibraryManagement
{
    /// <summary>
    /// Interaction logic for FrmAddEmployee.xaml
    /// </summary>
    public partial class FrmAddEmployee : Window
    {
        byte[] imageBytes = null;
        FrmAdmin frmAdmin;
        public FrmAddEmployee(FrmAdmin frmAdmin)
        {
            InitializeComponent();
            this.frmAdmin = frmAdmin;
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {

            TextBox tbUserName = (TextBox)edtUserName.Template.FindName("edt", edtUserName);
            PasswordBox tbPassword = (PasswordBox)edtPassword.Template.FindName("edt", edtPassword);
            TextBox tbEmail = (TextBox)edtEmail.Template.FindName("edt", edtEmail);
            TextBox tbPhoneNum = (TextBox)edtPhoneNum.Template.FindName("edt", edtPhoneNum);
            TextBox tbSalary = (TextBox)edtPhoneNum.Template.FindName("edt", edtSalary);
            bool usernameError = false;
            bool passwordError = false;
            bool phoneError = false;
            bool emailError = false;
            bool salaryError = false;
            string message = "Wrong ";
            if (RegexUtils.checkName(tbUserName.Text))
            {

            }
            else
            {
                usernameError = true;
                message += "Username ";
            }
            if (RegexUtils.checkPassword(tbPassword.Password))
            {


            }
            else
            {
                passwordError = true;
                message += "Password ";
            }
            if (RegexUtils.checkMail(tbEmail.Text))
            {

            }
            else
            {
                emailError = true;
                message += "Email ";
            }
            if (RegexUtils.checkPhoneNumber(tbPhoneNum.Text))
            {

            }
            else
            {
                phoneError = true;
                message += "PhoneNumber ";
            }
            int n;
            bool isNumeric = int.TryParse(tbSalary.Text, out n);
            if (isNumeric)
            {

            }
            else
            {
                salaryError = true;
                message += "Salary";
            }


            if (usernameError == false && passwordError == false && emailError == false && phoneError == false &&
                salaryError == false)
            {
                try
                {
                    if (imageBytes != null)
                    {
                        String query = "INSERT INTO tblEmployees (name,password,email,phoneNumber,picture,wage,balance) VALUES (@username,@password,@email, @phonenumber,@picture,@salary,@balance)";
                        SqlConnection con = new SqlConnection(Utils.getConnectionString());
                        con.Open();
                        SqlCommand command = new SqlCommand(query, con);
                        command.Parameters.Add("@username", tbUserName.Text);
                        command.Parameters.Add("@password", tbPassword.Password);
                        command.Parameters.Add("@email", tbEmail.Text);
                        command.Parameters.Add("@phonenumber", tbPhoneNum.Text);
                        command.Parameters.Add("@picture", imageBytes);
                        command.Parameters.Add("@salary", tbSalary.Text);
                        command.Parameters.Add("@balance", "0");

                        command.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Successfully added.");

                    }
                    else
                    {
                        String query = "INSERT INTO tblEmployees (name,password,email,phoneNumber,wage,balance) VALUES (@username,@password,@email, @phonenumber,@salary,@balance)";
                        SqlConnection con = new SqlConnection(Utils.getConnectionString());
                        con.Open();
                        SqlCommand command = new SqlCommand(query, con);
                        command.Parameters.Add("@username", tbUserName.Text);
                        command.Parameters.Add("@password", tbPassword.Password);
                        command.Parameters.Add("@email", tbEmail.Text);
                        command.Parameters.Add("@phonenumber", tbPhoneNum.Text);
                        command.Parameters.Add("@salary", tbSalary.Text);
                        command.Parameters.Add("@balance", "0");
                        command.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Successfully added.");
                    }
                    frmAdmin.updateFrmAdmin();
                    this.Close();
                }
                catch (SqlException ex)
                {
                    foreach (var er in ex.Errors)
                    {
                        if (er.ToString().Contains("IX_MemName"))
                        {
                            MessageBox.Show("This User Name has been taken");
                        }
                        else if (er.ToString().Contains("IX_MemEmail"))
                        {
                            MessageBox.Show("There is already an account with this email");
                        }
                        else if (er.ToString().Contains("IX_MemPhone"))
                        {
                            MessageBox.Show("There is already an account with this phone number");
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show(message);
            }
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

        private void btnSetPic_Click(object sender, RoutedEventArgs e)
        {
            imageBytes = readImage();
            btnProfile.ApplyTemplate();
            Image imgProfile = (Image)btnProfile.Template.FindName("imgProfile", btnProfile);
            if (imgProfile != null && imageBytes != null)
            {
                imgProfile.Source = Utils.BytesToImage(imageBytes);
            }
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void edt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender.GetHashCode() == ((TextBox)edtPhoneNum.Template.FindName("edt", edtPhoneNum)).GetHashCode())
            {
                TextBox tbIncreaseBalance = (TextBox)edtPhoneNum.Template.FindName("edt", edtPhoneNum);
                tbIncreaseBalance.Text = new string(tbIncreaseBalance.Text.Where(c => char.IsDigit(c)).ToArray());
            }
            if (sender.GetHashCode() == ((TextBox)edtSalary.Template.FindName("edt", edtSalary)).GetHashCode())
            {
                TextBox tbIncreaseBalance = (TextBox)edtSalary.Template.FindName("edt", edtSalary);
                tbIncreaseBalance.Text = new string(tbIncreaseBalance.Text.Where(c => char.IsDigit(c)).ToArray());
            }
        }
    }
}
