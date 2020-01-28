using System.Collections.Generic;
using System.Threading.Tasks;
using HeroesOfTheStats.Shared;

namespace HeroesOfTheStats.Server.Services
{
    public interface IHeroDataService
    {
        Task<IEnumerable<Hero>> InitializeHeroes();
        Hero GetHeroDetails(string heroShortName);
        Task CalculateWinRates();
        IEnumerable<Hero> GetAllHeroes();
    }
}
