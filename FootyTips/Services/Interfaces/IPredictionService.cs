using FootyTips.Models.DTOs;

namespace FootyTips.Services.Interfaces
{
    public interface IPredictionService
    {
        public Task<int> GetCount();
        public Task<GoalPrediction> GetPrediction(string homeTeam, string awayTeam);
    }
}
