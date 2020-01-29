namespace HeroesOfTheStats.Shared.DTOs
{
    public class TalentDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public object IconUrl { get; set; }
        public string Ability { get; set; }
        public int Sort { get; set; }
        public int? Cooldown { get; set; }
        public int? ManaCost { get; set; } 
        public int Level { get; set; }
    }
}
