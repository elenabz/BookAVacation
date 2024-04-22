using BookAVacation.DTO;
using FluentValidation;

namespace BookAVacation.Validations
{
    public class CreateReservationRequestValidator : AbstractValidator<ReservationDto>
    {
        public CreateReservationRequestValidator() { 
            RuleFor(x => x.NoOfGuests).GreaterThan(90);
            RuleFor(x => x.StartDate).Must(x => x >= DateTime.UtcNow);
            RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate).WithMessage("{PropertyName} must be greater than Start Date. You provided {PropertyValue}");
        }
    }
}   
