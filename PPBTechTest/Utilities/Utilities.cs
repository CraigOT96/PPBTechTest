using PPBTechTest.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace PPBTechTest
{
    public class Utilities
    {
        public static List<Result> GetResultsData()
        {
            try
            {
                return new List<Result>(File
                            .ReadLines("Data/GameResults.csv")
                            .Skip(1)
                            .Select(x => new Result(x))
                            .OrderBy(x => x.TotalPoints)
                            .ToList());
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found: " + ex.Message);
                return null;
            }
        }
        public static double GetMedian(List<Result> resultsData)
        {
            try
            {
                int middle = resultsData.Count / 2;
                return ((resultsData.Count % 2 != 0) ? (double)resultsData[middle].TotalPoints : ((double)resultsData[middle].TotalPoints + (double)resultsData[middle - 1].TotalPoints) / 2) + .5;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public static long RunBenchmark(string benchmarkName, string dataType, bool useIterator)
        {
            Console.WriteLine(benchmarkName);
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                Results results = new Results(Utilities.GetResultsData());

                if (results != null)
                {
                    SimulationResult simulationResults = new SimulationResult(results.ResultsData.Count, Utilities.GetMedian(results.ResultsData));

                    ICollection<Result> convertedData = ConvertDataType(dataType, results.ResultsData);

                    if (useIterator)
                    {
                        simulationResults.AddSimulationDataIterator(convertedData.GetEnumerator());
                        simulationResults.PrintResults();
                    }
                    else
                    {
                        simulationResults.AddSimulationDataLinq(convertedData);
                        simulationResults.PrintResults();
                    }

                    stopwatch.Stop();

                    Console.WriteLine("Total time: " + stopwatch.ElapsedMilliseconds + "ms");

                    results.Dispose();
                    simulationResults.Dispose();

                    return stopwatch.ElapsedMilliseconds;
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }
        public static ICollection<Result> ConvertDataType(string type, ICollection<Result> data)
        {
            try
            {
                switch (type)
                {
                    case "HashSet":
                        return new HashSet<Result>(data);
                    case "LinkedList":
                        return new LinkedList<Result>(data);
                    case "List":
                        return new List<Result>(data);
                    default:
                        return new List<Result>(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }
    }
}
