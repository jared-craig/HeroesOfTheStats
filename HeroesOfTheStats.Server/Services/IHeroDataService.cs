using System.Collections.Generic;
using System.Threading.Tasks;
using HeroesOfTheStats.Shared.DTOs;

namespace HeroesOfTheStats.Server.Services
{
    public interface IHeroDataService
    {
        Task<IEnumerable<HeroDto>> InitializeHeroes();
        HeroDto GetHeroDetails(string heroShortName);
        Task CalculateWinRates();
        IEnumerable<HeroDto> GetAllHeroes();
    }
}
