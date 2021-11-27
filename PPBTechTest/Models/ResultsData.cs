using System;

namespace PPBTechTest.Models
{
    public class ResultsData
    {
        public ResultsData (bool homeTeamWinner, bool awayTeamWinnner, int homeTeamPoints, int awayTeamPoints)
        {
            this.HomeTeamWinner = homeTeamWinner;
            this.AwayTeamWinner = awayTeamWinnner;
            this.HomeTeamPoints = homeTeamPoints;
            this.AwayTeamPoints = awayTeamPoints;
        }
        public ResultsData(string simulationLine)
        {
            string[] values = simulationLine.Split(',');
            this.HomeTeamWinner = !values[0].Equals("0");
            this.AwayTeamWinner = !values[1].Equals("0");
            this.HomeTeamPoints = Int32.Parse(values[2]);
            this.AwayTeamPoints = Int32.Parse(values[3]);
            this.TotalPoints = this.HomeTeamPoints + this.AwayTeamPoints;
            this.HomeWinningMargin = this.AwayTeamPoints - this.HomeTeamPoints;
            this.AwayWinningMargin = this.HomeTeamPoints - this.AwayTeamPoints;
        }
        public bool HomeTeamWinner { get; }
        public bool AwayTeamWinner { get; }
        public int HomeTeamPoints { get; }
        public int AwayTeamPoints { get; }
        public int TotalPoints { get; }
        public int HomeWinningMargin { get; }
        public int AwayWinningMargin { get; }
    }
}
