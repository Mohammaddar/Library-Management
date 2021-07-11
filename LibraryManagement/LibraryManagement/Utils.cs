using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace LibraryManagement
{
    class Utils
    {
        public static byte[] ReadImage()
        {
            try
            {
                string path;
                OpenFileDialog fileDialog = new OpenFileDialog
                {
                    InitialDirectory = @"C:\",
                    Title = "Select Image",
                    CheckFileExists = true,
                    CheckPathExists = true,
                    Filter = "png |*.png|jpg |*.jpg|jpeg |*.jpeg",
                };

                if (fileDialog.ShowDialog() == true)
                {
                    path = fileDialog.FileName;
                    FileStream imgFile = new FileStream(path, FileMode.Open, FileAccess.Read);
                    byte[] imgBytes = new byte[imgFile.Length];
                    imgFile.Read(imgBytes, 0, imgBytes.Length);
                    imgFile.Close();
                    return imgBytes;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\LibraryManagement\LibraryManagement\db\Library.mdf;Integrated Security=True;Connect Timeout=30";
        public static BitmapImage BytesToImage(byte[] array)
        {
            try
            {
                if (array == null)
                    return null;
                MemoryStream ms = new System.IO.MemoryStream(array);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string getConnectionString()
        {
            return CONNECTION_STRING;
        }
    }
}
