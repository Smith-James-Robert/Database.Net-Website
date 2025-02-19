using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JS2247A5.Models
{
    public class ShowBaseViewModel :ShowAddViewModel
    {
        public ShowBaseViewModel()
        {
            Actors = new List<ActorBaseViewModel>();
        }
        public int Id { get; set; }

        public string Coordinator { get; set; }

        public IEnumerable<ActorBaseViewModel> Actors { get; set; }

    }
}