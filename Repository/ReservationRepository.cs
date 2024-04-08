using BookAVacation.Data;
using BookAVacation.Interfaces;
using BookAVacation.Models;

namespace BookAVacation.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _dataContext;

        public ReservationRepository(ApplicationDbContext applicationDbContext)
        {
            _dataContext = applicationDbContext;
        }

        public bool CreateReservation(int propertyId, Reservation reservation)
        {
            var propertyEntity = _dataContext.Properties.Where(p => p.Id == propertyId).FirstOrDefault();
            reservation.Property = propertyEntity;
            _dataContext.Add(reservation);
            return Save();
        }

        public List<DateTime> GetPropertyReservations(int propertyId)
        {
            var propertyReservations = _dataContext.Reservations.Where(r => r.Property.Id == propertyId).ToList();
            return propertyReservations.Select(pr => pr.StartDate).ToList();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0;
        }
    }
}
