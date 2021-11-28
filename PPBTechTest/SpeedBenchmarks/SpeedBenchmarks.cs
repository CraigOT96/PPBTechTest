using PPBTechTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PPBTechTest
{
    public class SpeedBenchmarks
    {
        public void RunSpeedTests(int loops)
        {
            SpeedBenchmarksData benchmarks = new SpeedBenchmarksData(loops);
            benchmarks.RunTests();
            benchmarks.PrintResults();
        }
    }
}
