// Decompiled with JetBrains decompiler
// Type: WallpaperLoader.App
// Assembly: WallpaperLoader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 711D4775-DD50-4836-A978-55F537CC96D1
// Assembly location: C:\ProjectsMy\WallpaperLoader\Decompile\original files\WallpaperLoader.exe

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;

namespace WallpaperLoader
{
  public class App : Application
  {
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      this.StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
    }

    [STAThread]
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public static void Main()
    {
      App app = new App();
      app.InitializeComponent();
      app.Run();
    }
  }
}
