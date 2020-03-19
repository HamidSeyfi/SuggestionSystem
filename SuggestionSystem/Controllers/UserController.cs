using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuggestionSystem.BaseSystemModel.Model.DTO;
using SuggestionSystem.Business;
using SuggestionSystem.Business.Common;
using Newtonsoft.Json;
using SuggestionSystem.BaseSystemModel.Common;
using SuggestionSystem.Filters;

namespace SuggestionSystem.Controllers
{
    public class UserController : Controller
    {
        
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserDTO user)
        {
            try
            {
                LogBiz.Log("User/Login", JsonConvert.SerializeObject(user), LogTypeEnum.InputUser);

                var userSession = UserBiz.Instance.Login(user);
                Session["UserSession"] = userSession;

                LogBiz.Log("User/Login", JsonConvert.SerializeObject(userSession), LogTypeEnum.OutputUser);

                return Json(new
                {
                    Status = true
                });
            }
            catch (Exception ex)
            {
                LogBiz.LogException("User/Login", ex, LogTypeEnum.OutputUser);

                return Json(new
                {
                    Status = false,
                    Message = Message.GetExceptionMessage(ex)
                }); 
            }
        }


    }
}