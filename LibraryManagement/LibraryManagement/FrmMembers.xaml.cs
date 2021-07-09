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
    public partial class FrmMembers : Window
    {
        const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\LibraryManagement\LibraryManagement\db\Library.mdf;Integrated Security=True;Connect Timeout=30";
        const double MONTHLY_MEMBERSHIP_FEE = 50;
        string memberName = "hamid2";
        Member member;
        List<fourParameterLsItem> lsAllBooksItems;
        List<fourParameterLsItem> lsMyBooksItems;

        public FrmMembers()
        {
            InitializeComponent();
            updateTabAllBooks();
            updateTabMyBooks();
            getMemberInfoFromDB();
            lblMemberName.Content = member.name;
        }
        public FrmMembers(string memberName)
        {
            InitializeComponent();
            updateTabAllBooks();
            updateTabMyBooks();
            this.memberName = memberName;
            lblMemberName.Content = member.name;
        }


        private void rbAllBooks_Checked(object sender, RoutedEventArgs e)
        {
            if (tabMembers != null)
            {
                tabMembers.SelectedIndex = 0;
                boxSearch.Visibility = Visibility.Visible;
                updateTabAllBooks();
            }
        }
        private void rbMyBooks_Checked(object sender, RoutedEventArgs e)
        {
            tabMembers.SelectedIndex = 1;
            boxSearch.Visibility = Visibility.Hidden;
            updateTabMyBooks();
        }
        private void rbMembership_Checked(object sender, RoutedEventArgs e)
        {
            tabMembers.SelectedIndex = 2;
            boxSearch.Visibility = Visibility.Hidden;
            updateTabMembership();
        }
        private void rbWallet_Checked(object sender, RoutedEventArgs e)
        {
            tabMembers.SelectedIndex = 3;
            boxSearch.Visibility = Visibility.Hidden;
            updateTabWallet();
        }
        private void rbInfo_Checked(object sender, RoutedEventArgs e)
        {
            tabMembers.SelectedIndex = 4;
            boxSearch.Visibility = Visibility.Hidden;
            updateTabInfo();
        }


        private void btnRenewMembership_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(member.balance) >= MONTHLY_MEMBERSHIP_FEE)
            {
                SqlConnection con = new SqlConnection(CONNECTION_STRING);
                con.Open();
                string qry = "update tblMembers set lastPayDate=@lastPayDate ,balance=balance-@amount,spareDays=@remainingDays where name=@memberName";
                SqlCommand command = new SqlCommand(qry, con);
                command.Parameters.Add(new SqlParameter("@lastPayDate", DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day));
                command.Parameters.Add(new SqlParameter("@amount", MONTHLY_MEMBERSHIP_FEE));
                string[] s = member.lastPaymentDate.Split('/');
                DateTime today = DateTime.Now;
                DateTime lastPayDate = new DateTime(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]));
                int remainingDays = (30 + member.spareDays) - (int)Math.Floor((today - lastPayDate).TotalDays);
                command.Parameters.Add(new SqlParameter("@remainingDays", (remainingDays < 0) ? 0 : remainingDays));
                command.Parameters.Add(new SqlParameter("@memberName", memberName));
                command.ExecuteNonQuery();
                con.Close();
                updateTabMembership();
                MessageBox.Show("Operation finished successfuly");
            }
            else
            {
                string messageBoxText = "There isn't " + MONTHLY_MEMBERSHIP_FEE + " dollars in your wallet. Do you want to increase wallet balance?";
                string caption = "Not Enough Money";
                if (MessageBox.Show(messageBoxText, caption, MessageBoxButton.YesNo, MessageBoxImage.Error, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    new FrmPayment(this, (int)Math.Ceiling(MONTHLY_MEMBERSHIP_FEE - double.Parse(member.balance)), "member", memberName).Show();
                }
            }
        }
        private void btnIncreaseBalance_Click(object sender, RoutedEventArgs e)
        {
            TextBox tbIncreaseBalance = (TextBox)edtIncreaseBalance.Template.FindName("edt", edtIncreaseBalance);
            if (tbIncreaseBalance.Text != "")
            {
                new FrmPayment(this, int.Parse(tbIncreaseBalance.Text), "member", memberName).Show();
            }
            else
            {
                MessageBox.Show("Please specify the amount you want to increase your balance");
            }
        }
        private void btnApplyChanges_Click(object sender, RoutedEventArgs e)
        {
            TextBox tbUserName = (TextBox)edtUserName.Template.FindName("edtEditableRoundedTextBox", edtUserName);
            TextBox tbEmail = (TextBox)edtEmail.Template.FindName("edtEditableRoundedTextBox", edtEmail);
            TextBox tbPhoneNumber = (TextBox)edtPhoneNumber.Template.FindName("edtEditableRoundedTextBox", edtPhoneNumber);
            PasswordBox pbPassword = (PasswordBox)edtPassword.Template.FindName("edt", edtPassword);
            if (tbUserName.Text == "")
            {
                MessageBox.Show("User Name can not be empty");
                return;
            }
            if (tbEmail.Text == "")
            {
                MessageBox.Show("Email can not be empty");
                return;
            }
            if (tbPhoneNumber.Text == "")
            {
                MessageBox.Show("Phone Number can not be empty");
                return;
            }
            if (pbPassword.Password == "")
            {
                MessageBox.Show("Password can not be empty");
                return;
            }
            updateMemberInDB(tbUserName.Text, tbEmail.Text, tbPhoneNumber.Text, pbPassword.Password);
        }
        private void btnSetPic_Click(object sender, RoutedEventArgs e)
        {
            byte[] newImg = Utils.ReadImage();
            member.picture = (newImg == null) ? member.picture : newImg;
            updateProfilePic();
        }
        private void btnBorrow_Click(object sender, RoutedEventArgs e)
        {
            ListBox lsAllBooks_inner = (ListBox)lsAllBooks.Template.FindName("lsAllBooks", lsAllBooks);
            if (lsAllBooks_inner.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a book");
                return;
            }
            if (int.Parse(lsAllBooksItems[lsAllBooks_inner.SelectedIndex].Info4) > 0)
            {
                if (hasPermissionToBorrow())
                {
                    addBorrowingToDB(lsAllBooksItems[lsAllBooks_inner.SelectedIndex].Info1);
                    updateTabAllBooks();
                    MessageBox.Show("You borrowed this books successfuly");
                }
            }
            else
            {
                MessageBox.Show("This book is not available");
            }
        }
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            ListBox lsMyBooks_inner = (ListBox)lsMyBooks.Template.FindName("lsMyBooks", lsMyBooks);
            int index = lsMyBooks_inner.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Please select a book");
                return;
            }
            string[] s = lsMyBooksItems[index].Info4.Split('/');
            DateTime today = DateTime.Now;
            DateTime returnDate = new DateTime(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]));
            int daysToReturn = (int)(returnDate - today).TotalDays;
            if (daysToReturn < 0)///delayed
            {
                if (int.Parse(member.balance) >= (-daysToReturn))
                {
                    payPenalty(-daysToReturn);
                    returnBook(lsMyBooksItems[index].Info1);
                }
                else
                {
                    string messageBoxText = "You have to increase your balance to pay delay penalty. Do you want to do it now?";
                    string caption = "Delay penalty";
                    if (MessageBox.Show(messageBoxText, caption, MessageBoxButton.YesNo, MessageBoxImage.Error, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        new FrmPayment(this, (-daysToReturn) - int.Parse(member.balance), "member", memberName).Show();
                    }
                }
            }
            else
            {
                returnBook(lsMyBooksItems[index].Info1);
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
        private void edtEditableRoundedTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (sender.GetHashCode() == ((TextBox)edtPhoneNumber.Template.FindName("edtEditableRoundedTextBox", edtPhoneNumber)).GetHashCode())
            {
                TextBox tbPhoneNumber = (TextBox)edtPhoneNumber.Template.FindName("edtEditableRoundedTextBox", edtPhoneNumber);
                tbPhoneNumber.Text = new string(tbPhoneNumber.Text.Where(c => char.IsDigit(c)).ToArray());
            }
        }


        private void updateTabAllBooks()
        {
            getAllBooksFromDB();
            lsAllBooks.ItemsSource = lsAllBooksItems;
            edtSearch.Text = "";
        }

        private void updateTabMyBooks()
        {
            getMyBooksFromDB();
            lsMyBooks.ItemsSource = lsMyBooksItems;
        }

        public void updateTabMembership()
        {
            getMemberInfoFromDB();
            string[] s = member.lastPaymentDate.Split('/');
            DateTime today = DateTime.Now;
            DateTime lastPayDate = new DateTime(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]));
            int remainingDays = (30 + member.spareDays) - (int)Math.Floor((today - lastPayDate).TotalDays);
            if (remainingDays < 0)
            {
                remainingDays = -remainingDays;
                lblMembershipDays.Foreground = Brushes.Red;
            }
            else
            {
                lblMembershipDays.Foreground = Brushes.Green;
            }
            lblMembershipDays.Content = remainingDays;
        }
        public void updateTabWallet()
        {
            getMemberInfoFromDB();
            lblMemberBalance.Content = member.balance + "$";
        }
        private void updateTabInfo()
        {
            edtUserName.Text = member.name;
            edtEmail.Text = member.email;
            edtPhoneNumber.Text = member.phoneNumber;
            edtPassword.Password = member.password;
            updateProfilePic();
        }
        private void updateProfilePic()
        {
            Image imgProfile = (Image)btnProfile.Template.FindName("imgProfile", btnProfile);
            if (imgProfile != null)
            {
                imgProfile.Source = Utils.BytesToImage(member.picture);
            }
        }
        public void updateMemberInDB(string newName, string newEmail, string newPhone, string newPass)
        {
            string qry;
            if (member.picture != null)
            {
                qry = "update tblMembers set name=@newName,password=@newPass,email=@newEmail,phoneNumber=@newPhone,picture=@newPic" +
                      " where name=@oldName";
            }
            else
            {
                qry = "update tblMembers set name=@newName,password=@newPass,email=@newEmail,phoneNumber=@newPhone" +
                      " where name=@oldName";
            }
            try
            {
                SqlConnection con = new SqlConnection(CONNECTION_STRING);
                SqlCommand command = new SqlCommand(qry, con);
                command.Parameters.Add(new SqlParameter("@newName", newName));
                command.Parameters.Add(new SqlParameter("@newPass", newPass));
                command.Parameters.Add(new SqlParameter("@newEmail", newEmail));
                command.Parameters.Add(new SqlParameter("@newPhone", newPhone));
                command.Parameters.Add(new SqlParameter("@oldName", memberName));
                if (member.picture != null)
                {
                    command.Parameters.Add(new SqlParameter("@newPic", member.picture));
                }
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
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


        private void getAllBooksFromDB()
        {
            List<fourParameterLsItem> books = new List<fourParameterLsItem>();

            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            string qry = "select * from tblBooks";
            SqlCommand command = new SqlCommand(qry, con);
            SqlDataReader reader = command.ExecuteReader();
            int counter = 1;
            while (reader.Read())
            {
                books.Add(new fourParameterLsItem
                {
                    Info0 = counter++,
                    Info1 = (string)reader["name"],
                    Info2 = (string)reader["writer"],
                    Info3 = (string)reader["genre"],
                    Info4 = Convert.ToString(reader["count"]),
                });
            }
            con.Close();
            lsAllBooksItems = books;
        }
        private void getMyBooksFromDB()
        {
            List<fourParameterLsItem> myBooks = new List<fourParameterLsItem>();

            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            string qry = "select tblBooks.name,tblBooks.writer,tblBorrowings.borrowingDate,tblBorrowings.returnDate from " +
                         "tblBooks inner join tblBorrowings on tblBooks.name = tblBorrowings.bookName where tblBorrowings.memberName = @memberName";
            SqlCommand command = new SqlCommand(qry, con);
            command.Parameters.Add(new SqlParameter("@memberName", memberName));
            SqlDataReader reader = command.ExecuteReader();
            int counter = 1;
            while (reader.Read())
            {
                myBooks.Add(new fourParameterLsItem
                {
                    Info0 = counter++,
                    Info1 = (string)reader["name"],
                    Info2 = (string)reader["writer"],
                    Info3 = (string)reader["borrowingDate"],
                    Info4 = (string)reader["returnDate"],
                });
            }
            con.Close();
            lsMyBooksItems = myBooks;
        }
        private void getMemberInfoFromDB()
        {
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            string qry = "select * from tblMembers where name=@memberName";
            SqlCommand command = new SqlCommand(qry, con);
            command.Parameters.Add(new SqlParameter("@memberName", memberName));
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            member = new Member((string)reader["name"], (string)reader["password"], (string)reader["email"], (string)reader["phoneNumber"],
                                       (reader["picture"] == DBNull.Value) ? null : (byte[])reader["picture"], (string)reader["membershipDate"],
                                       (string)reader["lastPayDate"], (string)reader["balance"], (int)reader["spareDays"]);
            con.Close();
        }


        private void addBorrowingToDB(string bookName)
        {
            SqlConnection con = new SqlConnection(CONNECTION_STRING);

            string qryAddBorrowing = "insert into tblBorrowings values(@bookName,@memberName,@borrowingDate,@returnDate)";
            SqlCommand commandAddBorrowing = new SqlCommand(qryAddBorrowing, con);
            commandAddBorrowing.Parameters.Add(new SqlParameter("@bookName", bookName));
            commandAddBorrowing.Parameters.Add(new SqlParameter("@memberName", memberName));
            string borrowingDate = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            commandAddBorrowing.Parameters.Add(new SqlParameter("@borrowingDate", borrowingDate));
            string returnDate = DateTime.Now.AddMonths(1).Year + "/" + DateTime.Now.AddMonths(1).Month + "/" + DateTime.Now.AddMonths(1).Day;
            commandAddBorrowing.Parameters.Add(new SqlParameter("@returnDate", returnDate));

            string qryDecreaseCount = "update tblBooks set count=count-1 where name=@bookName";
            SqlCommand commandDecreaseCount = new SqlCommand(qryDecreaseCount, con);
            commandDecreaseCount.Parameters.Add(new SqlParameter("@bookName", bookName));

            try
            {
                con.Open();
                commandAddBorrowing.ExecuteNonQuery();
                commandDecreaseCount.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void returnBook(string bookName)
        {
            SqlConnection con = new SqlConnection(CONNECTION_STRING);

            string qryRemoveBorroing = "delete from tblBorrowings where bookName=@bookName and memberName=@memberName";
            SqlCommand commandRemoveBorroing = new SqlCommand(qryRemoveBorroing, con);
            commandRemoveBorroing.Parameters.Add(new SqlParameter("@bookName", bookName));
            commandRemoveBorroing.Parameters.Add(new SqlParameter("@memberName", memberName));

            string qryInceaseCount = "update tblBooks set count=count+1 where name=@bookName";
            SqlCommand commandIncreaseCount = new SqlCommand(qryInceaseCount, con);
            commandIncreaseCount.Parameters.Add(new SqlParameter("@bookName", bookName));

            try
            {
                con.Open();
                commandRemoveBorroing.ExecuteNonQuery();
                commandIncreaseCount.ExecuteNonQuery();
                con.Close();
                updateTabMyBooks();
                MessageBox.Show("You returned the book successfuly");
            }
            catch (SqlException er)
            {
                MessageBox.Show(er.Message);
            }
        }
        private void payPenalty(int amount)
        {
            SqlConnection con = new SqlConnection(CONNECTION_STRING);

            string qryDecreaseBlance = "update tblMembers set balance = balance-@amount where name=@memberName;";
            SqlCommand commandDecreaseBalance = new SqlCommand(qryDecreaseBlance, con);
            commandDecreaseBalance.Parameters.Add(new SqlParameter("@amount", amount));
            commandDecreaseBalance.Parameters.Add(new SqlParameter("@memberName", memberName));
            try
            {
                con.Open();
                commandDecreaseBalance.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException er)
            {
                MessageBox.Show(er.Message);
            }
        }
        private bool hasPermissionToBorrow()
        {
            ///////
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            string qry = "select COUNT(*) from tblBorrowings where memberName=@memberName";
            SqlCommand command = new SqlCommand(qry, con);
            command.Parameters.Add(new SqlParameter("@memberName", memberName));
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int borrowingsCount = (int)reader[0];
            con.Close();
            if (borrowingsCount == 5)
            {
                MessageBox.Show("You have reached your limit of borrowing 5 books");
                return false;
            }
            //////
            int delayedReturnsCount = lsMyBooksItems.Where(i => (new DateTime(int.Parse(i.Info4.Split('/')[0]),
                                                                             int.Parse(i.Info4.Split('/')[1]),
                                                                             int.Parse(i.Info4.Split('/')[2])) - DateTime.Now).TotalDays < 0).Count();
            if (delayedReturnsCount > 0)
            {
                MessageBox.Show("You have already a delayed return");
                return false;
            }
            //////
            string[] s = member.lastPaymentDate.Split('/');
            DateTime today = DateTime.Now;
            DateTime lastPayDate = new DateTime(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]));
            int remainingDays = (30 + member.spareDays) - (int)Math.Floor((today - lastPayDate).TotalDays);
            if (remainingDays < 7)
            {
                MessageBox.Show("Your remaining membership days is less than 7 days");
                return false;
            }
            return true;
        }


        private class fourParameterLsItem
        {
            public int Info0 { get; set; }
            public string Info1 { get; set; }
            public string Info2 { get; set; }
            public string Info3 { get; set; }
            public string Info4 { get; set; }
        }

        private void imgSearch_Click(object sender, RoutedEventArgs e)
        {
            getAllBooksFromDB();
            TextBox tbSearch = (TextBox)edtSearch.Template.FindName("edtSearchableRoundedTextBox", edtSearch);
            string phrase = tbSearch.Text;
            if (phrase != "")
            {
                if ((bool)cbBookName.IsChecked && (bool)cbBookWriter.IsChecked)
                {
                    lsAllBooksItems = lsAllBooksItems.Where(i => i.Info1.Contains(phrase) || i.Info2.Contains(phrase)).ToList();
                }
                else if ((bool)cbBookName.IsChecked)
                {
                    lsAllBooksItems = lsAllBooksItems.Where(i => i.Info1.Contains(phrase)).ToList();
                }
                else if ((bool)cbBookWriter.IsChecked)
                {
                    lsAllBooksItems = lsAllBooksItems.Where(i => i.Info2.Contains(phrase)).ToList();
                }
                else
                {
                    lsAllBooksItems.Clear();
                }
                lsAllBooks.ItemsSource = lsAllBooksItems;
            }
            else
            {
                updateTabAllBooks();
            }
        }
    }
}
