using System.Linq;
using HeroesOfTheStats.Shared.DTOs;
using HeroesOfTheStats.Shared.Entities;

namespace HeroesOfTheStats.Shared
{
    public static class Mapper
    {
        public static AbilityDto MapAbility(Ability ability)
        {
            if (ability == null)
                return new AbilityDto();

            var newAbilityDto = new AbilityDto
            {
                Owner = ability.owner,
                Name = ability.name,
                Title = ability.title,
                Description = ability.description,
                Icon = ability.icon,
                HotKey = ability.hotkey,
                Cooldown = ability.cooldown,
                ManaCost = ability.mana_cost,
                IsTrait = ability.trait
            };

            return newAbilityDto;
        }

        public static HeroDto MapHero(Hero hero)
        {
            if (hero == null)
                return new HeroDto();

            var newHeroDto = new HeroDto
            {
                Wins = hero.wins,
                Loses = hero.loses,
                WinRate = hero.win_rate,
                Name = hero.name,
                ShortName = hero.short_name,
                AttributeId = hero.attribute_id,
                CHeroId = hero.c_hero_id,
                CUnitId = hero.c_unit_id,
                Translations = hero.translations.ToList(),
                IconUrl = hero.icon_url,
                Role = hero.role,
                Type = hero.type,
                ReleaseDate = hero.release_date,
                ReleasePatch = hero.release_patch,
                Abilities = hero.abilities.Select(MapAbility).ToList(),
                Talents = hero.talents.Select(MapTalent).ToList()
            };

            return newHeroDto;
        }

        public static PlayerDto MapPlayer(Player player)
        {
            if (player == null)
                return new PlayerDto();

            var newPlayerDto = new PlayerDto
            {
                BattleTag = player.battletag,
                Hero = player.hero,
                HeroLevel = player.hero_level,
                Team = player.team,
                Winner = player.winner,
                BlizzId = player.blizz_id,
                IsSilenced = player.silenced,
                Party = player.party,
                Talents = player.talents,
                Score = MapScore(player.score)
            };

            return newPlayerDto;
        }

        public static ReplayDto MapReplay(Replay replay)
        {
            if (replay == null)
                return new ReplayDto();

            var newReplayDto = new ReplayDto
            {
                Id = replay.id,
                Filename = replay.filename,
                Size = replay.size,
                GameType = replay.game_type,
                GameDate = replay.game_date,
                GameLength = replay.game_length,
                GameMap = replay.game_map,
                GameVersion = replay.game_version,
                Region = replay.region,
                Fingerprint = replay.fingerprint,
                Url = replay.url,
                IsProcessed = replay.processed,
                IsDeleted = replay.deleted,
                Bans = replay.bans?.ToList(),
                Players = replay.players.Select(MapPlayer).ToList(),
                Teams = replay.teams.Select(MapTeam).ToList()
            };

            return newReplayDto;
        }

        public static ScoreDto MapScore(Score score)
        {
            if (score == null)
                return new ScoreDto();

            var newScoreDto = new ScoreDto
            {
                Level = score.level,
                Kills = score.kills,
                Assists = score.assists,
                Takedowns = score.takedowns,
                Deaths = score.deaths,
                HighestKillStreak = score.highest_kill_streak,
                HeroDamage = score.hero_damage,
                SiegeDamage = score.siege_damage,
                StructureDamage = score.structure_damage,
                MinionDamage = score.minion_damage,
                CreepDamage = score.creep_damage,
                SummonDamage = score.summon_damage,
                TimeCcEnemyHeroes = score.time_cc_enemy_heroes,
                Healing = score.healing,
                SelfHealing = score.self_healing,
                DamageTaken = score.damage_taken,
                ExperienceContribution = score.experience_contribution,
                TownKills = score.town_kills,
                MercCampCaptures = score.merc_camp_captures,
                WatchTowerCaptures = score.watch_tower_captures,
                MetaExperience = score.meta_experience
            };

            return newScoreDto;
        }

        public static TalentDto MapTalent(Talent talent)
        {
            if (talent == null)
                return new TalentDto();

            var newTalentDto = new TalentDto
            {
                Name = talent.name,
                Title = talent.title,
                Description = talent.description,
                Icon = talent.icon,
                IconUrl = talent.icon_url,
                Ability = talent.ability,
                Sort = talent.sort,
                Cooldown = talent.cooldown,
                ManaCost = talent.mana_cost,
                Level = talent.level
            };

            return newTalentDto;
        }

        public static TeamDto MapTeam(Team team)
        {
            if (team == null)
                return new TeamDto();

            var newTeamDto = new TeamDto
            {
                Winner = team.winner,
                TeamLevel = team.team_level,
                StructureXp = team.structure_xp,
                CreepXp = team.creep_xp,
                HeroXp = team.hero_xp,
                MinionXp = team.minion_xp,
                TrickleXp = team.trickle_xp,
                TotalXp = team.total_xp
            };

            return newTeamDto;
        }
    }
}
