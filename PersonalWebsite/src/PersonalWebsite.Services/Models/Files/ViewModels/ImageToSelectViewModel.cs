﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Services.Models
{
    public class ImageToSelectViewModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string PurePath { get; set; }
        public string PureThumbnailPath { get; set; }
        public string ThumbnailPath { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string UploaddedOn { get; set; }
    }
}