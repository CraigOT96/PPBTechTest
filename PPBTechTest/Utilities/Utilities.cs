using PPBTechTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PPBTechTest
{
    public class Utilities
    {
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
            catch (FileNotFoundException ex)
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
        public static long RunTest(string testName, string dataType, bool useIterator)
        {
            Console.WriteLine(testName);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                Results data = new Results(Utilities.GetSimulationData());

                if (data != null)
                {
                    SimulationResults results = new SimulationResults(data.Data.Count, Utilities.GetMedian(data.Data));

                    ICollection<ResultsData> source = ConvertData(dataType, data.Data);

                    if (useIterator)
                        ProbabilityIterator(source.GetEnumerator(), results);
                    else
                        ProbabilityLinq(source, results);

                    watch.Stop();

                    Console.WriteLine("Total time: " + watch.ElapsedMilliseconds + "ms");

                    data.Dispose();
                    results.Dispose();

                    return watch.ElapsedMilliseconds;
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
        public static ICollection<ResultsData> ConvertData(string type, ICollection<ResultsData> data)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }
        public static void ProbabilityIterator(IEnumerator<ResultsData> data, SimulationResults results)
        {
            try
            {
                results.AddSimulationDataIterator(data);
                results.PrintResults();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }
        public static void ProbabilityLinq(ICollection<ResultsData> data, SimulationResults results)
        {
            try
            {
                results.AddSimulationDataLinq(data);
                results.PrintResults();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }
    }
}
