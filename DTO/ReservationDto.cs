using System.ComponentModel.DataAnnotations;

namespace BookAVacation.DTO
{
    public class ReservationDto
    {
        public int Id { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public int NoOfGuests { set; get; }
    }
}
