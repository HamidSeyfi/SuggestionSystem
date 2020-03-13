using Newtonsoft.Json;
using SuggestionSystem.BaseSystemModel.Common;
using SuggestionSystem.Business.Common;
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
            Exception exception = Server.GetLastError();
            Response.Clear();

            HttpException httpException = exception as HttpException;

            if (httpException != null)
            {
                string action;

                switch (httpException.GetHttpCode())
                {
                    case 404:
                        // page not found
                        action = "HttpError404";
                        break;
                    case 500:
                        // server error
                        action = "HttpError500";
                        break;
                    default:
                        action = "General";
                        break;
                }

                // clear error on server
                Server.ClearError();


                LogBiz.LogException("Application_Error", exception, LogType.Exception);

                //Response.Redirect(String.Format("~/Error/{0}/?message={1}", action, exception.Message));
                Response.Redirect(String.Format("~/Error/{0}", action));
            }


        }
    }
}
