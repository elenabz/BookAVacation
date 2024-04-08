using BookAVacation.Models;

namespace BookAVacation.Interfaces
{
    public interface IReservationRepository
    {
        bool CreateReservation(int propertyId, Reservation reservation);
        List<DateTime> GetPropertyReservations(int propertyId);
        bool Save();
    }
}
