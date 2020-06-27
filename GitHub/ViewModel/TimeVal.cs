using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GitHub.ViewModel
{
    public class TimeVal:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "HH:mm", CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out date);

            return (isValid );
        }
    }
}