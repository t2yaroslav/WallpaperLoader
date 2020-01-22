using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Markup;

namespace WallpaperLoader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private const string InputPath = "AppData\\Local\\Packages\\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\\LocalState\\Assets";
        private const string OutputPath = "Pictures\\Wallpapers";
        private const string TypeFile = "jpg";

        public MainWindow()
        {
            InitializeComponent();

            string fullName = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6)
                fullName = Directory.GetParent(fullName).ToString();
            string sourceDirectory = Path.Combine(fullName, "Pictures\\Wallpapers");
            new Replicator(new ImageStorage(Path.Combine(fullName, "AppData\\Local\\Packages\\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\\LocalState\\Assets"), "jpg"), new ImageStorage(sourceDirectory, "jpg")).Start();
            Application.Current.Shutdown();

        }
    }
}