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
                Results simulationData = new Results(Utilities.GetSimulationData());
                if (simulationData != null)
                {
                    SimulationResults results = new SimulationResults(simulationData.Data.Count, Utilities.GetMedian(simulationData.Data));
                    results.AddSimulationDataLinq(simulationData.Data);
                    results.PrintResults();

                    simulationData.Dispose();
                    results.Dispose();

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
