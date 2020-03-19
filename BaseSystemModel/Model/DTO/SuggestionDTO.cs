using SuggestionSystem.BaseSystemModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionSystem.BaseSystemModel.Model.DTO
{
    public class SuggestionDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public SuggestionStatusEnum Status { get; set; }
        public string StatusDescrp { get; set; }

    }
}
