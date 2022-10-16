using FootyTips.Data;
using FootyTips.Data.Models;
using FootyTips.Models.DTOs;
using FootyTips.Services.Interfaces;

namespace FootyTips.Services
{
    public class DataDownloadService : IDataDownloadService
    {
        IFootballDataTranslator _dataTranslator;

        public DataDownloadService(IFootballDataTranslator footballDataTranslator)
        {
            _dataTranslator = footballDataTranslator;
        }

        public async Task<int> Download(string url)
        {
            List<string> dataRows = await RetrieveRowsFromCSV(url);

            var rawData = CreateRawObjects(dataRows);

            var savedRecords = SaveToDatabase(rawData);

            return savedRecords;
        }

        public async Task<List<FootballDataRAW>> TestFile(string url)
        {
            List<string> dataRows = await RetrieveRowsFromCSV(url);

            return CreateRawObjects(dataRows);
        }

        private async Task<List<string>> RetrieveRowsFromCSV(string url)
        {
            var dataRows = new List<string>();

            using (var client = new HttpClient())
            using (var response = await client.GetAsync(url))
            using (var content = response.Content)
            using (var stream = (MemoryStream)await content.ReadAsStreamAsync())
            using (var sr = new StreamReader(stream))
            {
                while (!sr.EndOfStream)
                {
                    var data = sr.ReadLine();
                    if (!string.IsNullOrEmpty(data))
                    {
                        dataRows.Add(data);
                    }
                }
            }

            return dataRows;
        }

        private List<FootballDataRAW> CreateRawObjects (List<string> dataRows)
        {
            var rawData = new List<FootballDataRAW>();

            dataRows.RemoveAt(0);

            foreach (var row in dataRows)
            {
                rawData.Add(_dataTranslator.TranslateString(row));
            }

            return rawData;
        }

        private int SaveToDatabase (List<FootballDataRAW> matches)
        {
            var intSaved = 0;

            using (var db = new FootyTipsContext())
            {
                foreach (var matchRaw in matches)
                {
                    int refereeId = GetReferee(db, matchRaw);
                    int homeTeamId = GetHomeTeam(db, matchRaw);
                    int awayTeamId = GetAwayTeam(db, matchRaw);

                    var matchId = db.Matches.Where(x => x.RefereeId == refereeId &&x.KickOff == matchRaw.KickOff).Select(x => x.Id).FirstOrDefault();

                    if (matchId == 0)
                    {
                        var match = CreateMatch(db, matchRaw, refereeId);
                        var homeTeamMatch = CreateHomeTeamMatch(db, matchRaw, homeTeamId, match.Id);
                        var awayTeamMatch = CreateAwayTeamMatch(db, matchRaw, awayTeamId, match.Id);
                        
                        intSaved++;
                    }
                }
            }           

            return intSaved;
        }

        private TeamMatch CreateHomeTeamMatch(FootyTipsContext db, FootballDataRAW matchRaw, int homeTeamId, int matchId)
        {
            var homeTeamMatch = new TeamMatch()
            {
                IsHome = true,
                Goals = matchRaw.FTHomeGoals,
                Shots = matchRaw.HomeShots,
                ShotsOnTarget = matchRaw.HomeShotsOnTarget,
                Fouls = matchRaw.HomeFouls,
                Corners = matchRaw.HomeCorners,
                TeamId = homeTeamId,
                MatchId = matchId
            };
            db.TeamMatches.Add(homeTeamMatch);
            db.SaveChanges();

            return homeTeamMatch;
        }

        private TeamMatch CreateAwayTeamMatch(FootyTipsContext db, FootballDataRAW matchRaw, int awayTeamId, int matchId)
        {
            var awayTeamMatch = new TeamMatch()
            {
                IsHome = false,
                Goals = matchRaw.FTAwayGoals,
                Shots = matchRaw.AwayShots,
                ShotsOnTarget = matchRaw.AwayShotsOnTarget,
                Fouls = matchRaw.AwayFouls,
                Corners = matchRaw.AwayCorners,
                TeamId = awayTeamId,
                MatchId = matchId
            };

            db.TeamMatches.Add(awayTeamMatch);
            db.SaveChanges();
            return awayTeamMatch;
        }



        private Match CreateMatch(FootyTipsContext db, FootballDataRAW matchRaw, int refereeId)
        {
            var teams = new List<TeamMatch>();

            var match = new Match()
            {
                KickOff = matchRaw.KickOff,
                RefereeId = refereeId,
                Teams = teams,
                Referee = db.Referees.Where(x => x.Id == refereeId).Single()
            };
            db.Matches.Add(match);
            db.SaveChanges();
            return match;
        }

        private int GetAwayTeam(FootyTipsContext db, FootballDataRAW matchRaw)
        {
            var awayTeamId = db.Teams.Where(x => x.Name == matchRaw.AwayTeam).Select(x => x.Id).SingleOrDefault();

            if (awayTeamId == 0)
            {
                var team = new Team()
                {
                    Name = matchRaw.AwayTeam,
                    ShortName = matchRaw.AwayTeam.Substring(0, 3),
                    HomeGround = "Unknown ATM"
                };
                db.Teams.Add(team);
                db.SaveChanges();
                awayTeamId = team.Id;
            }

            return awayTeamId;
        }

        private int GetHomeTeam(FootyTipsContext db, FootballDataRAW matchRaw)
        {
            var homeTeamId = db.Teams.Where(x => x.Name == matchRaw.HomeTeam).Select(x => x.Id).SingleOrDefault();

            if (homeTeamId == 0)
            {
                var team = new Team()
                {
                    Name = matchRaw.HomeTeam,
                    ShortName = matchRaw.HomeTeam.Substring(0, 3),
                    HomeGround = "Unknown ATM"
                };
                db.Teams.Add(team);
                db.SaveChanges();
                homeTeamId = team.Id;
            }

            return homeTeamId;
        }

        private int GetReferee(FootyTipsContext db, FootballDataRAW matchRaw)
        {
            var refereeId = db.Referees.Where(x => x.Name == matchRaw.Referee).Select(x => x.Id).SingleOrDefault();

            if (refereeId == 0)
            {
                var referee = new Referee()
                {
                    Name = matchRaw.Referee
                };
                db.Referees.Add(referee);
                db.SaveChanges();
                refereeId = referee.Id;
            }

            return refereeId;
        }

    }
}
