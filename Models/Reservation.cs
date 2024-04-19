using BookAVacation.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace BookAVacation.Models
{
    public class Reservation
    {
        [Key]
        public int Id { set; get; }

        [Required]
        public Property Property { set; get; }

        [Required(ErrorMessage = "Start Date is required.")]
        [StartDate]
        public DateTime StartDate { set; get; }

        [Required(ErrorMessage = "End Date is required.")]
        public DateTime EndDate { set; get; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Minim 1 guest.")]
        public int NoOfGuests { set; get; }
        //public User User { set; get; }
    }
}
