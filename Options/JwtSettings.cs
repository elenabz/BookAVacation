namespace BookAVacation.Options
{
    public class JwTSettings
    {
        public string? SigningKey {  get; set; }
        public string? Issuer {  get; set; }
        public string[]? Audiences {  get; set; }
    }
}
