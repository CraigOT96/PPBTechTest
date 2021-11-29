using PPBTechTest.Models;
using System;
using System.Diagnostics;

namespace PPBTechTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                RunProgram();
                stopwatch.Stop();
                Console.WriteLine("Run time: " + stopwatch.ElapsedMilliseconds + "ms");
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
                Results results = new Results(Utilities.GetResultsData());
                if (results != null)
                {
                    SimulationResult simulationResults = new SimulationResult(results.ResultsData.Count, Utilities.GetMedian(results.ResultsData));
                    simulationResults.AddSimulationDataLinq(results.ResultsData);
                    simulationResults.PrintResults();

                    results.Dispose();
                    simulationResults.Dispose();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
