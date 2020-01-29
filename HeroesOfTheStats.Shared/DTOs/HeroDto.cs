using System.Collections.Generic;

namespace HeroesOfTheStats.Shared.DTOs
{
    public class HeroDto
    {
        public double Wins { get; set; }
        public double Loses { get; set; }
        public double WinRate { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string AttributeId { get; set; }
        public string CHeroId { get; set; }
        public string CUnitId { get; set; }
        public List<string> Translations { get; set; }
        public object IconUrl { get; set; }
        public string Role { get; set; }
        public string Type { get; set; }
        public string ReleaseDate { get; set; }
        public string ReleasePatch { get; set; }
        public List<AbilityDto> Abilities { get; set; }
        public List<TalentDto> Talents { get; set; }
    }
}
