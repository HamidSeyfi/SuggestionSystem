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
                return ExObjectRefrenceNull;
            }
            else if (ex.Message.IndexOf("Index was outside the bounds of the array", StringComparison.OrdinalIgnoreCase) != -1
                || ex.Message.IndexOf("Index was out of range", StringComparison.OrdinalIgnoreCase) != -1)
            {
                return ExIndexOutOfRange;
            }
            if (ex.Message.IndexOf("Sequence contains no", StringComparison.OrdinalIgnoreCase) != -1)
            {
                return ExFoundNoData;
            }
            else
            {
                return "خطا رخ داده است";
            }
        }


        private static readonly string ExObjectRefrenceNull = "خطا ارجاع خالی";
        private static readonly string ExIndexOutOfRange = "خطا ایندکس اشتباه";
        private static readonly string ExFoundNoData = "خطا پیدا نکردن اطلاعات";


        public static readonly string CodePeygiri = "کد پیگیری";
        public static readonly string Onvan = "عنوان";
        public static readonly string Vaziat = "وضعیت";
        public static readonly string Namayesh = "نمایش";
        public static readonly string Virayesh = "ویرایش";
        public static readonly string ErsaleNazar = "ارسال نظر";
        public static readonly string ListNazarat = "لیست نظرات";

    }
}
