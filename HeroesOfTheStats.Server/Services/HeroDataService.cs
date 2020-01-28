using System;
using System.Collections.Generic;
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
        private List<Hero> _heroes;

        public HeroDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IEnumerable<Hero> GetAllHeroes()
        {
            return _heroes;
        }

        public async Task<IEnumerable<Hero>> InitializeHeroes()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Hero>>(
                await _httpClient.GetStreamAsync("heroes"),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
        }

        public Hero GetHeroDetails(string heroShortName)
        {
            return _heroes.First(h => h.short_name.Equals(heroShortName, StringComparison.OrdinalIgnoreCase));
        }

        public async Task CalculateWinRates()
        {
            var replays = await GetReplays(1337, true);
            var heroes = (await InitializeHeroes()).ToList();
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

            _heroes = heroes;
        }

        private async Task<IEnumerable<Replay>> GetReplays(int minParsedId, bool withPlayers)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Replay>>(
                await _httpClient.GetStreamAsync($"replays/parsed?min_parsed_id={minParsedId}&with_players={withPlayers}"),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
        }
    }
}
