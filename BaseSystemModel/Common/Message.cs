using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionSystem.BaseSystemModel.Common
{
    public class Message
    {
        public static string GetExceptionMessage(Exception ex)
        {
            if (ex.GetType()==typeof(BusinessException))
            {
                return ex.Message;
            }

            if (ex.Message.IndexOf("Object reference not set to an instance of an object", StringComparison.OrdinalIgnoreCase) != -1)
            {
                return ObjectRefrenceNull;
            }
            else if (ex.Message.IndexOf("Index was outside the bounds of the array", StringComparison.OrdinalIgnoreCase) != -1
                || ex.Message.IndexOf("Index was out of range", StringComparison.OrdinalIgnoreCase) != -1)
            {
                return IndexOutOfRange;
            }
            if (ex.Message.IndexOf("Sequence contains no", StringComparison.OrdinalIgnoreCase) != -1)
            {
                return FoundNoData;
            }
            else
            {
                return "خطا رخ داده است";
            }
        }


        private static readonly string ObjectRefrenceNull = "خطا ارجاع خالی";
        private static readonly string IndexOutOfRange = "خطا ایندکس اشتباه";
        private static readonly string FoundNoData = "خطا پیدا نکردن اطلاعات";
    }
}
