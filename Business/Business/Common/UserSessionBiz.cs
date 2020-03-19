using SuggestionSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuggestionSystem.BaseSystemModel.Model.Table;
using SuggestionSystem.BaseSystemModel.Common;
using System.Web.Routing;
using SuggestionSystem.BaseSystemModel.Model.DTO;

namespace SuggestionSystem.Business.Common
{
    public class UserSessionBiz
    {
        public static UserSession GetUserSession()
        {
            return (UserSession)System.Web.HttpContext.Current.Session["UserSession"];
        }

    }
}
