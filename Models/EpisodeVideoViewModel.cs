﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JS2247A5.Models
{
    public class EpisodeVideoViewModel
    {
        public int Id { get; set; }
        public string VideoContentType { get; set; }
        public byte[] Video { get; set; }
    }
}