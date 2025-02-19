using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JS2247A5.Data
{
    public class ActorMediaItem
    {


        public int Id { get; set; } 

        public string ContentType {  get; set; }

        public byte[] Content {  get; set; }

        public string Caption { get; set; }

        public Actor Actor { get; set; }
    }
}