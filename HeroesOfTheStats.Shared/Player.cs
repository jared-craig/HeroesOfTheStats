using System.Collections;
using System.Collections.Generic;

namespace HeroesOfTheStats.Shared
{
    public class Player
    {
        public string battletag { get; set; }
        public string hero { get; set; }
        public int hero_level { get; set; }
        public int team { get; set; }
        public bool winner { get; set; }
        public long blizz_id { get; set; }
        public bool silenced { get; set; }
        public int party { get; set; }
        public object talents { get; set; }
        public Score score { get; set; }
    }
}