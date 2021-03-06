﻿using System;
using System.IO;

namespace WallpaperLoader
{
  public class Replicator
  {
    private readonly ImageStorage _source;
    private readonly ImageStorage _destination;

    public Replicator(ImageStorage source, ImageStorage destination)
    {
      this._source = source;
      this._destination = destination;
    }

    public void Start()
    {
      foreach (Images image in this._source.Images)
      {
        Images itemSource = image;
        if (!this._destination.Images.Exists((Predicate<Images>) (x => x.FileName == itemSource.FileName)) && !itemSource.NoImage && (itemSource.Weight > 1000 && itemSource.Weight > itemSource.Height) && !this._destination.Images.Exists((Predicate<Images>) (x => x.Hash == itemSource.Hash)))
          File.Copy(itemSource.DestPath, this._destination.SourceDirectory + "/" + itemSource.FileNameWithExt);
      }
    }
  }
}
