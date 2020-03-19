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
    public class CommitteeRoleBiz
    {
        public static CommitteeRoleBiz Instance = new CommitteeRoleBiz();

        public void GetUserCommitteeRole(out CommitteeRoleEnum committeeRoleEnum, out CommitteeRoleTypeEnum committeeRoleTypeEnum)
        {
            using (var dbContext = new SqlServerDataContext())
            {
                var userId = UserSessionBiz.GetUserSession().UserId;
                var result = (from user in dbContext.User
                              join userCommitteeRole in dbContext.UserCommitteeRole_Rel on user.Id equals userCommitteeRole.FK_UserId
                              join committeeRole in dbContext.CommitteeRole on userCommitteeRole.FK_CommitteeRoleId equals committeeRole.Id
                              where user.Id == userId
                              select new {
                                  committeeRole.Code,
                                  committeeRole.FK_CommitteeRoleTypeCode
                              }).FirstOrDefault();
                committeeRoleEnum = (CommitteeRoleEnum)result.Code;
                committeeRoleTypeEnum = (CommitteeRoleTypeEnum)result.FK_CommitteeRoleTypeCode;
            }
        }













    }
}
