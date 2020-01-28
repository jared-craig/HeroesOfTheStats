namespace HeroesOfTheStats.Shared
{
    public class Score
    {
        public int? level { get; set; }
        public int? kills { get; set; }
        public int? assists { get; set; }
        public int? takedowns { get; set; }
        public int? deaths { get; set; }
        public int? highest_kill_streak { get; set; }
        public int? hero_damage { get; set; }
        public int? siege_damage { get; set; }
        public int? structure_damage { get; set; }
        public int? minion_damage { get; set; }
        public int? creep_damage { get; set; }
        public int? summon_damage { get; set; }
        public int? time_cc_enemy_heroes { get; set; }
        public int? healing { get; set; }
        public int? self_healing { get; set; }
        public int? damage_taken { get; set; }
        public int? experience_contribution { get; set; }
        public int? town_kills { get; set; }
        public int? merc_camp_captures { get; set; }
        public int? watch_tower_captures { get; set; }
        public int? meta_experience { get; set; }
    }
}