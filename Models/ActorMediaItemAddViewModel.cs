using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JS2247A5.Models
{
    public class ActorMediaItemAddViewModel
    {

        public string Caption { get; set; }

        public int ActorId {  get; set; }
        [Required]
        public HttpPostedFileBase ContentUpload { get; set; }


    }
}