using BookAVacation.Models;

namespace BookAVacation.Interfaces
{
    public interface IPropertyRepository
    {
        ICollection<Property> GetProperties();
        Property GetProperty(int id);
        bool PropertyExists(int id);
        bool CreateProperty(Property property);
        bool UpdateProperty(Property property);
        bool DeleteProperty(Property property);
        bool Save();
    }
}
