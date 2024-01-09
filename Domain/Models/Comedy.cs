namespace Domain.Models
{
    public class Comedy : Movie
    {
        public required string HumorStyle { get; set; }
        public bool FamilyFriendly { get; set; }
        public bool ParodyElements { get; set; }
    }
}
