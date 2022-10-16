namespace FootyTips.Data.Models
{
    public class Match
    {
        public int Id { get; set; } 
        public DateTime KickOff { get; set; }
        public int RefereeId { get; set; }
        public Referee Referee { get; set; }
        public List<TeamMatch> Teams { get; set; }
    }
}
