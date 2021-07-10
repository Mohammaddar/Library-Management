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
            string path;
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Select Image",
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "image |*.png",
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

        public static BitmapImage BytesToImage(byte[] array)
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

    }
}
