using PPBTechTest.Models;

namespace PPBTechTest
{
    public class SpeedBenchmarks
    {
        public void RunSpeedTests(int numberOfRuns)
        {
            SpeedBenchmarksData speedBenchmarksData = new SpeedBenchmarksData(numberOfRuns);
            speedBenchmarksData.RunSpeedBenchmarks();
            speedBenchmarksData.PrintResults();
        }
    }
}
