using PPBTechTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PPBTechTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                RunProgram();
                watch.Stop();
                Console.WriteLine();
                Console.WriteLine("Run time: " + watch.ElapsedMilliseconds + "ms");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static bool RunProgram()
        {
            try
            {
                List<ResultsData> simulationData = GetSimulationData();

                if (simulationData != null)
                {
                    SimulationResults results = new SimulationResults(simulationData.Count, GetMedian(simulationData));

                    LinkedList<ResultsData> linkedSimulationData = new LinkedList<ResultsData>(simulationData);

                    IEnumerator<ResultsData> simulationDataIter = linkedSimulationData.GetEnumerator();

                    while (simulationDataIter.MoveNext())
                    {
                        results.AddSimulationData(simulationDataIter.Current);
                    }

                    results.PrintResults();

                    return true;
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public static List<ResultsData> GetSimulationData()
        {
            try
            {
                return new List<ResultsData>(File
                            .ReadLines("Data/GameResults.csv")
                            .Skip(1)
                            .Select(x => new ResultsData(x))
                            .OrderBy(x => x.TotalPoints)
                            .ToList());
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("File not found: " + ex.Message);
                return null;
            }
        }

        public static double GetMedian(List<ResultsData> simulationData)
        {
            try
            {
                int middle = simulationData.Count / 2;
                return ((simulationData.Count % 2 != 0) ? (double)simulationData[middle].TotalPoints : ((double)simulationData[middle].TotalPoints + (double)simulationData[middle - 1].TotalPoints) / 2) + .5;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
