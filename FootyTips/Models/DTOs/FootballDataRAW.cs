namespace FootyTips.Models.DTOs
{
    public class FootballDataRAW
    {
        public string Div { get; set; }
        public DateTime KickOff { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int FTHomeGoals { get; set; }
        public int FTAwayGoals { get; set; }
        public string Referee { get; set; }
        public int HomeShots { get; set; }
        public int AwayShots { get; set; }
        public int HomeShotsOnTarget { get; set; }
        public int AwayShotsOnTarget { get; set; }
        public int HomeCorners { get; set; }
        public int AwayCorners { get; set; }
        public int HomeFouls { get; set; }
        public int AwayFouls { get; set; }
        public int HomeYellows { get; set; }
        public int AwayYellows { get; set; }
        public int HomeReds { get; set; }
        public int AwayReds { get; set; }
    }
}
