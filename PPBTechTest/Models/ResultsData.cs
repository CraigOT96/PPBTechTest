﻿using System;

namespace PPBTechTest.Models
{
    public class ResultsData
    {
        public ResultsData(bool homeTeamWinner, bool awayTeamWinnner, int homeTeamPoints, int awayTeamPoints)
        {
            try
            {
                this.HomeTeamWinner = homeTeamWinner;
                this.AwayTeamWinner = awayTeamWinnner;
                this.HomeTeamPoints = homeTeamPoints;
                this.AwayTeamPoints = awayTeamPoints;
                this.TotalPoints = homeTeamPoints + awayTeamPoints;
                this.HomeWinningMargin = homeTeamPoints - awayTeamPoints;
                this.AwayWinningMargin = awayTeamPoints - homeTeamPoints;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }
        public ResultsData(string simulationLine)
        {
            try
            {
                string[] values = simulationLine.Split(',');
                this.HomeTeamWinner = Int32.Parse(values[0]) != 0;
                this.AwayTeamWinner = Int32.Parse(values[1]) != 0;
                this.HomeTeamPoints = Int32.Parse(values[2]);
                this.AwayTeamPoints = Int32.Parse(values[3]);
                this.TotalPoints = this.HomeTeamPoints + this.AwayTeamPoints;
                this.HomeWinningMargin = this.HomeTeamPoints - this.AwayTeamPoints;
                this.AwayWinningMargin = this.AwayTeamPoints - this.HomeTeamPoints;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid file line");
                Console.WriteLine(simulationLine);
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
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
