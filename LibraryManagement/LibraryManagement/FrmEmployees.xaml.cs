using System;
using System.Collections.Generic;
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
    /// Interaction logic for FrmEmployees.xaml
    /// </summary>
    public partial class FrmEmployees : Window
    {
        public FrmEmployees()
        {
            InitializeComponent();
            List<lsAllBooksItem> lsAllBooksItems = new List<lsAllBooksItem>();
            lsAllBooksItems.Add(new lsAllBooksItem { Info0 = 1, Info1 ="thhr", Info2 = "awfeafedaw", Info3 = "herhafd", Info4 = "awdawd" });
            lsAllBooksItems.Add(new lsAllBooksItem { Info0 = 2, Info1 ="faeeafa", Info2 = "afeaaf", Info3 = "acabrbrs", Info4 = "tbdbrbd" });
            lsAllBooksItems.Add(new lsAllBooksItem { Info0 = 3, Info1 ="urkk", Info2 = "caaevabr", Info3 = "effsefs", Info4 = "efeadwdsf" });
            lsAllBooksItems.Add(new lsAllBooksItem { Info0 = 4, Info1 ="vssegr", Info2 = "SGgrg", Info3 = "rjtr", Info4 = "awdawa" });
            lsAllBooksItems.Add(new lsAllBooksItem { Info0 = 5, Info1 ="vssegr", Info2 = "SGgrg", Info3 = "rjtr", Info4 = "awdawa" });
            lsAllBooksItems.Add(new lsAllBooksItem { Info0 = 6, Info1 ="vssegr", Info2 = "SGgrg", Info3 = "rjtr", Info4 = "awdawa" });
            lsAllBooksItems.Add(new lsAllBooksItem { Info0 = 7, Info1 ="vssegr", Info2 = "SGgrg", Info3 = "rjtr", Info4 = "awdawa" });
            lsAllBooksItems.Add(new lsAllBooksItem { Info0 = 8, Info1 = "vssegr", Info2 = "SGgrg", Info3 = "rjtr", Info4 = "awdawa" });
            lsAllBooksItems.Add(new lsAllBooksItem { Info0 = 9, Info1 = "vssegr", Info2 = "SGgrg", Info3 = "rjtr", Info4 = "awdawa" });
            lsAllBooksItems.Add(new lsAllBooksItem { Info0 = 10, Info1 = "vssegr", Info2 = "SGgrg", Info3 = "rjtr", Info4 = "awdawa" });
            lsAllBooksItems.Add(new lsAllBooksItem { Info0 = 11, Info1 = "vssegr", Info2 = "SGgrg", Info3 = "rjtr", Info4 = "awdawa" });
            lsAllBooksItems.Add(new lsAllBooksItem { Info0 = 12, Info1 = "vssegr", Info2 = "SGgrg", Info3 = "rjtr", Info4 = "awdawa" });
            lsAllBooksItems.Add(new lsAllBooksItem { Info0 = 13, Info1 = "vssegr", Info2 = "SGgrg", Info3 = "rjtr", Info4 = "awdawa" });
            lsAllBooks.ItemsSource = lsAllBooksItems;
            lsAvailableBooks.ItemsSource = lsAllBooksItems;
            lsAllMembers.ItemsSource = lsAllBooksItems;
        }

        private void rbBooks_Checked(object sender, RoutedEventArgs e)
        {
            if (tabEmployees!=null)
            {
                tabEmployees.SelectedIndex = 0;
            }
        }

        private void rbMembers_Checked(object sender, RoutedEventArgs e)
        {
            tabEmployees.SelectedIndex = 1;
        }

        private void rbWallet_Checked(object sender, RoutedEventArgs e)
        {
            tabEmployees.SelectedIndex = 2;
        }

        private void rbInfo_Checked(object sender, RoutedEventArgs e)
        {
            tabEmployees.SelectedIndex = 3;
        }

        private void btnListMembersItemMore_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    public class lsAllBooksItem
    {
        public int Info0 { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
        public string Info4 { get; set; }
    }
}
