using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SuggestionSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            BaseSystemModel.Common.ConnectionString.SqlServerConnectionString = @"data source=DESKTOP-THBF5B2\MSSQLSERVER2016;initial catalog=SuggestionSystem;integrated security=True";



        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError();

            var temp = 0;

            //var httpException = error as HttpException;
            //if (httpException != null)
            //{
            //    string action;
            //    switch (httpException.GetHttpCode())
            //    {
            //        case 404:
            //            // page not found
            //            action = "HttpError404";
            //            break;
            //        case 500:
            //            // server error
            //            action = "HttpError500";
            //            break;
            //        default:
            //            action = "General";
            //            break;
            //    }
            //    Response.Redirect(String.Format("~/Error/{0}/?message={1}", action, error.Message));
            //}


            //var errorMsg = HttpContext.Current.Request.Url.ToString();
            //errorMsg += error.Message != null ? "\nMessage : " + error.Message.ToString() : "";
            //errorMsg += error.InnerException?.Message != null ? "\nInnerExceptionMessage : " + error.InnerException.Message.ToString() : "";
            //errorMsg += error.InnerException?.InnerException?.Message != null ? "\nInnerExceptionInnerExceptionMessage : " + error.InnerException.InnerException.Message.ToString() : "";

            //Hamid.Business.LogBiz.Log("Application_Error", errorMsg);

            //Response.Clear(); // to ensure that any content written to the response stream before the error occurred is removed.

            //if (HttpContext.Current.IsDebuggingEnabled == false)
            //{
            //    Server.ClearError();// to stop ASP.NET from serving the yellow screen of death.
            //    Response.Redirect("~/Error/Index");
            //    //Response.Redirect("~/Error/Index?msg=someThing");
            //}


        }
    }
}
