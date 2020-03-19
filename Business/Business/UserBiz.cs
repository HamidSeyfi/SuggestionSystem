using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuggestionSystem.BaseSystemModel.Common;
using SuggestionSystem.BaseSystemModel.Model.DTO;
using SuggestionSystem.BaseSystemModel.Model.Table;
using SuggestionSystem.DAL;

namespace SuggestionSystem.Business
{
    public class UserBiz
    {
        public static UserBiz Instance = new UserBiz();
        public UserSession Login(UserDTO user)
        {
            using (var dbContext = new SqlServerDataContext())
            {

                if (string.IsNullOrWhiteSpace(user.UserName) || string.IsNullOrWhiteSpace(user.UserName))
                {
                    throw new BusinessException("نام کاربری و  کلمه عبور را وارد کنید");
                }


                var userOutput = dbContext.User.FirstOrDefault(e => e.UserName == user.UserName && e.Password == user.Password);
                if (userOutput == null)
                {
                    throw new BusinessException("اطلاعات کاربری معتبر نمیباشد");
                }


                if (userOutput.IsActive == false)
                {
                    throw new BusinessException("حساب کاربری شما غیر فعال میباشد");
                }




                //List<int> userRoles = RoleBiz.Instance.GetUserRoles(userOutput.Id);

                List<string> userAcess = AccessBiz.Instance.GetUserAccess();
                var userSession = new UserSession();
                userSession.FullName = userOutput.Name + " " + userOutput.Family;
                userSession.UserId = userOutput.Id;
                userSession.Access = userAcess;

                var userCommitteeRole = new CommitteeRoleEnum();
                var userCommitteeRoleType = new CommitteeRoleTypeEnum();


                CommitteeRoleBiz.Instance.GetUserCommitteeRole(out userCommitteeRole, out userCommitteeRoleType);

                userSession.CommitteeRole = userCommitteeRole;
                userSession.CommitteeRoleType = userCommitteeRoleType;






                return userSession;
            }
        }
    }
}
