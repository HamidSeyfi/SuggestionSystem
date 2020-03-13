using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuggestionSystem.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult General()
        {
            return View();
        }


        public ActionResult HttpError404()
        {
            return View();
        }


        public ActionResult HttpError500()
        {
            return View();
        }
    }
}