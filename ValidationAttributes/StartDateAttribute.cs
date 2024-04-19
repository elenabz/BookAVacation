using System.ComponentModel.DataAnnotations;

namespace BookAVacation.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class StartDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(value is DateTime)
            {
                DateTime _startDate = Convert.ToDateTime(value);
                return _startDate > DateTime.Now.Date;

            }
            return false;
        }

    }
}
