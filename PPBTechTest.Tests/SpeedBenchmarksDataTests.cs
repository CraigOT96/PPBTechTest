using NUnit.Framework;
using PPBTechTest.Models;
using System;

namespace PPBTechTest.Tests
{
    [TestFixture]
    public class SpeedBenchmarksDataTests
    {
        [Test]
        public void SpeedBenchmarksDataTest()
        {
            SpeedBenchmarksData speedBenchmarksData = new SpeedBenchmarksData(10);
            Assert.IsNotNull(speedBenchmarksData);
        }
        [Test]
        public void RunSpeedBenchmarksTest()
        {
            try
            {
                SpeedBenchmarksData speedBenchmarksData = new SpeedBenchmarksData(10);
                speedBenchmarksData.RunSpeedBenchmarks();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Test]
        public void PrintResultsTest()
        {
            try
            {
                SpeedBenchmarksData speedBenchmarksData = new SpeedBenchmarksData(10);
                speedBenchmarksData.PrintResults();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}