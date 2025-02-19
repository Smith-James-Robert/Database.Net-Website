using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JS2247A5.Models
{
    public class EpisodeAddViewModel
    {
        
        public string Name {  get; set; }
        [Display(Name = "Season")]
        [Range(1, Int32.MaxValue)]
        public int SeasonNumber { get; set; }
        [Range(1, Int32.MaxValue)]
        [Display(Name="Episode")]
        public int EpisodeNumber { get; set; }
        [Range(1, Int32.MaxValue)]
        [Display(Name ="Genre")]
        public int GenreId { get; set; }
        [Display(Name = "Date Aired")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AirDate { get; set; }
        [Display (Name = "Image Url")]
        public string ImageUrl {  get; set; }

        [Range(1, Int32.MaxValue)]
        public int ShowId { get; set; }

        public string Clerk {  get; set; }
        [DataType(DataType.MultilineText)]
        public string Premise {  get; set; }
        
        [Required]
        public HttpPostedFileBase VideoUpload { get; set; }
    }
}