using FootyTips.Models.DTOs;
using FootyTips.Services.Interfaces;

namespace FootyTips.Services
{
    public class FootballDataTranslator : IFootballDataTranslator
    {
        public FootballDataRAW TranslateString(string raw)
        {
            var vals = raw.Split(",");

            return new FootballDataRAW()
            {
                Div = vals[0],
                KickOff = Convert.ToDateTime(vals[1] + " " + vals[2]),
                HomeTeam = vals[3],
                AwayTeam = vals[4],
                FTHomeGoals = int.Parse(vals[5]),
                FTAwayGoals = int.Parse(vals[6]),
                Referee= vals[11],
                HomeShots = int.Parse(vals[12]),
                AwayShots = int.Parse(vals[13]),
                HomeShotsOnTarget = int.Parse(vals[14]),
                AwayShotsOnTarget = int.Parse(vals[15]),
                HomeFouls = int.Parse(vals[16]),
                AwayFouls = int.Parse(vals[17]),
                HomeCorners = int.Parse(vals[18]),
                AwayCorners = int.Parse(vals[19]),
                HomeYellows = int.Parse(vals[20]),
                AwayYellows = int.Parse(vals[21]),
                HomeReds = int.Parse(vals[22]),
                AwayReds = int.Parse(vals[23])
            };
        }
    }
}
