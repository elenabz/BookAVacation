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
        [MinLength(1, ErrorMessage = "Minim Length 10 characters")]
        public string Name { get; set; }
        public string? Country { get; set; }
        [DisplayName("City of Property")]
        [MinLength(1, ErrorMessage = "Minim Length 10 characters")]
        public string City { get; set; }
        public string? Street { get; set; }
        public int? StreetNo { get; set; }
        public int? Stars { get; set; }
        public string? Type { get; set; }
        public string? Phone { get; set; }
        [DisplayName("Description of Property")]
        [MinLength(10, ErrorMessage = "Minim Length 10 characters")]
        public string? Description { get; set; }
    }
}
