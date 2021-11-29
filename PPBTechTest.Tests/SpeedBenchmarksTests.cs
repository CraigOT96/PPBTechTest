using NUnit.Framework;
using System;

namespace PPBTechTest.Tests
{
    [TestFixture]
    public class SpeedBenchmarksTests
    {
        [Test]
        public void SpeedBenchmarksTest()
        {
            try
            {
                SpeedBenchmarks speedBenchmarks = new SpeedBenchmarks();
                speedBenchmarks.RunSpeedTests(10);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}