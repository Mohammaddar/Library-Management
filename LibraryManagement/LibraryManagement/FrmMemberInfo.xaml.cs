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
    /// Interaction logic for FrmMemberInfo.xaml
    /// </summary>
    public partial class FrmMemberInfo : Window
    {
        string memberName;

        public FrmMemberInfo(string memberName)
        {
            this.memberName = memberName;
            InitializeComponent();
            displayMemberInfo();
        }

        private void displayMemberInfo()
        {
            SqlConnection con = new SqlConnection(Utils.getConnectionString());
            con.Open();
            string qry = "select * from tblMembers where name=@name";
            SqlCommand command = new SqlCommand(qry, con);
            command.Parameters.Add(new SqlParameter("@name", memberName));
            SqlDataReader reader= command.ExecuteReader();
            reader.Read();
            edtUserName.Text = (string)reader["name"];
            edtPassword.Text = (string)reader["password"];
            edtEmail.Text = (string)reader["email"];
            edtPhoneNum.Text = (string)reader["phoneNumber"];
            edtMembershipDate.Text = (string)reader["membershipDate"];
            edtBalance.Text = (string)reader["balance"];
            edtUserName.Text = (string)reader["name"];
            byte[] imgBytes = (reader["picture"] == DBNull.Value) ? null : (byte[])reader["picture"];
            con.Close();
            if (imgBytes != null)
            {
                btnProfile.ApplyTemplate();
                Image imgProfile = (Image)btnProfile.Template.FindName("imgProfile", btnProfile);
                imgProfile.Source = Utils.BytesToImage(imgBytes);
            }
        }
    }
}
