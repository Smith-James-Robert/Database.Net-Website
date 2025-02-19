using JS2247A5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JS2247A5.Controllers
{
    public class ActorController : Controller
    {
        // GET: Actor
        private Manager m = new Manager();

        public ActionResult Index()
        {
            return View(m.ActorGetAll());

        }

        // GET: Actor/Details/5
        public ActionResult Details(int id)
        {
            var form = m.ActorGetWithShowInfo(id);
            form.VideoClips = form.ActorMediaItems.Where(actor => actor.ContentType.Contains("video")).OrderBy(actor=>actor.Caption);
            form.AudioClips = form.ActorMediaItems.Where(actor => actor.ContentType.Contains("audio")).OrderBy(actor => actor.Caption);
            form.Photos = form.ActorMediaItems.Where(actor => actor.ContentType.Contains("image")).OrderBy(actor => actor.Caption);
            form.Documents = form.ActorMediaItems.Where(actor => actor.ContentType.Contains("pdf")).OrderBy(actor => actor.Caption);
            

            


            return View(form);

        }

        // GET: Actor/Create
        [Authorize(Roles = "Executive")]

        public ActionResult Create()
        {
            var formModel = new ActorAddViewModel();

            return View(formModel);

        }

        // POST: Actor/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ActorAddViewModel newActor)
        {
            var addedActor = m.ActorAdd(newActor);
            if (addedActor == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("details", new { id = addedActor.Id });

            }

        }
        [Authorize(Roles = "Executive")]
        public ActionResult CreateMediaItem(int id)
        {

            var form = new ActorMediaItemAddFormViewModel();

            var actor = m.ActorGetById(id);
            form.ActorName = actor.Name;
            form.ActorId = actor.Id;
            return View(form);


        }
        [HttpPost]
        public ActionResult CreateMediaItem(ActorMediaItemAddViewModel newMediaItem)
        {
            var addedItem = m.ActorMediaItemAdd(newMediaItem);
            if (addedItem == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("details", new { id = addedItem.Id });
            }
        }

        [Route("Actors/MediaItem/{Id}")]
        public ActionResult MediaItemDownload(int Id)
        {

                // Attempt to get the matching object
                var o = m.ActorMediaItemGetById(Id);
            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // TODO 9 - Return a file content result
                // Set the Content-Type header, and return the photo bytes
                //return View();
                if (o.ContentType.Contains("pdf"))
                {
                    return File(o.Content, o.ContentType,o.Caption+".pdf");
                }
                else
                {
                    return File(o.Content, o.ContentType);
                }
            }
        }
        /*
         * [HttpPost]
        public ActionResult CreateMediaItem()
        {
            return View();
        }
        */
    }
}
