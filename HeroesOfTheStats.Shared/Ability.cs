namespace HeroesOfTheStats.Shared
{
    public class Ability
    {
        public string owner { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public string hotkey { get; set; }
        public int? cooldown { get; set; }
        public int? mana_cost { get; set; }
        public bool trait { get; set; }
    }
}
