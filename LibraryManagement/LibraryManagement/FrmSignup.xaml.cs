using Microsoft.Win32;
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

namespace LibraryManagement
{
    /// <summary>
    /// Interaction logic for FrmSignup.xaml
    /// </summary>
    public partial class FrmSignup : Window
    {
        const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\LibraryManagement\LibraryManagement\db\Library.mdf;Integrated Security=True;Connect Timeout=30";
        byte[] imageBytes = null;
        public FrmSignup()
        {
            InitializeComponent();
            btnProfile.Content = new BitmapImage(new Uri(@"/LibraryManagement;component/Images/books.png", UriKind.Relative));
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            TextBox tbUserName = (TextBox)edtUserName.Template.FindName("edt", edtUserName);
            PasswordBox tbPassword = (PasswordBox)edtPassword.Template.FindName("edt", edtPassword);
            TextBox tbEmail = (TextBox)edtEmail.Template.FindName("edt", edtEmail);
            TextBox tbPhoneNum = (TextBox)edtPhoneNum.Template.FindName("edt", edtPhoneNum);
            Member member = new Member(tbUserName.Text, tbPassword.Password, tbEmail.Text, tbPhoneNum.Text, imageBytes, "2021/07/06", "2021/07/06", "0");
            AddMemberToDB(member);
        }

        private void btnSetPic_Click(object sender, RoutedEventArgs e)
        {
            imageBytes = readImage();
        }

        public void AddMemberToDB(Member member)
        {
            string qry;
            if (imageBytes!=null)
            {
                qry = "insert into tblMembers(name,password,email,phoneNumber,picture,membershipDate,lastPayDate,balance) " +
                    "values(@name,@pass,@email,@phone,@pic,@memDate,@lastPayDate,@balance)";
            }
            else
            {
                qry = "insert into tblMembers(name,password,email,phoneNumber,membershipDate,lastPayDate,balance) " +
                    "values(@name,@pass,@email,@phone,@memDate,@lastPayDate,@balance)";
            }
            try
            {
                SqlConnection con = new SqlConnection(CONNECTION_STRING);
                SqlCommand command = new SqlCommand(qry, con);
                new SqlParameter("@name", member.name);
                command.Parameters.Add(new SqlParameter("@name", member.name));
                command.Parameters.Add(new SqlParameter("@pass", member.password));
                command.Parameters.Add(new SqlParameter("@email", member.email));
                command.Parameters.Add(new SqlParameter("@phone", member.phoneNumber));
                command.Parameters.Add(new SqlParameter("@memDate", member.membershipDate));
                command.Parameters.Add(new SqlParameter("@lastPayDate", member.lastPaymentDate));
                command.Parameters.Add(new SqlParameter("@balance", member.balance));
                if (imageBytes != null)
                {
                    command.Parameters.Add(new SqlParameter("@pic", imageBytes));
                }
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException ex)
            {
                foreach (var er in ex.Errors)
                {
                    if (er.ToString().Contains("IX_MemName"))
                    {
                        MessageBox.Show("This User Name has been taken");
                    }else if (er.ToString().Contains("IX_MemEmail"))
                    {
                        MessageBox.Show("There is already an account with this email");
                    }
                    else if(er.ToString().Contains("IX_MemPhone"))
                    {
                        MessageBox.Show("There is already an account with this phone number");
                    }
                }
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

    }

}
