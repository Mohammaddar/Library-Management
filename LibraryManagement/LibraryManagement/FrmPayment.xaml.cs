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
    public partial class FrmPayment : Window
    {
        const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\LibraryManagement\LibraryManagement\db\Library.mdf;Integrated Security=True;Connect Timeout=30";
        int amount;
        string userType;
        string memberName;
        public FrmPayment(int amount,string userType)
        {
            InitializeComponent();
            this.amount = 230;
            this.userType = userType;
            lblFee.Content = "Fee : " + amount;
        }
        public FrmPayment(int amount, string userType,string memberName)
        {
            InitializeComponent();
            this.amount = 230;
            this.userType = userType;
            this.memberName = memberName;
            lblFee.Content = "Fee : " + amount;
        }

        private void edt_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (sender.GetHashCode() == ((TextBox)edtCardNumber1.Template.FindName("edt", edtCardNumber1)).GetHashCode())//edtCardNum1 insider textBox hashCode
            {
                TextBox tbCardNum1 = (TextBox)edtCardNumber1.Template.FindName("edt", edtCardNumber1);
                tbCardNum1.Text = new string(tbCardNum1.Text.Where(c => char.IsDigit(c)).ToArray());
            }
            if (sender.GetHashCode() == ((TextBox)edtCardNumber2.Template.FindName("edt", edtCardNumber2)).GetHashCode())//edtCardNum2 insider textBox hashCode
            {
                TextBox tbCardNum2 = (TextBox)edtCardNumber2.Template.FindName("edt", edtCardNumber2);
                tbCardNum2.Text = new string(tbCardNum2.Text.Where(c => char.IsDigit(c)).ToArray());
            }
            if (sender.GetHashCode() == ((TextBox)edtCardNumber3.Template.FindName("edt", edtCardNumber3)).GetHashCode())//edtCardNum3 insider textBox hashCode
            {
                TextBox tbCardNum3 = (TextBox)edtCardNumber3.Template.FindName("edt", edtCardNumber3);
                tbCardNum3.Text = new string(tbCardNum3.Text.Where(c => char.IsDigit(c)).ToArray());
            }
            if (sender.GetHashCode() == ((TextBox)edtCardNumber4.Template.FindName("edt", edtCardNumber4)).GetHashCode())//edtCardNum1 insider textBox hashCode
            {
                TextBox tbCardNum4 = (TextBox)edtCardNumber4.Template.FindName("edt", edtCardNumber4);
                tbCardNum4.Text = new string(tbCardNum4.Text.Where(c => char.IsDigit(c)).ToArray());
            }
            if (sender.GetHashCode() == ((TextBox)edtCVV.Template.FindName("edt", edtCVV)).GetHashCode())//edtCVV insider textBox hashCode
            {
                TextBox tbCVV = (TextBox)edtCVV.Template.FindName("edt", edtCVV);
                tbCVV.Text = new string(tbCVV.Text.Where(c => char.IsDigit(c)).ToArray());
            }
            if (sender.GetHashCode() == ((TextBox)edtExpDate1.Template.FindName("edt", edtExpDate1)).GetHashCode())//edtExpDate1 insider textBox hashCode
            {
                TextBox tbExpDate1 = (TextBox)edtExpDate1.Template.FindName("edt", edtExpDate1);
                tbExpDate1.Text = new string(tbExpDate1.Text.Where(c => char.IsDigit(c)).ToArray());
            }
            if (sender.GetHashCode() == ((TextBox)edtExpDate2.Template.FindName("edt", edtExpDate2)).GetHashCode())//edtExpDate2 insider textBox hashCode
            {
                TextBox tbExpDate2 = (TextBox)edtExpDate2.Template.FindName("edt", edtExpDate2);
                tbExpDate2.Text = new string(tbExpDate2.Text.Where(c => char.IsDigit(c)).ToArray());
            }
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            if (checkCardInfo())
            {
                if (userType == "admin")
                {
                    UpdateLibraryBalanceInDB();
                }else if (userType == "member")
                {
                    UpdateMemberBalanceInDB();
                }
            }
        }

        private void UpdateLibraryBalanceInDB()
        {
            string qry;
            qry = "update tblAdmins set libraryBalance = (select libraryBalance from tblAdmins where id=1)+@amount WHERE id=1;";
            try
            {
                SqlConnection con = new SqlConnection(CONNECTION_STRING);
                SqlCommand command = new SqlCommand(qry, con);
                command.Parameters.Add(new SqlParameter("@amount", amount));
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException)
            {

            }
        }
        private void UpdateMemberBalanceInDB()
        {
            //MessageBox.Show("a");
            //string qry;
            //qry = "update tblMembers set balance = (select balance from tblMembers where name=@memberName)+@amount where name=@memberName;";
            //try
            //{
            //    SqlConnection con = new SqlConnection(CONNECTION_STRING);
            //    SqlCommand command = new SqlCommand(qry, con);
            //    command.Parameters.Add(new SqlParameter("@amount", amount));
            //    command.Parameters.Add(new SqlParameter("@memberName", memberName));
            //    con.Open();
            //    command.ExecuteNonQuery();
            //    con.Close();
            //}
            //catch (SqlException er)
            //{
            //    MessageBox.Show(er.Message);

            //}
        }

        private bool checkCardInfo()
        {
            string cardNum = ((TextBox)edtCardNumber1.Template.FindName("edt", edtCardNumber1)).Text +
                             ((TextBox)edtCardNumber2.Template.FindName("edt", edtCardNumber2)).Text +
                             ((TextBox)edtCardNumber3.Template.FindName("edt", edtCardNumber3)).Text +
                             ((TextBox)edtCardNumber4.Template.FindName("edt", edtCardNumber4)).Text;
            if (!RegexUtils.checkCardNumber(long.Parse(cardNum)))
            {
                MessageBox.Show("Please Insert a valid Card Number");
                return false;
            }
            if (!RegexUtils.checkExpiration(int.Parse(((TextBox)edtExpDate1.Template.FindName("edt", edtExpDate1)).Text),
                                           int.Parse(((TextBox)edtExpDate2.Template.FindName("edt", edtExpDate2)).Text)))
            {
                MessageBox.Show("Please Insert a valid Expiration Date");
                return false;
            }
            if (!RegexUtils.checkCvv(((TextBox)edtCVV.Template.FindName("edt", edtCVV)).Text))
            {
                MessageBox.Show("Please Insert a valid CVV");
                return false;
            }
            return true;
        }
    }
}
