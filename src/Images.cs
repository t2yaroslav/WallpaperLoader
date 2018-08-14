// Decompiled with JetBrains decompiler
// Type: WallpaperLoader.Images
// Assembly: WallpaperLoader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 711D4775-DD50-4836-A978-55F537CC96D1
// Assembly location: C:\ProjectsMy\WallpaperLoader\Decompile\original files\WallpaperLoader.exe

using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;

namespace WallpaperLoader
{
  public class Images
  {
    private readonly string _type;
    public bool NoImage;
    private Bitmap _bitmap;
    public string DestPath;
    private string _hash;

    public Bitmap Bitmap
    {
      get
      {
        try
        {
          return this._bitmap ?? (this._bitmap = new Bitmap(this.DestPath, true));
        }
        catch (Exception ex)
        {
          this.NoImage = true;
          return (Bitmap) null;
        }
      }
    }

    public int Weight
    {
      get
      {
        Bitmap bitmap = this.Bitmap;
        if (bitmap == null)
          return 0;
        return bitmap.Width;
      }
    }

    public int Height
    {
      get
      {
        Bitmap bitmap = this.Bitmap;
        if (bitmap == null)
          return 0;
        return bitmap.Height;
      }
    }

    public string FileName
    {
      get
      {
        return Path.GetFileNameWithoutExtension(this.DestPath);
      }
    }

    public string FileExt
    {
      get
      {
        string extension = Path.GetExtension(this.DestPath);
        return string.IsNullOrWhiteSpace(extension) ? this._type : extension;
      }
    }

    public string FileNameWithExt
    {
      get
      {
        return this.FileName + "." + this.FileExt;
      }
    }

    public string Hash
    {
      get
      {
        if (this._hash == null)
          this._hash = BitConverter.ToString(new SHA256Managed().ComputeHash((byte[]) new ImageConverter().ConvertTo((object) this.Bitmap, new byte[1].GetType())));
        return this._hash;
      }
    }

    public Images(string filePath, string type)
    {
      this.DestPath = filePath;
      this._type = type;
    }
  }
}
