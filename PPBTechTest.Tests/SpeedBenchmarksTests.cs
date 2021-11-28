using NUnit.Framework;
using PPBTechTest.Models;
using System;
using System.Collections.Generic;

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
                SpeedBenchmarks benchmark = new SpeedBenchmarks();
                benchmark.RunSpeedTests(10);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}