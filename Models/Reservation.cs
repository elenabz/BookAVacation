using System.ComponentModel.DataAnnotations;

namespace BookAVacation.Models
{
    public class Reservation
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public Property Property { set; get; }
        [Required]
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        [Range(1, int.MaxValue)]
        public int NoOfGuests { set; get; }
        //public User User { set; get; }
    }
}
