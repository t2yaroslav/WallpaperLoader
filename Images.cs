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
        public readonly string DestPath;
        private string _hash;

        private Bitmap Bitmap
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
                var bitmap = this.Bitmap;
                return bitmap?.Width ?? 0;
            }
        }

        public int Height
        {
            get
            {
                var bitmap = this.Bitmap;
                return bitmap?.Height ?? 0;
            }
        }

        public string FileName => Path.GetFileNameWithoutExtension(this.DestPath);

        private string FileExt
        {
            get
            {
                var extension = Path.GetExtension(this.DestPath);
                return string.IsNullOrWhiteSpace(extension) ? this._type : extension;
            }
        }

        public string FileNameWithExt => this.FileName + "." + this.FileExt;

        public string Hash
        {
            get
            {
                if (this._hash == null)
                    this._hash = BitConverter.ToString(new SHA256Managed().ComputeHash(
                        (byte[]) new ImageConverter().ConvertTo((object) this.Bitmap, new byte[1].GetType())));
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