using BookAVacation.Data;
using BookAVacation.Interfaces;
using BookAVacation.Models;

namespace BookAVacation.Repository
{
    public class PropertyRepository : IPropertyRepository
    {

        // get application dbContext using dependency injection => so that I can communicate with DB
        private readonly ApplicationDbContext _dataContext;

        public PropertyRepository(ApplicationDbContext applicationDbContext)
        {
            _dataContext = applicationDbContext;
        }
        public bool CreateProperty(Property property)
        {
            _dataContext.Add(property);
            return Save();
        }

        public bool DeleteProperty(Property property)
        {
            _dataContext.Remove(property);
            return Save();
        }

        public ICollection<Property> GetProperties()
        {
            return _dataContext.Properties.ToList();
        }

        public Property GetProperty(int id)
        {
            return _dataContext.Properties.Where(p => p.Id == id).FirstOrDefault();
        }

        public bool PropertyExists(int id)
        {
            return _dataContext.Properties.Any(p => p.Id == id);
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0;
        }

        public bool UpdateProperty(Property property)
        {
            _dataContext.Update(property);
            return Save();
        }
    }
}
