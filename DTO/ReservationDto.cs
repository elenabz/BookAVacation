using BookAVacation.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace BookAVacation.DTO
{
    public class ReservationDto
    {
        [Required(ErrorMessage = "Start Date is required.")]
        [StartDate]
        public DateTime StartDate { set; get; }

        [Required(ErrorMessage = "End Date is required.")]
        //[Future]
        [Future(InvalidDate = "End Date is invalid.")]
        public DateTime EndDate { set; get; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Minim 1 guest.")]
        public int NoOfGuests { set; get; }
    }
}
