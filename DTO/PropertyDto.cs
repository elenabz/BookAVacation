using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BookAVacation.DTO
{
    public class PropertyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int StreetNo { get; set; }
        public int Stars { get; set; }
        public string Type { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
    }
}
