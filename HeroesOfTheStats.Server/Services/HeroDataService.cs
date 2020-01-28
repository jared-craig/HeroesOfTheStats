using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using HeroesOfTheStats.Shared;

namespace HeroesOfTheStats.Server.Services
{
    public class HeroDataService : IHeroDataService
    {
        private readonly HttpClient _httpClient;

        public HeroDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Hero>> GetAllHeroes()
        {
            var heroes = await JsonSerializer.DeserializeAsync<IEnumerable<Hero>>(
                await _httpClient.GetStreamAsync("heroes"),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            return heroes;
        }

        public async Task<Hero> GetHeroDetails(string heroShortName)
        {
            var hero = await JsonSerializer.DeserializeAsync<Hero>(
                await _httpClient.GetStreamAsync($"heroes/{heroShortName}"),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            return hero;
        }

        public async Task<IEnumerable<Hero>> CalculateWinRates()
        {
            var replays = await GetReplays(1337, true);
            var heroes = (await GetAllHeroes()).ToList();
            foreach (var replay in replays)
            {
                foreach (var player in replay.players)
                {
                    if (player.winner)
                    {
                        heroes.First(h => h.name.Equals(player.hero, StringComparison.OrdinalIgnoreCase)).wins++;
                    }
                    else
                    {
                        heroes.First(h => h.name.Equals(player.hero, StringComparison.OrdinalIgnoreCase)).loses++;
                    }
                }
            }

            foreach (var hero in heroes)
            {
                hero.win_rate = (hero.wins + hero.loses) <= 0 ? 0.0 : Math.Round((hero.wins / (hero.wins + hero.loses) * 100), 2);
            }

            return heroes;
        }

        private async Task<IEnumerable<Replay>> GetReplays(int minParsedId, bool withPlayers)
        {
            var replays = await JsonSerializer.DeserializeAsync<IEnumerable<Replay>>(
                await _httpClient.GetStreamAsync($"replays/parsed?min_parsed_id={minParsedId}&with_players={withPlayers}"),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            return replays;
        }
    }
}
