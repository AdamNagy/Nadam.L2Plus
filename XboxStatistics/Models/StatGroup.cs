namespace XboxStatistics.Models
{
    public class StatGroup
    {
        public string Name { get; set; }
        public int TitleTd { get; set; }
        public StatlistsCollection[] StatlistsCollection { get; set; }
    }
}