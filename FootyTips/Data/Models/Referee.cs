namespace FootyTips.Data.Models
{
    public class Referee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Match> MatchesOfficiated { get; set; } = new();
    }
}
