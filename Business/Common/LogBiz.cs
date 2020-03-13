using SuggestionSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuggestionSystem.BaseSystemModel.Model.Table;
using SuggestionSystem.BaseSystemModel.Common;
using System.Web.Routing;

namespace SuggestionSystem.Business.Common
{
    public class LogBiz
    {
        public static void Log(string logName, string logText, LogType logType)
        {


            using (var context = new SqlServerDataContext())
            {

                var x = context.User.FirstOrDefault();
            }




            LogIntoSqlServer(logName, logText, logType);
        }

        public static void LogException(string logName, Exception ex, LogType logType = LogType.Exception)
        {

            if (ex.GetType() == typeof(BusinessException))
            {
                LogIntoSqlServer(logName, ex.Message, logType);
            }
            else
            {
                var logMessage = ex.Message + "*"
                    + ex.InnerException?.Message + "*"
                    + ex.InnerException?.InnerException?.Message + "*"
                    + ex.InnerException?.InnerException?.InnerException?.Message;

                LogIntoSqlServer(logName, logMessage, LogType.Exception);
            }
        }

        public static void LogFilter(RouteData routeData, LogType logType)
        {
            
            var areaName = (string)routeData.DataTokens["area"];
            var controllerName = (string)routeData.Values["controller"];
            var actionName = (string)routeData.Values["action"];
            var logName = $"{(string.IsNullOrWhiteSpace(areaName) ? "" : (areaName + "/"))}{controllerName}/{actionName}";
            LogIntoSqlServer(logName, "", logType);
        }

        private static void LogIntoSqlServer(string logName, string logText, LogType logType)
        {
            var userSession = (SuggestionSystem.BaseSystemModel.Model.DTO.UserSession)System.Web.HttpContext.Current.Session["UserSession"];

            using (var context = new SqlServerDataContext())
            {
                context.Log.Add(new Log
                {
                    Date = DateTime.Now,
                    LogName = logName,
                    LogText = logText,
                    FK_UserId = userSession != null ? userSession.UserId : (int?)null,
                    LogType = (byte)logType

                });
                context.SaveChanges();
            }
        }
    }
}
