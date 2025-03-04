﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JS2247A5.Data
{
    public class Actor
    {
        public Actor () { 
        
        Shows = new HashSet<Show> ();
            BirthDate = new DateTime(0);
            ActorMediaItems = new HashSet<ActorMediaItem> ();
        }
        [StringLength(150)]
        public string AlternativeName { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(250)]
        public string Executive {  get; set; }

        public double Height {  get; set; }

        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string ImageUrl { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        public int ShowId {  get; set; }
        public ICollection<Show> Shows {  get; set; }

        public string Biography {  get; set; }

        public ICollection<ActorMediaItem> ActorMediaItems { get; set; }



    }
}