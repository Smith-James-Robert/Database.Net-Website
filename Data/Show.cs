﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JS2247A5.Data
{
    public class Show
    {
        public Show()
        {
            Episodes = new HashSet<Episode>();
            Actors = new HashSet<Actor>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Coordinator { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [Required]
        [StringLength(250)]
        public string ImageUrl { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [StringLength(50)]
        public string Genre { get; set; }

        public ICollection<Episode> Episodes { get; set; }
        public ICollection<Actor> Actors { get; set; }

        public string Premise { get; set; }
    }
}