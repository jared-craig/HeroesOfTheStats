using System.Collections.Generic;
using System.Diagnostics;

namespace HeroesOfTheStats.Shared
{
    public class Hero
    {
        public double wins { get; set; }
        public double loses { get; set; }
        public double win_rate { get; set; }
        public string name { get; set; }
        public string short_name { get; set; }
        public string attribute_id { get; set; }
        public string c_hero_id { get; set; }
        public string c_unit_id { get; set; }
        public IEnumerable<string> translations { get; set; }
        public object icon_url { get; set; }
        public string role { get; set; }
        public string type { get; set; }
        public string release_date { get; set; }
        public string release_patch { get; set; }
        public IEnumerable<Ability> abilities { get; set; }
        public IEnumerable<Talent> talents { get; set; }
    }
}
