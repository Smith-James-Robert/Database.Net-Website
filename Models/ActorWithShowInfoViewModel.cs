using JS2247A5.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace JS2247A5.Models
{
    public class ActorWithShowInfoViewModel :ActorBaseViewModel
    {
        public ActorWithShowInfoViewModel() {
            Shows = new List<Show>();
            ActorMediaItems = new List<ActorMediaItem>();
            Photos = new List<ActorMediaItem>();
            Documents = new List<ActorMediaItem>();
            AudioClips = new List<ActorMediaItem>();
            VideoClips = new List<ActorMediaItem>();
        }  
        public IEnumerable<Show> Shows { get; set; }

        public IEnumerable<ActorMediaItem> ActorMediaItems { get; set; }
        public IEnumerable<ActorMediaItem> Photos { get; set; }

        public IEnumerable<ActorMediaItem> Documents {  get; set; }
        public IEnumerable<ActorMediaItem> AudioClips {  get; set; }
        public IEnumerable<ActorMediaItem> VideoClips {  get; set; }





    }
}