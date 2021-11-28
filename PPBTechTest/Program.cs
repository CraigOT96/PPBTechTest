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
            RunProgram();
        }
        public static bool RunProgram()
        {
            try
            {
                List<ResultsData> simulationData = GetSimulationData();

                if (simulationData != null)
                {
                    double median = GetMedian(simulationData);

                    LinkedList<ResultsData> linkedSimulationData = new LinkedList<ResultsData>(simulationData);

                    IEnumerator<ResultsData> simulationDataIter = linkedSimulationData.GetEnumerator();

                    SimulationResults results = new SimulationResults();
                    results.RecordCount = linkedSimulationData.Count;

                    while (simulationDataIter.MoveNext())
                    {
                        if (simulationDataIter.Current.HomeTeamWinner)
                            results.HomeWins++;
                        else
                            results.AwayWins++;
                        if (simulationDataIter.Current.TotalPoints > median)
                            results.OverLine++;
                        else
                            results.UnderLine++;
                        if (simulationDataIter.Current.HomeWinningMargin >= 11)
                            results.HomeOverTenPoints++;
                        else if (simulationDataIter.Current.HomeWinningMargin <= 10 && simulationDataIter.Current.HomeWinningMargin > -1)
                            results.HomeUnderTenPoints++;
                        else if (simulationDataIter.Current.AwayWinningMargin >= 11)
                            results.AwayOverTenPoints++;
                        else if (simulationDataIter.Current.AwayWinningMargin <= 10 && simulationDataIter.Current.AwayWinningMargin > -1)
                            results.AwayUnderTenPoints++;
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
