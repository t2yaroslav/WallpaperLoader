// Decompiled with JetBrains decompiler
// Type: WallpaperLoader.MainWindow
// Assembly: WallpaperLoader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 711D4775-DD50-4836-A978-55F537CC96D1
// Assembly location: C:\ProjectsMy\WallpaperLoader\Decompile\original files\WallpaperLoader.exe

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Markup;

namespace WallpaperLoader
{
  public partial class MainWindow : Window, IComponentConnector
  {
    private bool _contentLoaded;

    public MainWindow()
    {
      string fullName = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
      if (Environment.OSVersion.Version.Major >= 6)
        fullName = Directory.GetParent(fullName).ToString();
      string sourceDirectory = Path.Combine(fullName, "Pictures\\Wallpapers");
      new Replicator(new ImageStorage(Path.Combine(fullName, "AppData\\Local\\Packages\\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\\LocalState\\Assets"), "jpg"), new ImageStorage(sourceDirectory, "jpg")).Start();
      Application.Current.Shutdown();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/WallpaperLoader;component/mainwindow.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      this._contentLoaded = true;
    }
  }
}
