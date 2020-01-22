using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Media.Imaging;

namespace WallpaperLoader
{
  public class Images
  {
    private readonly string _type;
    public bool NoImage;
    private BitmapImage _bitmap;
    public string DestPath;
    private string _hash;

    public BitmapImage Bitmap
    {
      get
      {
        try
        {
          return this._bitmap ?? (this._bitmap = new BitmapImage(new Uri(this.DestPath)));
        }
        catch (Exception ex)
        {
          this.NoImage = true;
          return (BitmapImage) null;
        }
      }
    }

    public double Weight
    {
      get
      {
        BitmapImage bitmap = this.Bitmap;
        if (bitmap == null)
          return 0;
        return bitmap.Width;
      }
    }

    public double Height
    {
      get
      {
        BitmapImage bitmap = this.Bitmap;
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
          this._hash = "";
          // this._hash = BitConverter.ToString(new SHA256Managed().ComputeHash((byte[]) new ImageConverter().ConvertTo((object) this.Bitmap, new byte[1].GetType())));
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
