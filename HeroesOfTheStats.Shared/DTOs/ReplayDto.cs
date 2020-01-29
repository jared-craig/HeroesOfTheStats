using System.Collections.Generic;

namespace HeroesOfTheStats.Shared.DTOs
{
    public class ReplayDto
    {
        public long Id { get; set; }
        public string Filename { get; set; }
        public long Size { get; set; }
        public string GameType { get; set; }
        public string GameDate { get; set; }
        public int GameLength { get; set; }
        public string GameMap { get; set; }
        public string GameVersion { get; set; }
        public int Region { get; set; }
        public string Fingerprint { get; set; }
        public string Url { get; set; }
        public bool IsProcessed { get; set; }
        public bool IsDeleted { get; set; }
        public List<PlayerDto> Players { get; set; }
        public List<TeamDto> Teams { get; set; }
        public List<string[]> Bans { get; set; }
    }
}
