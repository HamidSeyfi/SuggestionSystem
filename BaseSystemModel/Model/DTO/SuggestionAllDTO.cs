using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionSystem.BaseSystemModel.Model.DTO
{
    public class SuggestionAllDTO
    {
        public List<SuggestionDTO> Suggestions_UserCreated { get; set; }

        public List<SuggestionDTO> Suggestions { get; set; }
    }
}
