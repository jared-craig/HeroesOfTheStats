using System.Collections.Generic;
using System.Threading.Tasks;
using HeroesOfTheStats.Shared;

namespace HeroesOfTheStats.Server.Services
{
    public interface IHeroDataService
    {
        Task<IEnumerable<Hero>> GetAllHeroes();
        Task<Hero> GetHeroDetails(string heroShortName);
        Task<IEnumerable<Hero>> CalculateWinRates();
    }
}
