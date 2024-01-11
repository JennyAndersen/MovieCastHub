namespace Domain.Models
{
    public class Documentary : Movie
    {
        public required string HistoricalContext { get; set; }
        public required string RealLifeContext { get; set; }
    }
}
