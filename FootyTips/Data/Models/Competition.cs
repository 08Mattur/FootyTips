namespace FootyTips.Data.Models
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }

        public List<Season> Seasons { get; set; } = new();
    }
}
