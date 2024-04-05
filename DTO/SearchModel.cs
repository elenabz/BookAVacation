using System.ComponentModel.DataAnnotations;

namespace BookaVacation.DTO
{
    public class SearchModel
    {
        public string? Location { get; set; }

        // used DateTime because .net 6 doesn't support binding for DateOnly 
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NoOfPersons { get; set; }
    }
}
