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
            if (!RegexUtils.checkName(tbUserName.Text))
            {
                MessageBox.Show("User Name is not valid");
                return;
            }else if (!RegexUtils.checkPassword(tbPassword.Password))
            {
                MessageBox.Show("Password is not valid");
                return;
            }else if (!RegexUtils.checkMail(tbEmail.Text))
            {
                MessageBox.Show("Email is not valid");
                return;
            }else if (!RegexUtils.checkPhoneNumber(tbPhoneNum.Text))
            {
                MessageBox.Show("Phone Number is not valid");
                return;
            }
            string today = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            Member member = new Member(tbUserName.Text, tbPassword.Password, tbEmail.Text, tbPhoneNum.Text, imageBytes, today, today, "0",0);
            new FrmPayment(this,50,"memberSignUp",member).Show();
        }

        private void btnSetPic_Click(object sender, RoutedEventArgs e)
        {
            imageBytes = Utils.ReadImage();
            updateProfilePic();
        }

        public void AddMemberToDB(Member member)
        {
            string qry;
            if (imageBytes != null)
            {
                qry = "insert into tblMembers(name,password,email,phoneNumber,picture,membershipDate,lastPayDate,balance,spareDays) " +
                    "values(@name,@pass,@email,@phone,@pic,@memDate,@lastPayDate,@balance,@spareDays)";
                
            }
            else
            {
                qry = "insert into tblMembers(name,password,email,phoneNumber,membershipDate,lastPayDate,balance,spareDays) " +
                    "values(@name,@pass,@email,@phone,@memDate,@lastPayDate,@balance,@spareDays)";
               
            }
            try
            {
                SqlConnection con = new SqlConnection(Utils.getConnectionString());
                SqlCommand command = new SqlCommand(qry, con);
                new SqlParameter("@name", member.name);
                command.Parameters.Add(new SqlParameter("@name", member.name));
                command.Parameters.Add(new SqlParameter("@pass", member.password));
                command.Parameters.Add(new SqlParameter("@email", member.email));
                command.Parameters.Add(new SqlParameter("@phone", member.phoneNumber));
                command.Parameters.Add(new SqlParameter("@memDate", member.membershipDate));
                command.Parameters.Add(new SqlParameter("@lastPayDate", member.lastPaymentDate));
                command.Parameters.Add(new SqlParameter("@balance", member.balance));
                command.Parameters.Add(new SqlParameter("@spareDays", member.spareDays));
                if (imageBytes != null)
                {
                    command.Parameters.Add(new SqlParameter("@pic", imageBytes));
                }
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                FrmMembers frmMembers = new FrmMembers(member.name);
                frmMembers.Show();
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

        private void edt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender.GetHashCode()==((TextBox)edtPhoneNum.Template.FindName("edt", edtPhoneNum)).GetHashCode())
            {
                TextBox tbPhoneNum = (TextBox)edtPhoneNum.Template.FindName("edt", edtPhoneNum);
                tbPhoneNum.Text = new string(tbPhoneNum.Text.Where(c => char.IsDigit(c)).ToArray());
            }
        }

        private void updateProfilePic()
        {
            Image imgProfile = (Image)btnProfile.Template.FindName("imgProfile", btnProfile);
            if (imgProfile != null && imageBytes!=null)
            {
                imgProfile.Source = Utils.BytesToImage(imageBytes);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            new FrmLogin().Show();
            this.Close();
        }
    }

}
