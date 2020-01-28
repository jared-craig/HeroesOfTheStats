using System.Threading.Tasks;
using HeroesOfTheStats.Server.Services;
using HeroesOfTheStats.Shared;
using Microsoft.AspNetCore.Components;

namespace HeroesOfTheStats.Server.Pages
{
    public class HeroDetailBase : ComponentBase
    {
        [Parameter]
        public string HeroShortName { get; set; }

        [Inject]
        public IHeroDataService HeroDataService { get; set; }

        public Hero Hero { get; set; } = new Hero();

        protected override void OnInitialized()
        {
            Hero = HeroDataService.GetHeroDetails(HeroShortName);
        }
    }
}
