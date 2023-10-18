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

namespace Image
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            Photos photos = new Photos();

            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                photos.photo = File.ReadAllBytes(openFileDialog.FileName);
                TestImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                Connection.kamillaLoxBaseEntities.Photos.Add(photos);
                Connection.kamillaLoxBaseEntities.SaveChanges();
            }

        }
    }
}
