using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using HeroesOfTheStats.Shared;
using HeroesOfTheStats.Shared.DTOs;
using HeroesOfTheStats.Shared.Entities;

namespace HeroesOfTheStats.Server.Services
{
    public class HeroDataService : IHeroDataService
    {
        private readonly HttpClient _httpClient;
        private List<HeroDto> _heroes;

        public HeroDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IEnumerable<HeroDto> GetAllHeroes()
        {
            return _heroes;
        }

        public async Task<IEnumerable<HeroDto>> InitializeHeroes()
        {
            var heroes = await JsonSerializer.DeserializeAsync<IEnumerable<Hero>>(
                await _httpClient.GetStreamAsync("heroes"),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            return heroes.Select(Mapper.MapHero).ToList();
        }

        public HeroDto GetHeroDetails(string heroShortName)
        {
            return _heroes.First(h => h.ShortName.Equals(heroShortName, StringComparison.OrdinalIgnoreCase));
        }

        public async Task CalculateWinRates()
        {
            var replays = await GetReplays(1337, true);
            var heroes = (await InitializeHeroes()).ToList();
            foreach (var replay in replays)
            {
                foreach (var player in replay.Players)
                {
                    if (player.Winner)
                    {
                        heroes.First(h => h.Name.Equals(player.Hero, StringComparison.OrdinalIgnoreCase)).Wins++;
                    }
                    else
                    {
                        heroes.First(h => h.Name.Equals(player.Hero, StringComparison.OrdinalIgnoreCase)).Loses++;
                    }
                }
            }

            foreach (var hero in heroes)
            {
                hero.WinRate = (hero.Wins + hero.Loses) <= 0 ? 0.0 : Math.Round(hero.Wins / (hero.Wins + hero.Loses) * 100, 2);
            }

            _heroes = heroes;
        }

        private async Task<IEnumerable<ReplayDto>> GetReplays(int minParsedId, bool withPlayers)
        {
            var replays = await JsonSerializer.DeserializeAsync<IEnumerable<Replay>>(
                await _httpClient.GetStreamAsync($"replays/parsed?min_parsed_id={minParsedId}&with_players={withPlayers}"),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            return replays.Select(Mapper.MapReplay).ToList();
        }
    }
}
