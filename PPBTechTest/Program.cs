using PPBTechTest.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PPBTechTest
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<ResultsData> results = GetSimulationData();
        }

        static HashSet<ResultsData> GetSimulationData()
        {
            var source = File
                .ReadLines("Data/GameResults.csv")
                .Skip(1)
                .Select(x => new ResultsData(x))
                .ToHashSet();

            return source;
        }
    }
}
