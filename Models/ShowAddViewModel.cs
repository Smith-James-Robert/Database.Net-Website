using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JS2247A5.Models
{
    public class ShowAddViewModel
    {

        public ShowAddViewModel()
        {
            ActorId = new List<int>();
        }
        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Genre { get; set; }
        [Display(Name = "Image")]
        [Required]
        public string ImageUrl { get; set; }
        public ICollection<int> ActorId { get; set; }
        [DataType(DataType.MultilineText)]

        public string Premise {  get; set; }
    }
}