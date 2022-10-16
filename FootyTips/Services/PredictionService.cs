using FootyTips.Data;
using FootyTips.Models.DTOs;
using FootyTips.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FootyTips.Services
{
    public class PredictionService : IPredictionService
    {
        public async Task<int> GetCount()
        {
            //var matchCount = 0;

            //using (var db = new FootyTipsContext())
            //{
            //    matchCount = db.Matches.Count();
            //}

            //return matchCount;

            throw new NotImplementedException();
        }

        public async Task<GoalPrediction> GetPrediction(string homeTeam, string awayTeam)
        {
            var homeTeamMoreThan15 = 0;
            var awayTeamMoreThan15 = 0;
            var homeBTTS = 0;
            var awayBTTS = 0;
            var homeScoreMin1 = 0;
            var awayScoreMin1 = 0;

            using (var db = new FootyTipsContext())
            {
                var homeTeamPlayed = db.Matches.Include(x => x.Teams).Where(x => x.Teams.Any(y => y.Team.Name == homeTeam)).ToList();

                foreach (var homeMatch in homeTeamPlayed.Skip(Math.Max(0, homeTeamPlayed.Count() - 5)))
                {
                    var homeGoals = homeMatch.Teams[0].Goals;
                    var awayGoals = homeMatch.Teams[1].Goals;
                    if (homeGoals + awayGoals > 1)
                    {
                        homeTeamMoreThan15++;
                    }
                    if (homeGoals > 0 && awayGoals > 0)
                    {
                        homeBTTS++;
                    }
                    if (homeGoals > 0)
                    {
                        homeScoreMin1++;
                    }
                }

                var awayTeamPlayed = db.Matches.Include(x => x.Teams).Where(x => x.Teams.Any(y => y.Team.Name == awayTeam)).ToList();
                foreach (var awayMatch in awayTeamPlayed.Skip(Math.Max(0, awayTeamPlayed.Count() - 5)))
                {
                    var homeGoals = awayMatch.Teams[0].Goals;
                    var awayGoals = awayMatch.Teams[1].Goals;
                    if (homeGoals + awayGoals > 1)
                    {
                        awayTeamMoreThan15++;
                    }
                    if (homeGoals > 0 && awayGoals > 0)
                    {
                        awayBTTS++;
                    }
                    if (homeGoals > 0)
                    {
                        awayScoreMin1++;
                    }
                }
            }

            return new GoalPrediction()
            {
                HomeMoreThan15Goals = homeTeamMoreThan15,
                HomeBTTS = homeBTTS,
                HomeScoreMin1 = homeScoreMin1,
                AwayMoreThan15Goals = awayTeamMoreThan15,
                AwayBTTS = awayBTTS,
                AwayScoreMin1 = awayScoreMin1
            };

        }
    }
}
