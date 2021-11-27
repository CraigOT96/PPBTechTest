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
            LinkedList<ResultsData> simulationData = GetSimulationData();
            IEnumerator<ResultsData> simulationDataIter = simulationData.GetEnumerator();

            int homeWins = 0;
            int awayWins = 0;

            while (simulationDataIter.MoveNext())
            {
                if (simulationDataIter.Current.HomeTeamWinner)
                    homeWins++;
                else
                    awayWins++;
            }
        }

        static LinkedList<ResultsData> GetSimulationData()
        {
            return new LinkedList<ResultsData>(File
                        .ReadLines("Data/GameResults.csv")
                        .Skip(1)
                        .Select(x => new ResultsData(x))
                        .ToList());
        }

        static void RunSpeedTest()
        {
            SpeedTests.SpeedTests.HashSpeedIter();
            Console.WriteLine();
            SpeedTests.SpeedTests.HashSpeedLinq();
            Console.WriteLine();
            SpeedTests.SpeedTests.LinkedListIter();
            Console.WriteLine();
            SpeedTests.SpeedTests.LinkedListLinq();
            Console.WriteLine();
            SpeedTests.SpeedTests.ListIter();
            Console.WriteLine();
            SpeedTests.SpeedTests.ListLinq();
        }
    }
}
