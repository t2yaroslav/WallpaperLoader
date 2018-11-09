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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WallpaperLoader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string InputPath = "AppData\\Local\\Packages\\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\\LocalState\\Assets";
        private const string OutputPath = "Pictures\\Wallpapers";
        private const string TypeFile = "jpg";

        public MainWindow()
        {
            InitializeComponent();
            var fullName = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6) fullName = Directory.GetParent(fullName).ToString();

            var inputStorage = new ImageStorage(System.IO.Path.Combine(fullName, InputPath), TypeFile);
            var outputStorage = new ImageStorage(System.IO.Path.Combine(fullName, OutputPath), TypeFile);

            new Replicator(inputStorage, outputStorage).Start();
            Application.Current.Shutdown();
        }
    }
}