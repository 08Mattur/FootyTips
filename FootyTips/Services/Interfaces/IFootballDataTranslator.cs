using FootyTips.Models.DTOs;

namespace FootyTips.Services.Interfaces
{
    public interface IFootballDataTranslator
    {
        public FootballDataRAW TranslateString(string raw);
    }
}
