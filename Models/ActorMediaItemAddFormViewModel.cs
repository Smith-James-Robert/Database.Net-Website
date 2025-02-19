using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JS2247A5.Models
{
    public class ActorMediaItemAddFormViewModel
    {
        [Required]
        public string Caption { get; set; }

        [Required]
        [Display(Name = "Attachment")]
        [DataType(DataType.Upload)]
        public string ContentUpload {  get; set; }

        public int ActorId {  get; set; }

        public string ActorName { get; set; }
    }
}