namespace FootyTips.Data.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string HomeGround { get; set; }
        public List<TeamMatch> Matches { get; set; } = new();
        public List<Season> Seasons { get; set; } = new();
    }
}
