using PPBTechTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PPBTechTest.SpeedTests
{
    public class SpeedTests
    {
        public static long HashSpeedIter()
        {
            Console.WriteLine("HashSpeedIter");

            int homeWins = 0;
            int awayWins = 0;
            int overChance = 0;
            int underChance = 0;

            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<ResultsData> simulationData = (List<ResultsData>)GetData("List");

            double median = GetMedian(simulationData);

            ProbabilityIter(simulationData.GetEnumerator(), median, out homeWins, out awayWins, out overChance, out underChance);

            PrintResults(homeWins, awayWins, overChance, underChance);

            watch.Stop();

            Console.WriteLine("Total time: " + watch.ElapsedMilliseconds + "ms");

            return watch.ElapsedMilliseconds;
        }

        public static long HashSpeedLinq()
        {
            Console.WriteLine("HashSpeedLinq");

            int homeWins = 0;
            int awayWins = 0;
            int overChance = 0;
            int underChance = 0;

            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<ResultsData> simulationData = (List<ResultsData>)GetData("List");

            double median = GetMedian(simulationData);

            HashSet<ResultsData> source = new HashSet<ResultsData>(simulationData);

            WinProbabilityLinq(simulationData, median, out homeWins, out awayWins, out overChance, out underChance);

            PrintResults(homeWins, awayWins, overChance, underChance);

            watch.Stop();

            Console.WriteLine("Total time: " + watch.ElapsedMilliseconds + "ms");

            return watch.ElapsedMilliseconds;
        }

        public static long LinkedListIter()
        {
            Console.WriteLine("LinkedListIter");

            int homeWins = 0;
            int awayWins = 0;
            int overChance = 0;
            int underChance = 0;

            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<ResultsData> simulationData = (List<ResultsData>)GetData("List");

            double median = GetMedian(simulationData);

            LinkedList<ResultsData> source = new LinkedList<ResultsData>(simulationData);

            ProbabilityIter(simulationData.GetEnumerator(), median, out homeWins, out awayWins, out overChance, out underChance);

            PrintResults(homeWins, awayWins, overChance, underChance);

            watch.Stop();

            Console.WriteLine("Total time: " + watch.ElapsedMilliseconds + "ms");

            return watch.ElapsedMilliseconds;
        }

        public static long LinkedListLinq()
        {
            Console.WriteLine("LinkedListLinq");

            int homeWins = 0;
            int awayWins = 0;
            int overChance = 0;
            int underChance = 0;

            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<ResultsData> simulationData = (List<ResultsData>)GetData("List");

            double median = GetMedian(simulationData);

            LinkedList<ResultsData> source = new LinkedList<ResultsData>(simulationData);

            WinProbabilityLinq(simulationData, median, out homeWins, out awayWins, out overChance, out underChance);

            PrintResults(homeWins, awayWins, overChance, underChance);

            watch.Stop();

            Console.WriteLine("Total time: " + watch.ElapsedMilliseconds + "ms");

            return watch.ElapsedMilliseconds;
        }

        public static long ListIter()
        {
            Console.WriteLine("ListIter");

            int homeWins = 0;
            int awayWins = 0;
            int overChance = 0;
            int underChance = 0;

            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<ResultsData> simulationData = (List<ResultsData>)GetData("List");

            double median = GetMedian(simulationData);

            ProbabilityIter(simulationData.GetEnumerator(), median, out homeWins, out awayWins, out overChance, out underChance);

            PrintResults(homeWins, awayWins, overChance, underChance);

            watch.Stop();

            Console.WriteLine("Total time: " + watch.ElapsedMilliseconds + "ms");

            return watch.ElapsedMilliseconds;
        }

        public static long ListLinq()
        {
            Console.WriteLine("ListLinq");

            int homeWins = 0;
            int awayWins = 0;
            int overChance = 0;
            int underChance = 0;

            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<ResultsData> simulationData = (List<ResultsData>)GetData("List");

            double median = GetMedian(simulationData);

            WinProbabilityLinq(simulationData, median, out homeWins, out awayWins, out overChance, out underChance);

            PrintResults(homeWins, awayWins, overChance, underChance);

            watch.Stop();

            Console.WriteLine("Total time: " + watch.ElapsedMilliseconds + "ms");

            return watch.ElapsedMilliseconds;
        }

        public static ICollection<ResultsData> GetData(string type)
        {
            switch(type)
            {
                case "HashSet":
                    return File
                        .ReadLines("Data/GameResults.csv")
                        .Skip(1)
                        .Select(x => new ResultsData(x))
                        .OrderBy(x => x.TotalPoints)
                        .ToHashSet();
                case "LinkedList":
                    return new LinkedList<ResultsData>(File
                        .ReadLines("Data/GameResults.csv")
                        .Skip(1)
                        .Select(x => new ResultsData(x))
                        .OrderBy(x => x.TotalPoints)
                        .ToList());
                case "List":
                    return File
                        .ReadLines("Data/GameResults.csv")
                        .Skip(1)
                        .Select(x => new ResultsData(x))
                        .OrderBy(x => x.TotalPoints)
                        .ToList();
                default:
                    return File
                        .ReadLines("Data/GameResults.csv")
                        .Skip(1)
                        .Select(x => new ResultsData(x))
                        .OrderBy(x => x.TotalPoints)
                        .ToList();
            }
        }

        public static double GetMedian(List<ResultsData> simulationData)
        {
            int middle = simulationData.Count / 2;
            return ((simulationData.Count % 2 != 0) ? (double)simulationData[middle].TotalPoints : ((double)simulationData[middle].TotalPoints + (double)simulationData[middle - 1].TotalPoints) / 2) + .5;
        }

        public static void ProbabilityIter(IEnumerator<ResultsData> data, double median, out int homeWins, out int awayWins, out int overChance, out int underChance)
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
        public static void WinProbabilityLinq(ICollection<ResultsData> data, double median, out int homeWins, out int awayWins, out int overChance, out int underChance)
        {
            homeWins = data.Where(x => x.HomeTeamWinner).Count();
            awayWins = data.Where(x => x.AwayTeamWinner).Count();
            overChance = data.Where(x => x.TotalPoints > median).Count();
            underChance = data.Where(x => x.TotalPoints < median).Count();
        }

        public static void PrintResults(int homeWins, int awayWins, int overChance, int underChance)
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
