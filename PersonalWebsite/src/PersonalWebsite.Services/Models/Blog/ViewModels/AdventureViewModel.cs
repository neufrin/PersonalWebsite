﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Services.Models
{
    public class AdventureViewModel
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string Map { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int PostId { get; set; }

        public string Title { get; set; }

    }
}
