using NUnit.Framework;
using PPBTechTest.Models;
using System;
using System.Collections.Generic;

namespace PPBTechTest.Tests
{
    [TestFixture]
    public class SpeedBenchmarksDataTests
    {
        [Test]
        public void SpeedBenchmarksDataTest()
        {
            SpeedBenchmarksData data = new SpeedBenchmarksData(10);
            Assert.IsNotNull(data);
        }
        [Test]
        public void RunTestsTest()
        {
            try
            {
                SpeedBenchmarksData data = new SpeedBenchmarksData(10);
                data.RunTests();
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
                SpeedBenchmarksData data = new SpeedBenchmarksData(10);
                data.PrintResults();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}