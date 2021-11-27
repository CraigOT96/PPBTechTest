using PPBTechTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PPBTechTest
{
    public class SpeedTests
    {
        public static void RunSpeedTests(int loops)
        {
            double hashSpeedIterAverage = 0;
            double hashSpeedLinqAverage = 0;
            double linkedListIterAverage = 0;
            double linkedListLinqAverage = 0;
            double listIterAverage = 0;
            double listLinqAverage = 0;

            for (int i = 0; i < loops; i++)
            {
                hashSpeedIterAverage += RunTest("Hash Set Iterator", "HashSet", true);
                hashSpeedLinqAverage += RunTest("Hash Set Linq", "HashSet", false);

                linkedListIterAverage += RunTest("Linked List Iterator", "LinkedList", true);
                linkedListLinqAverage += RunTest("Linked List Linq", "LinkedList", false);

                listIterAverage += RunTest("Linked List Iterator", "List", true);
                listLinqAverage += RunTest("Linked List Linq", "List", false);
            }

            Console.WriteLine();
            Console.WriteLine("Hash Speed Iter Avg: " + (double)(hashSpeedIterAverage / loops));
            Console.WriteLine("Hash Speed Linq Avg: " + (double)(hashSpeedLinqAverage / loops));
            Console.WriteLine("Linked List Iter Avg: " + (double)(linkedListIterAverage / loops));
            Console.WriteLine("Linked List Linq Avg: " + (double)(linkedListLinqAverage / loops));
            Console.WriteLine("List Iter Avg: " + (double)(listIterAverage / loops));
            Console.WriteLine("List Linq Avg: " + (double)(listLinqAverage / loops));
        }

        private static long RunTest(string testName, string dataType, bool useIterator)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            Console.WriteLine(testName);

            int homeWins = 0;
            int awayWins = 0;
            int overChance = 0;
            int underChance = 0;

            List<ResultsData> data = File
                        .ReadLines("Data/GameResults.csv")
                        .Skip(1)
                        .Select(x => new ResultsData(x))
                        .OrderBy(x => x.TotalPoints)
                        .ToList();

            double median = GetMedian(data);

            var source = ConvertData(dataType, data);

            if (useIterator)
                ProbabilityIterator(source.GetEnumerator(), median, out homeWins, out awayWins, out overChance, out underChance);
            else
                ProbabilityLinq(source, median, out homeWins, out awayWins, out overChance, out underChance);

            PrintTestResults(homeWins, awayWins, overChance, underChance);

            watch.Stop();

            Console.WriteLine("Total time: " + watch.ElapsedMilliseconds + "ms");

            return watch.ElapsedMilliseconds;
        }

        private static ICollection<ResultsData> ConvertData(string type, ICollection<ResultsData> data)
        {
            switch (type)
            {
                case "HashSet":
                    return new HashSet<ResultsData>(data);
                case "LinkedList":
                    return new LinkedList<ResultsData>(data);
                case "List":
                    return new List<ResultsData>(data);
                default:
                    return new List<ResultsData>(data);
            }
        }

        private static double GetMedian(List<ResultsData> simulationData)
        {
            int middle = simulationData.Count / 2;
            return ((simulationData.Count % 2 != 0) ? (double)simulationData[middle].TotalPoints : ((double)simulationData[middle].TotalPoints + (double)simulationData[middle - 1].TotalPoints) / 2) + .5;
        }

        private static void ProbabilityIterator(IEnumerator<ResultsData> data, double median, out int homeWins, out int awayWins, out int overChance, out int underChance)
        {
            homeWins = 0;
            awayWins = 0;
            overChance = 0;
            underChance = 0;

            while (data.MoveNext())
            {
                if (data.Current.HomeTeamWinner)
                    homeWins++;
                else
                    awayWins++;
                if (data.Current.TotalPoints > median)
                    overChance++;
                else
                    underChance++;
            }
        }
        private static void ProbabilityLinq(ICollection<ResultsData> data, double median, out int homeWins, out int awayWins, out int overChance, out int underChance)
        {
            homeWins = data.Where(x => x.HomeTeamWinner).Count();
            awayWins = data.Where(x => x.AwayTeamWinner).Count();
            overChance = data.Where(x => x.TotalPoints > median).Count();
            underChance = data.Where(x => x.TotalPoints < median).Count();
        }

        private static void PrintTestResults(int homeWins, int awayWins, int overChance, int underChance)
        {
            double homePercent = (double)(1 * homeWins) / 20000;
            double awayPercent = (double)(1 * awayWins) / 20000;
            double overPercent = (double)(1 * overChance) / 20000;
            double underPercent = (double)(1 * underChance) / 20000;
            Console.WriteLine("Total Home Wins: " + homeWins);
            Console.WriteLine("Total Away Wins: " + awayWins);
            Console.WriteLine("Home Win Probability: " + homePercent);
            Console.WriteLine("Away Win Probability: " + awayPercent);
            Console.WriteLine("Total: " + (homePercent + awayPercent));
            Console.WriteLine();
            Console.WriteLine("Total Over Line: " + overChance);
            Console.WriteLine("Total Under Line: " + underChance);
            Console.WriteLine("Over Line Probability: " + overPercent);
            Console.WriteLine("Under Line Probability: " + underPercent);
            Console.WriteLine("Total: " + (overPercent + underPercent));
        }
    }
}
