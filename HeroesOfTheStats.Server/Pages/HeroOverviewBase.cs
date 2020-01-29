using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroesOfTheStats.Server.Services;
using HeroesOfTheStats.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace HeroesOfTheStats.Server.Pages
{
    public class HeroOverviewBase : ComponentBase
    {
        [Inject]
        public IHeroDataService HeroDataService { get; set; }
        
        public IEnumerable<HeroDto> Heroes { get; set; }

        public IEnumerable<HeroDto> FilteredHeroes => Heroes
            .Where(h => h.Name.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            .OrderByDescending(h => h.WinRate).ToList();

        public string SearchTerm { get; set; } = "";

        protected override async Task OnInitializedAsync()
        {
            await HeroDataService.CalculateWinRates();
            Heroes = HeroDataService.GetAllHeroes().OrderByDescending(x => x.WinRate);
        }
    }
}
