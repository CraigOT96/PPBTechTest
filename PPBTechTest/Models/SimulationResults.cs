using System;
using System.Collections.Generic;
using System.Text;

namespace PPBTechTest.Models
{
    public class SimulationResults
    {
        public int RecordCount { get; set; }
        public int HomeWins { get; set; }
        public int AwayWins { get; set; }
        public int OverLine { get; set; }
        public int UnderLine { get; set; }
        public int HomeOverTenPoints { get; set; }
        public int HomeUnderTenPoints { get; set; }
        public int AwayOverTenPoints { get; set; }
        public int AwayUnderTenPoints { get; set; }

        public void PrintResults ()
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

        private double CalculatePercent(int value, int total)
        {
            return (double)(1 * value) / total;
        }
    }
}
