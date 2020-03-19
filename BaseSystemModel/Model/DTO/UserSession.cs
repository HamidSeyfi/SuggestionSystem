using SuggestionSystem.BaseSystemModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionSystem.BaseSystemModel.Model.DTO
{
    public class UserSession
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public CommitteeRoleTypeEnum CommitteeRoleType { get; set; }
        public CommitteeRoleEnum CommitteeRole { get; set; }
        public List<string> Access { get; set; }


    }
}
