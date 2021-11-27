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
        public static void HashSpeedIter()
        {
            Console.WriteLine("HashSpeedIter");
            var watch = System.Diagnostics.Stopwatch.StartNew();

            HashSet<ResultsData> source = (HashSet<ResultsData>)GetData("HashSet");
            IEnumerator<ResultsData> tData = source.GetEnumerator();


            int homeWins = 0;
            int awayWins = 0;

            while (tData.MoveNext())
            {
                if (tData.Current.HomeTeamWinner)
                    homeWins++;
                else
                    awayWins++;
            }

            PrintResults(homeWins, awayWins);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Total time: " + elapsedMs + "ms");
        }

        public static void HashSpeedLinq()
        {
            Console.WriteLine("HashSpeedLinq");
            var watch = System.Diagnostics.Stopwatch.StartNew();

            HashSet<ResultsData> source = (HashSet<ResultsData>)GetData("HashSet");
            int homeWins = source.Where(x => x.HomeTeamWinner).Count();
            int awayWins = source.Where(x => x.AwayTeamWinner).Count();

            PrintResults(homeWins, awayWins);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Total time: " + elapsedMs + "ms");
        }

        public static void LinkedListIter()
        {
            Console.WriteLine("LinkedListIter");
            var watch = System.Diagnostics.Stopwatch.StartNew();

            LinkedList<ResultsData> source = (LinkedList<ResultsData>)GetData("LinkedList");
            IEnumerator<ResultsData> tData = source.GetEnumerator();


            int homeWins = 0;
            int awayWins = 0;

            while (tData.MoveNext())
            {
                if (tData.Current.HomeTeamWinner)
                    homeWins++;
                else
                    awayWins++;
            }

            PrintResults(homeWins, awayWins);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Total time: " + elapsedMs + "ms");
        }

        public static void LinkedListLinq()
        {
            Console.WriteLine("LinkedListLinq");
            var watch = System.Diagnostics.Stopwatch.StartNew();

            LinkedList<ResultsData> source = (LinkedList<ResultsData>)GetData("LinkedList");
            int homeWins = source.Where(x => x.HomeTeamWinner).Count();
            int awayWins = source.Where(x => x.AwayTeamWinner).Count();

            PrintResults(homeWins, awayWins);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Total time: " + elapsedMs + "ms");
        }

        public static void ListIter()
        {
            Console.WriteLine("ListIter");
            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<ResultsData> source = (List<ResultsData>)GetData("List");
            IEnumerator<ResultsData> tData = source.GetEnumerator();


            int homeWins = 0;
            int awayWins = 0;

            while (tData.MoveNext())
            {
                if (tData.Current.HomeTeamWinner)
                    homeWins++;
                else
                    awayWins++;
            }

            PrintResults(homeWins, awayWins);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Total time: " + elapsedMs + "ms");
        }

        public static void ListLinq()
        {
            Console.WriteLine("ListLinq");
            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<ResultsData> source = (List<ResultsData>)GetData("List");
            int homeWins = source.Where(x => x.HomeTeamWinner).Count();
            int awayWins = source.Where(x => x.AwayTeamWinner).Count();

            PrintResults(homeWins, awayWins);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Total time: " + elapsedMs + "ms");
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
                        .ToHashSet();
                case "LinkedList":
                    return new LinkedList<ResultsData>(File
                        .ReadLines("Data/GameResults.csv")
                        .Skip(1)
                        .Select(x => new ResultsData(x))
                        .ToList());
                case "List":
                    return File
                        .ReadLines("Data/GameResults.csv")
                        .Skip(1)
                        .Select(x => new ResultsData(x))
                        .ToList();
                default:
                    return File
                        .ReadLines("Data/GameResults.csv")
                        .Skip(1)
                        .Select(x => new ResultsData(x))
                        .ToList();
            }
        }

        static void PrintResults(int homeWins, int awayWins)
        {
            double homePercent = (double)(1 * homeWins) / 20000;
            double awayPercent = (double)(1 * awayWins) / 20000;
            Console.WriteLine("Total Home Wins: " + homeWins);
            Console.WriteLine("Total Away Wins: " + awayWins);
            Console.WriteLine("Home Win Probability: " + homePercent);
            Console.WriteLine("Away Win Probability: " + awayPercent);
            Console.WriteLine("Total: " + (homePercent + awayPercent));

        }
    }
}
