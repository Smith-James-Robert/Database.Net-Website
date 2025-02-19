using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JS2247A5.Data
{
    public class Episode
    {

        public DateTime AirDate { get; set; }
        [Required]
        [StringLength(250)]
        public string Clerk { get; set; }

        public int EpisodeNumber { get; set; }
        [Required]
        public Genre Genre { get; set; }

        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string ImageUrl { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        public int SeasonNumber { get; set; }
        [Required]
        public Show Show {  get; set; }

        public string Premise {  get; set; }

        [StringLength(200)]
        public string VideoContentType { get; set; }
        public byte[] Video { get; set; }
    }
}