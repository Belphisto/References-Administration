using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public enum Status
    {
        [Description("Запланировано")]
        Scheduled,

        [Description("Подтверждено")]
        Confirmed,

        [Description("Отменено")]
        Canceled
    }

    public static class StatusExtensions
    {
        public static string GetDescription(this Status status)
        {
            var fieldInfo = status.GetType().GetField(status.ToString());
            var descriptionAttributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (descriptionAttributes != null && descriptionAttributes.Length > 0)
            {
                return descriptionAttributes[0].Description;
            }

            return status.ToString();
        }
    }
}
