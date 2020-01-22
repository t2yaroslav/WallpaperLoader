using System.Collections.Generic;
using System.IO;

namespace WallpaperLoader
{
  public class ImageStorage
  {
    private string Type { get; set; }

    public ImageStorage(string sourceDirectory, string type)
    {
      this.SourceDirectory = sourceDirectory;
      this.Type = type;
      this.ReadImages(this.SourceDirectory);
    }

    public string SourceDirectory { get; set; }

    public List<WallpaperLoader.Images> Images { get; set; }

    private List<WallpaperLoader.Images> ReadImages(string pathDirectory)
    {
      this.Images = new List<WallpaperLoader.Images>();
      if (Directory.Exists(this.SourceDirectory))
      {
        foreach (string file in Directory.GetFiles(pathDirectory))
          this.Images.Add(new WallpaperLoader.Images(file, this.Type));
      }
      return this.Images;
    }
  }
}
