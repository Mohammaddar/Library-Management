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
    public partial class FrmMembers : Window
    {
        public FrmMembers()
        {
            InitializeComponent();
            List<lsAllMembersItem> lsAllBooksItems = new List<lsAllMembersItem>();
            lsAllBooksItems.Add(new lsAllMembersItem { Info0 = 1, Info1 = "thhr", Info2 = "awfeafedaw", Info3 = "herhafd", Info4 = "awdawd" });
            lsAllBooksItems.Add(new lsAllMembersItem { Info0 = 2, Info1 = "faeeafa", Info2 = "afeaaf", Info3 = "acabrbrs", Info4 = "tbdbrbd" });
            lsAllBooksItems.Add(new lsAllMembersItem { Info0 = 3, Info1 = "urkk", Info2 = "caaevabr", Info3 = "effsefs", Info4 = "efeadwdsf" });
            lsAllBooksItems.Add(new lsAllMembersItem { Info0 = 4, Info1 = "vssegr", Info2 = "SGgrg", Info3 = "rjtr", Info4 = "awdawa" });
            lsAllBooksItems.Add(new lsAllMembersItem { Info0 = 5, Info1 = "vssegr", Info2 = "SGgrg", Info3 = "rjtr", Info4 = "awdawa" });
            lsAllBooksItems.Add(new lsAllMembersItem { Info0 = 6, Info1 = "vssegr", Info2 = "SGgrg", Info3 = "rjtr", Info4 = "awdawa" });
            lsAllBooksItems.Add(new lsAllMembersItem { Info0 = 7, Info1 = "vssegr", Info2 = "SGgrg", Info3 = "rjtr", Info4 = "awdawa" });
            lsAllBooksItems.Add(new lsAllMembersItem { Info0 = 8, Info1 = "vssegr", Info2 = "SGgrg", Info3 = "rjtr", Info4 = "awdawa" });
            lsAllBooksItems.Add(new lsAllMembersItem { Info0 = 9, Info1 = "vssegr", Info2 = "SGgrg", Info3 = "rjtr", Info4 = "awdawa" });
            lsAllBooksItems.Add(new lsAllMembersItem { Info0 = 10, Info1 = "vssegr", Info2 = "SGgrg", Info3 = "rjtr", Info4 = "awdawa" });
            lsAllBooksItems.Add(new lsAllMembersItem { Info0 = 11, Info1 = "vssegr", Info2 = "SGgrg", Info3 = "rjtr", Info4 = "awdawa" });
            lsAllBooksItems.Add(new lsAllMembersItem { Info0 = 12, Info1 = "vssegr", Info2 = "SGgrg", Info3 = "rjtr", Info4 = "awdawa" });
            lsAllBooksItems.Add(new lsAllMembersItem { Info0 = 13, Info1 = "vssegr", Info2 = "SGgrg", Info3 = "rjtr", Info4 = "awdawa" });
            lsAllBooks.ItemsSource = lsAllBooksItems;
            lsMyBooks.ItemsSource = lsAllBooksItems;
        }

        private void rbAllBooks_Checked(object sender, RoutedEventArgs e)
        {
            if (tabMembers != null)
            {
                tabMembers.SelectedIndex = 0;
                boxSearch.Visibility = Visibility.Visible;
            }
        }

        private void rbMyBooks_Checked(object sender, RoutedEventArgs e)
        {
            tabMembers.SelectedIndex = 1;
            boxSearch.Visibility = Visibility.Hidden;
        }
        private void rbMembership_Checked(object sender, RoutedEventArgs e)
        {
            tabMembers.SelectedIndex = 2;
            boxSearch.Visibility = Visibility.Hidden;
        }

        private void rbWallet_Checked(object sender, RoutedEventArgs e)
        {
            tabMembers.SelectedIndex = 3;
            boxSearch.Visibility = Visibility.Hidden;
        }

        private void rbInfo_Checked(object sender, RoutedEventArgs e)
        {
            tabMembers.SelectedIndex = 4;
            boxSearch.Visibility = Visibility.Hidden;
        }

        private void btnListMembersItemMore_Click(object sender, RoutedEventArgs e)
        {

        }

    }
    public class lsMembersAllBooksItem
    {
        public int Info0 { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
        public string Info4 { get; set; }
    }
}
