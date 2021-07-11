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
using Ap_Project_supplementry;

namespace LibraryManagement
{
    /// <summary>
    /// Interaction logic for FrmAddBook.xaml
    /// </summary>
    public partial class FrmAddBook : Window
    {
        const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\LibraryManagement\LibraryManagement\db\Library.mdf;Integrated Security=True;Connect Timeout=30";

        public FrmAddBook()
        {
            InitializeComponent();
        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            TextBox tbBookName = (TextBox)edtBookName.Template.FindName("edt", edtBookName);
            TextBox tbGenre = (TextBox)edtGenre.Template.FindName("edt", edtGenre);
            TextBox tbPrintingNum = (TextBox)edtPrintingNum.Template.FindName("edt", edtPrintingNum);
            TextBox tbBookwriter = (TextBox)bookWriter.Template.FindName("edt", bookWriter);
            string message = "These fields are empty : ";

            if (tbBookName.Text=="")
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
            if (tbBookName.Text!="" && tbGenre.Text != "" && tbPrintingNum.Text != "" && tbBookwriter.Text != "")
            {
                String query = "INSERT INTO tblBooks (name,writer,genre,printingNum,count) VALUES (@name,@writer,@genre, @printingnum,@count)";
                SqlConnection con = new SqlConnection(CONNECTION_STRING);
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
            }
            else
            {
                MessageBox.Show(message);
            }
                FrmAdmin frmAdmin = new FrmAdmin();
                frmAdmin.Show();
                this.Close();



        }
            
        }
    }

