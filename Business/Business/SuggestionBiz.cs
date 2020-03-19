using SuggestionSystem.BaseSystemModel.Common;
using SuggestionSystem.BaseSystemModel.Model.DTO;
using SuggestionSystem.BaseSystemModel.Model.Table;
using SuggestionSystem.Business.Common;
using SuggestionSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionSystem.Business
{
    public class SuggestionBiz
    {
        public static SuggestionBiz Instance = new SuggestionBiz();

        public SuggestionAllDTO GetUserSeggestions()
        {
            var output = new SuggestionAllDTO();

            var userSession = UserSessionBiz.GetUserSession();

            using (var dbContext = new SqlServerDataContext())
            {
                output.Suggestions = new List<SuggestionDTO>();
                output.Suggestions_UserCreated = new List<SuggestionDTO>();

                if (AccessBiz.UserHasAccess("10"))//پیشنهاد
                {
                    output.Suggestions_UserCreated = (from sug in dbContext.Suggestion
                                                      join sugStatus in dbContext.SuggestionStatus
                                                      on sug.FK_SuggestionStatusCode equals sugStatus.Code
                                                      where sug.FK_UserId_Insert == userSession.UserId
                                                      select new SuggestionDTO()
                                                      {
                                                          Id = sug.Id,
                                                          Title = sug.Title,
                                                          Status = (SuggestionStatusEnum)sug.FK_SuggestionStatusCode,
                                                          StatusDescrp = sugStatus.Name
                                                      }).ToList();
                }


                if (AccessBiz.UserHasAccess("20"))//کارابل دبیر کمیته عالی
                {
                    if (AccessBiz.UserHasAccess("20-01")) //لیست پیشنهاد های ثبت شده
                    {
                        output.Suggestions.AddRange((from sug in dbContext.Suggestion
                                                     join sugStatus in dbContext.SuggestionStatus
                                                     on sug.FK_SuggestionStatusCode equals sugStatus.Code
                                                     where sug.FK_CommitteeRoleCode == (int)CommitteeRoleEnum.SuperiorCommitteeSecretary &&
                                                     sug.FK_SuggestionStatusCode == (int)SuggestionStatusEnum.Created_And_In_SuperiorCommitteeSecretary_Kartable
                                                     select new SuggestionDTO()
                                                     {
                                                         Id = sug.Id,
                                                         Title = sug.Title,
                                                         Status = (SuggestionStatusEnum)sug.FK_SuggestionStatusCode,
                                                         StatusDescrp = sugStatus.Name
                                                     }).ToList());
                    }


                    if (AccessBiz.UserHasAccess("20-02")) //لیست پیشنهاد های تایید شده توسط کمیته تخصصی
                    {
                        output.Suggestions_UserCreated = (from sug in dbContext.Suggestion
                                                          join sugStatus in dbContext.SuggestionStatus
                                                          on sug.FK_SuggestionStatusCode equals sugStatus.Code
                                                          where sug.FK_CommitteeRoleCode == (int)CommitteeRoleEnum.SuperiorCommitteeSecretary &&
                                                          sug.FK_SuggestionStatusCode == (int)SuggestionStatusEnum.TechnicalCommittee_Accepted
                                                          select new SuggestionDTO()
                                                          {
                                                              Id = sug.Id,
                                                              Title = sug.Title,
                                                              StatusDescrp = sugStatus.Name
                                                          }).ToList();
                    }


                    if (AccessBiz.UserHasAccess("20-03")) //تاریخچه
                    {
                        output.Suggestions_UserCreated = (from sug in dbContext.Suggestion
                                                          join sugStatus in dbContext.SuggestionStatus
                                                          on sug.FK_SuggestionStatusCode equals sugStatus.Code
                                                          where sug.FK_CommitteeRoleCode == (int)CommitteeRoleEnum.SuperiorCommitteeSecretary &&
                                                          sug.FK_SuggestionStatusCode == (int)SuggestionStatusEnum.TechnicalCommittee_Accepted
                                                          select new SuggestionDTO()
                                                          {
                                                              Id = sug.Id,
                                                              Title = sug.Title,
                                                              StatusDescrp = sugStatus.Name
                                                          }).ToList();
                    }







                }

            }

            return output;





        }


        public void CreateSuggestion(Suggestion model)
        {
            ValidateUserHasAccessToOperation("10-01");
            ValidateSuggestion(model);

            using (var dataContext = new SqlServerDataContext())
            {
                //model.FK_SuggestionStatusId = (int)BaseSystemModel.Common.SuggestionStatusEnum.create_and_it_is_in_dabireAli_kartable;
                //model.FK_UserId_Insert = ;
            }
        }


        public void EditSuggestion(Suggestion model)
        {
            ValidateUserHasAccessToOperation("10-03");
            ValidateUserHasAccessToSuggestion(model.Id);
            ValidateSuggestion(model);
        }


        public Suggestion Details(int? id)
        {
            ValidateUserHasAccessToOperation("10-02");
            ValidateUserHasAccessToSuggestion(id.Value);

            return null;
        }


        private void ValidateSuggestion(Suggestion model)
        {
            if (string.IsNullOrWhiteSpace(model.Title))
            {
                throw new BusinessException("عنوان پیشنهاد خالی است");
            }
        }

        private void ValidateUserHasAccessToSuggestion(int id)
        {
            //return true;
        }

        private void ValidateUserHasAccessToOperation(string accessCodeStr)
        {
            if (!AccessBiz.UserHasAccess(accessCodeStr))
                throw new BusinessException("شما به این عملیات دسترسی ندارد");
        }


    }
}
