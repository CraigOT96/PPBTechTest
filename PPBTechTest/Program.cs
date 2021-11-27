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
            List<ResultsData> simulationData = GetSimulationData(100);

            int mid = simulationData.Count / 2;
            double median = 
                ((simulationData.Count % 2 != 0) 
                    ? simulationData[mid].TotalPoints 
                    : (simulationData[mid].TotalPoints + simulationData[mid - 1].TotalPoints) 
                / 2) 
                + .5;

            LinkedList<ResultsData> linkedSimulationData = new LinkedList<ResultsData>(simulationData);

            IEnumerator<ResultsData> simulationDataIter = linkedSimulationData.GetEnumerator();

            int homeWins = 0;
            int awayWins = 0;
            int overLine = 0;
            int underLine = 0;

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
            }
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

        static void RunSpeedTest(int loops)
        {
            double hashSpeedIterAverage = 0;
            double hashSpeedLinqAverage = 0;
            double linkedListIterAverage = 0;
            double linkedListLinqAverage = 0;
            double listIterAverage = 0;
            double listLinqAverage = 0;

            for(int i = 0; i < loops; i++)
            {
                hashSpeedIterAverage += SpeedTests.SpeedTests.HashSpeedIter();
                Console.WriteLine();
                hashSpeedLinqAverage += SpeedTests.SpeedTests.HashSpeedLinq();
                Console.WriteLine();
                linkedListIterAverage += SpeedTests.SpeedTests.LinkedListIter();
                Console.WriteLine();
                linkedListLinqAverage += SpeedTests.SpeedTests.LinkedListLinq();
                Console.WriteLine();
                listIterAverage += SpeedTests.SpeedTests.ListIter ();
                Console.WriteLine();
                listLinqAverage += SpeedTests.SpeedTests.ListLinq();
                Console.WriteLine();
            }
            Console.WriteLine("Hash Speed Iter Avg: " + (hashSpeedIterAverage / loops));
            Console.WriteLine("Hash Speed Linq Avg: " + (hashSpeedLinqAverage / loops));
            Console.WriteLine("Linked List Iter Avg: " + (linkedListIterAverage / loops));
            Console.WriteLine("Linked List Linq Avg: " + (linkedListLinqAverage / loops));
            Console.WriteLine("List Iter Avg: " + (listIterAverage / loops));
            Console.WriteLine("List Linq Avg: " + (listLinqAverage / loops));

        }
    }
}
