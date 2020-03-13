using SuggestionSystem.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuggestionSystem.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LogBiz.LogFilter(filterContext.RouteData, BaseSystemModel.Common.LogType.LogFilterActionExecuting);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            LogBiz.LogFilter(filterContext.RouteData, BaseSystemModel.Common.LogType.LogFilterResultExecuted);
        }

        
    }
}