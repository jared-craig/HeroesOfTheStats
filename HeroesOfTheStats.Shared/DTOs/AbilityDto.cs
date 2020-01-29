namespace HeroesOfTheStats.Shared.DTOs
{
    public class AbilityDto
    {
        public string Owner { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string HotKey { get; set; }
        public int? Cooldown { get; set; }
        public int? ManaCost { get; set; }
        public bool IsTrait { get; set; }
    }
}
