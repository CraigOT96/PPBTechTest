using System;
using System.Collections.Generic;
using System.Text;

namespace PPBTechTest.Models
{
    public class SimulationResults
    {
        public SimulationResults (int recordCount, double median)
        {
            this.RecordCount = recordCount;
            this.Median = median;
        }
        private int RecordCount { get; set; }
        private double Median { get; set; }
        private int HomeWins { get; set; }
        private int AwayWins { get; set; }
        private int OverLine { get; set; }
        private int UnderLine { get; set; }
        private int HomeOverTenPoints { get; set; }
        private int HomeUnderTenPoints { get; set; }
        private int AwayOverTenPoints { get; set; }
        private int AwayUnderTenPoints { get; set; }

        public void PrintResults()
        {
            Console.WriteLine("Total Home Wins: " + this.HomeWins);
            Console.WriteLine("Total Away Wins: " + this.AwayWins);
            Console.WriteLine("Home Win Probability: " + CalculatePercent(this.HomeWins, this.RecordCount));
            Console.WriteLine("Away Win Probability: " + CalculatePercent(this.AwayWins, this.RecordCount));
            Console.WriteLine();
            Console.WriteLine("Total Over Line: " + this.OverLine);
            Console.WriteLine("Total Under Line: " + this.UnderLine);
            Console.WriteLine("Over Line Probability: " + CalculatePercent(this.OverLine, this.RecordCount));
            Console.WriteLine("Under Line Probability: " + CalculatePercent(this.UnderLine, this.RecordCount));
            Console.WriteLine();
            Console.WriteLine("Home Over Ten Points Win: " + this.HomeOverTenPoints);
            Console.WriteLine("Home Under or On Ten Points Win: " + this.HomeUnderTenPoints);
            Console.WriteLine("Away Over Ten Points Win: " + this.AwayOverTenPoints);
            Console.WriteLine("Away Under or On Ten Points Win: " + this.AwayUnderTenPoints);
            Console.WriteLine("Home Over Ten Points Probability: " + CalculatePercent(this.HomeOverTenPoints, this.RecordCount));
            Console.WriteLine("Home Under or On Ten Points Probability: " + CalculatePercent(this.HomeUnderTenPoints, this.RecordCount));
            Console.WriteLine("Away Over Ten Points Probability: " + CalculatePercent(this.AwayOverTenPoints, this.RecordCount));
            Console.WriteLine("Away Under or On Ten Points Probability: " + CalculatePercent(this.AwayUnderTenPoints, this.RecordCount));
        }

        public void AddSimulationData(ResultsData data)
        {
            try
            {
                if (data.HomeTeamWinner)
                    this.HomeWins++;
                else
                    this.AwayWins++;
                if (data.TotalPoints > this.Median)
                    this.OverLine++;
                else
                    this.UnderLine++;
                if (data.HomeWinningMargin >= 11)
                    this.HomeOverTenPoints++;
                else if (data.HomeWinningMargin <= 10 && data.HomeWinningMargin > -1)
                    this.HomeUnderTenPoints++;
                else if (data.AwayWinningMargin >= 11)
                    this.AwayOverTenPoints++;
                else if (data.AwayWinningMargin <= 10 && data.AwayWinningMargin > -1)
                    this.AwayUnderTenPoints++;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }

        private double CalculatePercent(int value, int total)
        {
            return (double)(1 * value) / total;
        }
    }
}
