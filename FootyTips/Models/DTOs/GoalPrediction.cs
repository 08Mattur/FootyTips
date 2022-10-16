namespace FootyTips.Models.DTOs
{
    public class GoalPrediction
    {
        public int HomeMoreThan15Goals { get; set; }
        public double HomeMoreThan15GoalsPercent
        {
            get
            {
                return HomeMoreThan15Goals / 5.00;
            }
        }
        public int HomeBTTS { get; set; }
        public double HomeBTTSPercent
        {
            get
            {
                return HomeBTTS / 5.00;
            }
        }
        public int HomeScoreMin1 { get; set; }
        public double HomeScoreMin1Percent
        {
            get
            {
                return HomeScoreMin1 / 5.00;
            }
        }

        public int AwayMoreThan15Goals { get; set; }
        public double AwayMoreThan15GoalsPercent
        {
            get
            {
                return AwayMoreThan15Goals / 5.00;
            }
        }
        public int AwayBTTS { get; set; }
        public double AwayBTTSPercent
        {
            get
            {
                return AwayBTTS / 5.00;
            }
        }
        public int AwayScoreMin1 { get; set; }
        public double AwayScoreMin1Percent
        {
            get
            {
                return AwayScoreMin1 / 5.00;
            }
        }


        public double MoreThan15Percent
        {
            get
            {
                return HomeMoreThan15GoalsPercent * AwayMoreThan15GoalsPercent;
            }
        }

        public double BTTSPercent
        {
            get
            {
                return HomeBTTSPercent * AwayBTTSPercent;
            }
        }
    }
}
