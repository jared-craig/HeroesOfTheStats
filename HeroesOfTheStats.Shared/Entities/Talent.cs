namespace HeroesOfTheStats.Shared.Entities
{
    public class Talent
    {
        public string name { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public object icon_url { get; set; }
        public string ability { get; set; }
        public int sort { get; set; }
        public int? cooldown { get; set; }
        public int? mana_cost { get; set; } 
        public int level { get; set; }
    }
}
