using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JS2247A5.Models
{
    public class ActorAddViewModel
    {
        [Required]
        [StringLength(150)]
        public string Name {  get; set; }

        [StringLength(150)]
        public string AlternativeName {get; set; }
        [Required]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        [Required]
        [Display(Name = "Height(m)")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        public float? Height {  get; set; }
        [Required]
        public string Executive {  get; set; }
        [Required]
        [Display(Name ="Birth Date")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate {  get; set; }

        [DataType(DataType.MultilineText)]
        public string Biography { get; set; }
    }
}