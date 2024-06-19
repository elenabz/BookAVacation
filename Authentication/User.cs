using BookAVacation.Models;
using Microsoft.AspNetCore.Identity;

namespace BookAVacation.Authentication
{
    public class User : IdentityUser
    {
        public bool ReservationAllowed { get; set; }
        public required ICollection<Reservation> Reservations { get; set; }
    }
}
