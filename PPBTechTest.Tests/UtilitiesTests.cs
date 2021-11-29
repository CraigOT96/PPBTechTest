using NUnit.Framework;
using PPBTechTest.Models;
using System;
using System.Collections.Generic;

namespace PPBTechTest.Tests
{
    [TestFixture]
    public class UtilitiesTests
    {
        [Test]
        public void GetSimulationDataTest()
        {
            List<Result> results = Utilities.GetResultsData();
            Assert.True(results.Count > 0);
        }
        [Test]
        public void GetMedianTest()
        {
            List<Result> results = Utilities.GetResultsData();
            double median = Utilities.GetMedian(results);
            Assert.True(median > 0);
        }
        [Test]
        public void GetMedianNoDataTest()
        {
            double median = Utilities.GetMedian(null);
            Assert.AreEqual(median, 0);
        }
        [Test]
        public void RunBenchmarkTest()
        {
            long runtime = Utilities.RunBenchmark("Hash Set Iterator", "List", false);
            Assert.Greater(runtime, 0);
        }
        [Test]
        public void RunBenchmarkInvalidDataTest()
        {
            long runtime = Utilities.RunBenchmark("kjasbndasbdjabs", "asoidhasoihd", false);
            Assert.Greater(runtime, 0);
        }
        [Test]
        public void RunBenchmarkNullDataTest()
        {
            long runtime = Utilities.RunBenchmark(null, null, false);
            Assert.Greater(runtime, 0);
        }
        [Test]
        public void ConvertDataTypeTest()
        {
            ICollection<Result> results = Utilities.ConvertDataType("List", new List<Result>());
            Assert.IsNotNull(results);
        }
        [Test]
        public void ConvertDataTypeInvalidTypeTest()
        {
            ICollection<Result> results = Utilities.ConvertDataType("asasasaas", new List<Result>());
            Assert.IsNotNull(results);
        }
        [Test]
        public void ConvertDataTypeInvalidDataTest()
        {
            try
            {
                ICollection<Result> results = Utilities.ConvertDataType("", null);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }
    }
}