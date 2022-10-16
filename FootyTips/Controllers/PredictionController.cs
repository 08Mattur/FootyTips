using FootyTips.Models.DTOs;
using FootyTips.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FootyTips.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictionController : ControllerBase
    {
        IPredictionService _predictionService;

        public PredictionController(IPredictionService predictionService)
        {
            _predictionService = predictionService;
        }

        [HttpGet("count")]
        public async Task<int> GetCount()
        {
            return await _predictionService.GetCount();
        }

        [HttpGet("goals")]
        public async Task<GoalPrediction> GetPrediction(string homeTeam, string awayTeam)
        {
            return await _predictionService.GetPrediction(homeTeam, awayTeam);
        }
    }
}
