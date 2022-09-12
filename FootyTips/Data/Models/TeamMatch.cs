namespace FootyTips.Data.Models
{
    public class TeamMatch
    {
        public int Id { get; set; }
        public bool IsHome { get; set; }
        public int Goals { get; set; }
        public int Shots { get; set; }
        public int ShotsOnTarget { get; set; }
        public int Fouls { get; set; }
        public int Corners { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
