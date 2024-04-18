using BookAVacation.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace BookAVacation.DTO
{
    public class ReservationDto
    {
        [Required(ErrorMessage = "Start Date is required.")]
        [ValidStartDate]
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public int NoOfGuests { set; get; }
    }
}
