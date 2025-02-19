using JS2247A5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JS2247A5.Models
{
    public class ShowWithDetailViewModel :ShowBaseViewModel
    {

        public ShowWithDetailViewModel() {
        Episodes = new List<Episode>();
        Actors = new List<Actor>();
        }
        public IEnumerable<Episode> Episodes { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }
}