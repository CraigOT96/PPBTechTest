using PPBTechTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PPBTechTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ResultsData> simulationData = GetSimulationData();

            double median = GetMedian(simulationData);

            LinkedList<ResultsData> linkedSimulationData = new LinkedList<ResultsData>(simulationData);

            IEnumerator<ResultsData> simulationDataIter = linkedSimulationData.GetEnumerator();

            int homeWins = 0;
            int awayWins = 0;
            int overLine = 0;
            int underLine = 0;
            int homeOverTenPoints = 0;
            int homeUnderTenPoints = 0;
            int awayOverTenPoints = 0;
            int awayUnderTenPoints = 0;

            while (simulationDataIter.MoveNext())
            {
                if (simulationDataIter.Current.HomeTeamWinner)
                    homeWins++;
                else
                    awayWins++;
                if (simulationDataIter.Current.TotalPoints > median)
                    overLine++;
                else
                    underLine++;
                if (simulationDataIter.Current.HomeWinningMargin >= 11)
                    homeOverTenPoints++;
                else if (simulationDataIter.Current.HomeWinningMargin <= 10 && simulationDataIter.Current.HomeWinningMargin > -1)
                    homeUnderTenPoints++;
                else if(simulationDataIter.Current.AwayWinningMargin >= 11)
                    awayOverTenPoints++;
                else if (simulationDataIter.Current.AwayWinningMargin <= 10 && simulationDataIter.Current.AwayWinningMargin > -1)
                    awayUnderTenPoints++;
            }

            PrintResults(homeWins, awayWins, overLine, underLine, homeOverTenPoints, homeUnderTenPoints, awayOverTenPoints, awayUnderTenPoints);
        }

        static List<ResultsData> GetSimulationData()
        {
            return new List<ResultsData>(File
                        .ReadLines("Data/GameResults.csv")
                        .Skip(1)
                        .Select(x => new ResultsData(x))
                        .OrderBy(x => x.TotalPoints)
                        .ToList());
        }

        public static double GetMedian(List<ResultsData> simulationData)
        {
            int middle = simulationData.Count / 2;
            return ((simulationData.Count % 2 != 0) ? (double)simulationData[middle].TotalPoints : ((double)simulationData[middle].TotalPoints + (double)simulationData[middle - 1].TotalPoints) / 2) + .5;
        }

        private static void PrintResults(int homeWins, int awayWins, int overLine, int underLine, int homeOverTenPoints, int homeUnderTenPoints, int awayOverTenPoints, int awayUnderTenPoints)
        {
            double homePercent = (double)(1 * homeWins) / 20000;
            double awayPercent = (double)(1 * awayWins) / 20000;
            double overPercent = (double)(1 * overLine) / 20000;
            double underPercent = (double)(1 * underLine) / 20000;
            double homeOverTenPointsPercent = (double)(1 * homeOverTenPoints) / 20000;
            double homeUnderTenPointsPercent = (double)(1 * homeUnderTenPoints) / 20000;
            double awayOverTenPointsPercent = (double)(1 * awayOverTenPoints) / 20000;
            double awayUnderTenPointsPercent = (double)(1 * awayUnderTenPoints) / 20000;
            Console.WriteLine("Total Home Wins: " + homeWins);
            Console.WriteLine("Total Away Wins: " + awayWins);
            Console.WriteLine("Home Win Probability: " + homePercent);
            Console.WriteLine("Away Win Probability: " + awayPercent);
            Console.WriteLine("Total: " + (homePercent + awayPercent));
            Console.WriteLine();
            Console.WriteLine("Total Over Line: " + overLine);
            Console.WriteLine("Total Under Line: " + underLine);
            Console.WriteLine("Over Line Probability: " + overPercent);
            Console.WriteLine("Under Line Probability: " + underPercent);
            Console.WriteLine("Total: " + (overPercent + underPercent));
            Console.WriteLine();
            Console.WriteLine("Home Over Ten Points Win: " + homeOverTenPoints);
            Console.WriteLine("Home Under or On Ten Points Win: " + homeUnderTenPoints);
            Console.WriteLine("Away Over Ten Points Win: " + awayOverTenPoints);
            Console.WriteLine("Away Under or On Ten Points Win: " + awayUnderTenPoints);
            Console.WriteLine("Home Over Ten Points Probability: " + homeOverTenPointsPercent);
            Console.WriteLine("Home Under or On Ten Points Probability: " + homeUnderTenPointsPercent);
            Console.WriteLine("Away Over Ten Points Probability: " + awayOverTenPointsPercent);
            Console.WriteLine("Away Under or On Ten Points Probability: " + awayUnderTenPointsPercent);
            Console.WriteLine("Total: " + (homeOverTenPointsPercent + homeUnderTenPointsPercent + awayOverTenPointsPercent + awayUnderTenPointsPercent));
        }
    }
}
