﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionSystem.BaseSystemModel.Common
{
    public class BusinessException : Exception
    {
        public BusinessException(string msg) : base (msg)
        {

        }

    }
}
