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

        // todo where to have the logic? controller or repository 
        public List<DateTime> GetPropertyReservations(int propertyId)
        {
            var propertyReservations = _dataContext.Reservations.Where(r => r.Property.Id == propertyId).ToList();
            var dates = new HashSet<DateTime>();

            propertyReservations.ForEach((pr) =>
            {
                for (var dt = pr.StartDate; dt <= pr.EndDate; dt = dt.AddDays(1))
                {
                    dates.Add(dt);
                }
            });

            List<DateTime> bookedDates = dates.ToList();
            // de ce nu pot return bookedDates.Sort... ?
            bookedDates.Sort((x, y) => DateTime.Compare(x, y));
            return bookedDates;
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0;
        }
    }
}
