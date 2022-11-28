using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace GaleryApp
{
    public partial class MainWindow : Window
    {
        List<Image> images;
        public MainWindow()
        {
            InitializeComponent();
            images = new List<Image>();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = "image";

            int imageNumber = 0;
            while (File.Exists(path + "fileName"))
            {
                if (int.TryParse(fileName[fileName.Length - 1].ToString(), out imageNumber))
                    fileName += imageNumber.ToString();
                else
                    break;

            }

            Image image = new Image();
            var stream = new MemoryStream();
            image.SetBinding

        }
    }
}
