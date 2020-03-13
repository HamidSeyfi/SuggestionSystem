using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionSystem.BaseSystemModel.Common
{
    public enum LogType
    {
        InputUser = 1,
        OutputUser = 2,
        Exception = 3,
        LogFilterActionExecuting = 10,
        LogFilterResultExecuted = 11,
        
    }
}
