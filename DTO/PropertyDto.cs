using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BookAVacation.DTO
{
    public class PropertyDto
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Property Name")]
        [MinLength(5, ErrorMessage = "Minim Length 5 characters. dto")]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [DisplayName("City of Property")]
        [MinLength(1, ErrorMessage = "Minim Length 1 characters. dto")]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public int StreetNo { get; set; }

        [Required]
        public int PricePerNight { get; set; }

        [Required]
        public int MaxGuestsNo { get; set; }

        [Required]
        public int Stars { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [DisplayName("Description of Property")]
        [MinLength(3, ErrorMessage = "Minim Length 3 characters. dto")]
        public string Description { get; set; }
    }
}
