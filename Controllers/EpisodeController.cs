using JS2247A5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JS2247A5.Controllers
{
    public class EpisodeController : Controller
    {
        // GET: Episode
        private Manager m = new Manager();

        public ActionResult Index()
        {
            return View(m.EpisodeGetAll());

        }

        // GET: Episode/Details/5
        public ActionResult Details(int id)
        {
            return View(m.EpisodeGetById(id));

        }
        [Route("Episode/Video/{id}")]
        public ActionResult GetVideo(int id)
        {
                
            // Attempt to get the matching object
            var o = m.EpisodeVideoGetById(id);

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // TODO 9 - Return a file content result
                // Set the Content-Type header, and return the photo bytes
                return File(o.Video, o.VideoContentType);
            }
        }
    }
}
