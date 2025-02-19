using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JS2247A5.Models
{
    public class EpisodeBaseViewModel : EpisodeAddViewModel
    {
        public int Id {  get; set; }
        [Display(Name ="Genre")]
        public string GenreName {  get; set; }
        [Display(Name ="Show")]
        public string ShowName {  get; set; }

        public string VideoContentType {  get; set; }
    }
}