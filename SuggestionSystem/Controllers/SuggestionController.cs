using SuggestionSystem.BaseSystemModel.Model.DTO;
using SuggestionSystem.Business;
using SuggestionSystem.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuggestionSystem.BaseSystemModel.Model.Table;

namespace SuggestionSystem.Controllers
{
    public class SuggestionController : Controller
    {
        #region Index
        [HttpGet]
        public ActionResult Index()
        {
            var output = SuggestionBiz.Instance.GetUserSeggestions();
            return View(output);
        }
        #endregion

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        

        [HttpPost]
        public ActionResult Create([Bind(Include = "Title")] Suggestion model)
        {
            return View("Index");
        }
        #endregion


        #region Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Title")]Suggestion model)
        {
            return View("Index");
        }
        #endregion


        #region Details
        [HttpGet]
        public ActionResult Details(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Details(Suggestion model)
        {
            return View("Index");
        }
        #endregion


    }
}