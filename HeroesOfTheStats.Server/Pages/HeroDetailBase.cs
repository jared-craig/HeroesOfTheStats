using HeroesOfTheStats.Server.Services;
using HeroesOfTheStats.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace HeroesOfTheStats.Server.Pages
{
    public class HeroDetailBase : ComponentBase
    {
        [Parameter]
        public string HeroShortName { get; set; }

        [Inject]
        public IHeroDataService HeroDataService { get; set; }

        public HeroDto Hero { get; set; } = new HeroDto();

        protected override void OnInitialized()
        {
            Hero = HeroDataService.GetHeroDetails(HeroShortName);
        }
    }
}
