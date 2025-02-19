using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JS2247A5.Controllers
{
    public class GenreController : Controller
    {
        // GET: Genre
        private Manager m = new Manager();
        public ActionResult Index()
        {
            return View(m.GenreGetAll());

        }
    }
}
