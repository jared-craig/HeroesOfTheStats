using System.Collections.Generic;

namespace HeroesOfTheStats.Shared
{
    public class Replay
    {
        public long id { get; set; }
        public string filename { get; set; }
        public long size { get; set; }
        public string game_type { get; set; }
        public string game_date { get; set; }
        public int game_length { get; set; }
        public string game_map { get; set; }
        public string game_version { get; set; }
        public int region { get; set; }
        public string fingerprint { get; set; }
        public string url { get; set; }
        public bool processed { get; set; }
        public bool deleted { get; set; }
        public IEnumerable<Player> players { get; set; }
        public IEnumerable<Team> teams { get; set; }
        public IEnumerable<string[]> bans { get; set; }
    }
}
