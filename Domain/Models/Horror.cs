namespace Domain.Models
{
    public class Horror : Movie
    {
        public int ScaryLevel { get; set; }
        public bool SupernaturalElements { get; set; }
        public int GoreLevel { get; set; }
    }
}
