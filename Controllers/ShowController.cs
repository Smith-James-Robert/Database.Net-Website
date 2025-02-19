using JS2247A5.Data;
using JS2247A5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JS2247A5.Controllers
{
    public class ShowController : Controller
    {
        // GET: Show
        private Manager m = new Manager();
        public ActionResult Index()
        {
            return View(m.ShowGetAll());

        }

        // GET: Show/Details/5
        public ActionResult Details(int id)
        {
            return View(m.ShowGetById(id));

        }
        [Authorize(Roles = "Coordinator")]

        [Route("Actors/{id}/AddShow")]
        public ActionResult Create(int id)
        {
            var form = new ShowAddFormViewModel();
            IEnumerable<string> genres = m.GenreGetAll().Select(m => m.Name);
            form.GenreList = new SelectList(genres);
            form.ActorId.Add(id);
            form.ActorList = new MultiSelectList(m.ActorGetAll(), "Id", "Name",form.ActorId);
            form.ActorName = m.ActorGetWithShowInfo(id).Name;
            return View(form);

        }
        [Route("Actors/{id}/AddShow")]
        [ValidateInput(false)]

        [HttpPost]
        public ActionResult Create(ShowAddViewModel newShow)
        {
            if (!ModelState.IsValid)
            {
                return View("Pear");
            }
            var addedShow = m.ShowAdd(newShow);
            if (addedShow == null)
            {
                return View("Apple");
            }
            else
            {
                // return RedirectToAction("details", "Show", new { id = newEpisode.ShowId });
                return RedirectToAction("details", new { id = addedShow.Id });
            }

        }
        // GET: Show/Create
        [Authorize(Roles = "Clerk")]

        [Route("Shows/{id}/AddEpisode")]
        public ActionResult AddEpisode(int id)
        {
            var show = m.ShowGetById(id);

            if (show==null)
            {
                return HttpNotFound();
            }
            else
            {
                var formModel = new EpisodeAddFormViewModel();
                if (formModel != null)
                {
                    formModel.ShowName = show.Name;
                    formModel.ShowId = show.Id;
                    formModel.GenreList = new SelectList(m.GenreGetAll(), "Id", "Name");
                    if (formModel.GenreList != null)
                    {
                        return View(formModel);
                    }
                    else
                    {
                        return View(Details(id));
                    }
                }
                else {
                        return View(Details(id));
                }

            }




        }

        // POST: Show/Create
        [Route("Shows/{id}/AddEpisode")]
        [ValidateInput(false)]

        [HttpPost]
        public ActionResult AddEpisode(EpisodeAddViewModel newEpisode)
        {
            if (!ModelState.IsValid)
            {
                return View(newEpisode);
            }
            var addedEpisode = m.EpisodeAdd(newEpisode);
            if (addedEpisode == null)
            {
                return View(newEpisode);
            }
            else
            {
                return RedirectToAction("details", "Show", new { id = newEpisode.ShowId });

            }

        }

    }
}
