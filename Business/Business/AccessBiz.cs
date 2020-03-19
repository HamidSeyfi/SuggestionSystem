using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuggestionSystem.BaseSystemModel.Common;
using SuggestionSystem.BaseSystemModel.Model.DTO;
using SuggestionSystem.BaseSystemModel.Model.Table;
using SuggestionSystem.Business.Common;
using SuggestionSystem.DAL;

namespace SuggestionSystem.Business
{
    public class AccessBiz
    {
        public static AccessBiz Instance = new AccessBiz();

        public List<string> GetUserAccess()
        {
            using (var dbContext = new SqlServerDataContext())
            {
                var userId = UserSessionBiz.GetUserSession().UserId;
                var result = (from user in dbContext.User
                              join userAccess in dbContext.UserAccess_Rel on user.Id equals userAccess.FK_UserId
                              join access in dbContext.Access on userAccess.FK_AccessId equals access.Id
                              where user.Id == userId
                              select access.CodeStr
                              ).ToList();
                return result;
            }

        }

        public static bool UserHasAccess(string accessCodeStr)
        {
            var userSession = UserSessionBiz.GetUserSession();
            if (userSession.Access.Contains(accessCodeStr))
            {
                return true;
            }
            return false;
        }
    }
}
