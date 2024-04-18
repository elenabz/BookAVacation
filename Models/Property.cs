using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookAVacation.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Property Name")]
        [MinLength(5, ErrorMessage = "Minim Length 5 characters")]
        public string Name { get; set; }
        public string? Country { get; set; }

        [DisplayName("City of Property")]
        [MinLength(10, ErrorMessage = "Minim Length 1 characters")]
        public string City { get; set; }
        public string? Street { get; set; }
        public int? StreetNo { get; set; }
        public int PricePerNight { get; set; }
        public int MaxGuestsNo { get; set; }
        public int? Stars { get; set; }
        public string? Type { get; set; }
        public string? Phone { get; set; }
        [DisplayName("Description of Property")]
        [MinLength(3, ErrorMessage = "Minim Length 3 characters")]
        public string? Description { get; set; }
    }
}
