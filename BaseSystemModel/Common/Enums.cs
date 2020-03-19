using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionSystem.BaseSystemModel.Common
{
    public enum LogTypeEnum
    {
        InputUser = 1,
        OutputUser = 2,
        Exception = 3,
        LogFilterActionExecuting = 10,
        LogFilterResultExecuted = 11,

    }


    public enum OperationEnum
    {
        Create = 1,
        Edit = 2,
        Details = 3,
        Delete = 4
    }


    public enum SuggestionStatusEnum
    {
        Created_And_In_SuperiorCommitteeSecretary_Kartable = 20,
        SuperiorCommitteeSecretary_Send_To_TechnicalCommittee = 30,
        TechnicalCommittee_Accepted = 40,
        SuperiorCommitteeSecretary_Send_To_SuperiorCommittee=50,
        SuperiorCommittee_Accepted=60
    }


    public  enum CommitteeRoleTypeEnum
    {
        NormalUser = 10,
        SuperiorCommitteeSecretary = 20,
        TechnicalCommittee=40,
        SuperiorCommitteeMember=30
    }


    public enum CommitteeRoleEnum
    {
        NormalUser = 11,
        SuperiorCommitteeSecretary = 21,
        TechnicalCommittee1 = 41,
        TechnicalCommittee2 = 42,
        SuperiorCommitteeMember = 31
    }
}
