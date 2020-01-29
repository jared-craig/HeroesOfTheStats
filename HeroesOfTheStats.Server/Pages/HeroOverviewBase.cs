using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroesOfTheStats.Server.Services;
using HeroesOfTheStats.Shared;
using Microsoft.AspNetCore.Components;

namespace HeroesOfTheStats.Server.Pages
{
    public class HeroOverviewBase : ComponentBase
    {
        [Inject]
        public IHeroDataService HeroDataService { get; set; }
        
        public IEnumerable<Hero> Heroes { get; set; }

        public IEnumerable<Hero> FilteredHeroes => Heroes
            .Where(h => h.name.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            .OrderByDescending(h => h.win_rate).ToList();

        public string SearchTerm { get; set; } = "";

        protected override async Task OnInitializedAsync()
        {
            await HeroDataService.CalculateWinRates();
            Heroes = HeroDataService.GetAllHeroes().OrderByDescending(x => x.win_rate).ToList();
        }
    }
}
