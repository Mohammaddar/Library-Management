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
    /// Interaction logic for FrmAddBook.xaml
    /// </summary>
    public partial class FrmAddBook : Window
    {
        FrmAdmin frmAdmin;
        public FrmAddBook(FrmAdmin frmAdmin)
        {
            InitializeComponent();
            this.frmAdmin = frmAdmin;
        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            TextBox tbBookName = (TextBox)edtBookName.Template.FindName("edt", edtBookName);
            TextBox tbGenre = (TextBox)edtGenre.Template.FindName("edt", edtGenre);
            TextBox tbPrintingNum = (TextBox)edtPrintingNum.Template.FindName("edt", edtPrintingNum);
            TextBox tbBookwriter = (TextBox)bookWriter.Template.FindName("edt", bookWriter);
            string message = "These fields are empty : ";

            if (tbBookName.Text == "")
            {
                message += "BookName ";
            }
            if (tbGenre.Text == "")
            {
                message += "Genre ";
            }
            if (tbBookwriter.Text == "")
            {
                message += "Writer ";
            }
            if (tbPrintingNum.Text == "")
            {
                message += "PrintingNum";
            }
            if (tbBookName.Text != "" && tbGenre.Text != "" && tbPrintingNum.Text != "" && tbBookwriter.Text != "")
            {
                try
                {
                    String query = "INSERT INTO tblBooks (name,writer,genre,printingNum,count) VALUES (@name,@writer,@genre, @printingnum,@count)";
                    SqlConnection con = new SqlConnection(Utils.getConnectionString());
                    con.Open();
                    SqlCommand command = new SqlCommand(query, con);
                    command.Parameters.Add("@name", tbBookName.Text);
                    command.Parameters.Add("@writer", tbBookwriter.Text);
                    command.Parameters.Add("@genre", tbGenre.Text);
                    command.Parameters.Add("@printingnum", tbPrintingNum.Text);
                    command.Parameters.Add("@count", "1");

                    command.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully added.");
                    frmAdmin.updateFrmAdmin();
                }catch(SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(message);
            }
            this.Close();



        }
        private void edt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender.GetHashCode() == ((TextBox)edtPrintingNum.Template.FindName("edt", edtPrintingNum)).GetHashCode())
            {
                TextBox tbIncreaseBalance = (TextBox)edtPrintingNum.Template.FindName("edt", edtPrintingNum);
                tbIncreaseBalance.Text = new string(tbIncreaseBalance.Text.Where(c => char.IsDigit(c)).ToArray());
            }
        }
    }
}

