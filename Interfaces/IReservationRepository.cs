using BookAVacation.Models;

namespace BookAVacation.Interfaces
{
    public interface IReservationRepository
    {
        bool CreateReservation(Reservation reservation);
        bool Save();
    }
}
