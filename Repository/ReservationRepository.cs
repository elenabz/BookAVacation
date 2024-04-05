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

        public bool CreateReservation(Reservation reservation)
        {
            _dataContext.Add(reservation);
            return Save();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0;
        }
    }
}
