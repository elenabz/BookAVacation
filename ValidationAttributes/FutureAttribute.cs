using System.ComponentModel.DataAnnotations;

namespace BookAVacation.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class FutureAttribute: ValidationAttribute
    {
        public string InvalidDate = "Invalid Date";
        public FutureAttribute() : base("Invalid Date.")
        { 
        
        }

        public override bool IsValid(object? value)
        {
            return value is DateTime dateTime && dateTime > DateTime.UtcNow;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return value is DateTime dateTime && dateTime > DateTime.UtcNow
                ? ValidationResult.Success
                : new ValidationResult(InvalidDate);
        }
    }
}
