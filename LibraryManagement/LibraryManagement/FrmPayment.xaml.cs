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
        FrmAdmin frmAdmin;
        FrmMembers frmMembers;
        FrmSignup frmSignup;
        int amount;
        string usageType;
        string memberName;
        Member member;
        public FrmPayment(FrmAdmin frmAdmin, int amount, string usageType)
        {
            InitializeComponent();
            this.frmAdmin = frmAdmin;
            this.amount = amount;
            this.usageType = usageType;
            lblFee.Content = "Fee : " + amount;
        }
        public FrmPayment(FrmMembers frmMembers, int amount, string usageType, string memberName)
        {
            InitializeComponent();
            this.frmMembers = frmMembers;
            this.amount = amount;
            this.usageType = usageType;
            this.memberName = memberName;
            lblFee.Content = "Fee : " + amount;
        }
        public FrmPayment(FrmSignup frmSignup, int amount, string usageType, Member member)
        {
            InitializeComponent();
            this.frmSignup = frmSignup;
            this.amount = amount;
            this.usageType = usageType;
            this.member = member;
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
                if (usageType == "admin")
                {
                    UpdateLibraryBalanceInDB();
                }
                else if (usageType == "member")
                {
                    UpdateMemberBalanceInDB();
                }
                else if (usageType == "memberSignUp")
                {
                    frmSignup.AddMemberToDB(member);
                }
                this.Close();
            }
        }

        private void UpdateLibraryBalanceInDB()
        {
            string qry;
            qry = "update tblAdmins set libraryBalance = (select libraryBalance from tblAdmins where id=1)+@amount WHERE id=1;";
            try
            {
                SqlConnection con = new SqlConnection(Utils.getConnectionString());
                SqlCommand command = new SqlCommand(qry, con);
                command.Parameters.Add(new SqlParameter("@amount", amount));
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                frmAdmin.updateTabWallet();
            }
            catch (SqlException)
            {

            }
        }
        private void UpdateMemberBalanceInDB()
        {
            string qry;
            qry = "update tblMembers set balance = balance+@amount where name=@memberName;";
            try
            {
                SqlConnection con = new SqlConnection(Utils.getConnectionString());
                SqlCommand command = new SqlCommand(qry, con);
                command.Parameters.Add(new SqlParameter("@amount", amount));
                command.Parameters.Add(new SqlParameter("@memberName", memberName));
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                frmMembers.updateTabMembership();
                frmMembers.updateTabWallet();
                MessageBox.Show("Operation finished successfuly");
            }
            catch (SqlException er)
            {
                MessageBox.Show(er.Message);

            }
        }

        private bool checkCardInfo()
        {
            string cardNum = ((TextBox)edtCardNumber1.Template.FindName("edt", edtCardNumber1)).Text +
                             ((TextBox)edtCardNumber2.Template.FindName("edt", edtCardNumber2)).Text +
                             ((TextBox)edtCardNumber3.Template.FindName("edt", edtCardNumber3)).Text +
                             ((TextBox)edtCardNumber4.Template.FindName("edt", edtCardNumber4)).Text;
            string expireYear = ((TextBox)edtExpDate1.Template.FindName("edt", edtExpDate1)).Text;
            string expireDay = ((TextBox)edtExpDate2.Template.FindName("edt", edtExpDate2)).Text;
            string cvv = ((TextBox)edtCVV.Template.FindName("edt", edtCVV)).Text;
            if (cardNum == "" || expireYear == "" || expireDay == "" || cvv == "")
            {
                MessageBox.Show("Please fill all boxes");
                return false;
            }
            if (!RegexUtils.checkCardNumber(long.Parse(cardNum)))
            {
                MessageBox.Show("Please Insert a valid Card Number");
                return false;
            }
            if (!RegexUtils.checkExpiration(int.Parse(expireYear)+2000,
                                           int.Parse((expireDay))))
            {
                MessageBox.Show("Please Insert a valid Expiration Date");
                return false;
            }
            if (!RegexUtils.checkCvv(cvv))
            {
                MessageBox.Show("Please Insert a valid CVV");
                return false;
            }
            return true;
        }
    }
}
