using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\LibraryManagement\LibraryManagement\db\Library.mdf;Integrated Security=True;Connect Timeout=30";
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                SqlConnection con = new SqlConnection(CONNECTION_STRING);
                con.Open();
                string qry2 = "select * from tblEmployees where id=1006";

                SqlCommand SqlCom2 = new SqlCommand(qry2, con);
                SqlDataReader reader = SqlCom2.ExecuteReader();
                reader.Read();
                byte[] imgBytes = (byte[])reader["picture"];
                con.Close();
                img.Source = ToImage(imgBytes);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        public BitmapImage ToImage(byte[] array)
        {
            MemoryStream ms = new System.IO.MemoryStream(array);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(CONNECTION_STRING);
                con.Open();
                string qry = "insert into tblEmployees(name,password,email,phoneNumber,picture,wage,balance)" +
                    " values('hasan','@grge2424FEF','afe@gmail.com','091756359',@imgBytes,'7550','53451')";
                SqlCommand command = new SqlCommand(qry, con);

                //Read jpg into file stream, and from there into Byte array.
                FileStream imgFile = new FileStream("C:/Users/asus/Downloads/prof.png", FileMode.Open, FileAccess.Read);
                Byte[] imgBytes = new Byte[imgFile.Length];
                imgFile.Read(imgBytes, 0, imgBytes.Length);
                imgFile.Close();

                SqlParameter param = new SqlParameter("@imgBytes", imgBytes);
                command.Parameters.Add(param);
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
    }
}
