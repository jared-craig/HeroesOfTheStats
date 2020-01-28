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

        protected override async Task OnInitializedAsync()
        {
            Heroes = (await HeroDataService.CalculateWinRates()).OrderByDescending(x => x.win_rate).ToList();
        }
    }
}
