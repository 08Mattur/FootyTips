namespace FootyTips.Data.Models
{
    public class Season
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int CompetitionId { get; set; }
        public Competition Competition { get; set; }
        public List<Team> Teams { get; set; } = new();
    }
}
