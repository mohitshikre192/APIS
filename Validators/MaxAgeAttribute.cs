using Microsoft.OpenApi;
using System.ComponentModel.DataAnnotations;

namespace APIS.Validators
{
    public class MaxAgeAttribute:ValidationAttribute
    {
        int _maxAge;    

       public MaxAgeAttribute(int maxAge)
        {
            _maxAge = maxAge;
        }

        public override bool IsValid(object value)
        {
            DateTime date;

            if (DateTime.TryParse(value.ToString(), out date))
            { 
              return date.AddYears(_maxAge) > DateTime.Now;
            }
            return false;
        }
    }
}
