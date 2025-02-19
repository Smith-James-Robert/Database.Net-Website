using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JS2247A5.Models
{
    public class ShowAddFormViewModel : ShowAddViewModel
    {
        public ShowAddFormViewModel() {
            ReleaseDate = DateTime.Now;
        }
        [Display(Name ="Actors")]
        public MultiSelectList ActorList { get; set; }
        [Display(Name="Genre")]
        public SelectList GenreList {  get; set; }
        public string ActorName { get; set; }
    }
}