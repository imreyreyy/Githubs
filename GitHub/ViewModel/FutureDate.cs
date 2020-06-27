using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GitHub.ViewModel
{
    public class FutureDate:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date;
            var isValid=DateTime.TryParseExact(Convert.ToString(value),
                "dd MMM yyyy", CultureInfo.CurrentCulture, 
                DateTimeStyles.None, 
                out date);

            return (isValid && date > DateTime.Now);
        }
    }
}