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
            List<ResultsData> data = Utilities.GetSimulationData();
            Assert.True(data.Count > 0);
        }
        [Test]
        public void GetMedianTest()
        {
            List<ResultsData> data = Utilities.GetSimulationData();
            double median = Utilities.GetMedian(data);
            Assert.True(median > 0);
        }
        [Test]
        public void GetMedianNoDataTest()
        {
            double median = Utilities.GetMedian(null);
            Assert.AreEqual(median, 0);
        }
        [Test]
        public void RunTestTest()
        {
            long time = Utilities.RunTest("Hash Set Iterator", "List", false);
            Assert.Greater(time, 0);
        }
        [Test]
        public void RunTestInvalidDataTest()
        {
            long time = Utilities.RunTest("kjasbndasbdjabs", "asoidhasoihd", false);
            Assert.Greater(time, 0);
        }
        [Test]
        public void RunTestNullDataTest()
        {
            long time = Utilities.RunTest(null, null, false);
            Assert.Greater(time, 0);
        }
        [Test]
        public void ConvertDataTest()
        {
            ICollection<ResultsData> data = Utilities.ConvertData("List", new List<ResultsData>());
            Assert.IsNotNull(data);
        }
        [Test]
        public void ConvertDataInvalidTypeTest()
        {
            ICollection<ResultsData> data = Utilities.ConvertData("asasasaas", new List<ResultsData>());
            Assert.IsNotNull(data);
        }
        [Test]
        public void ConvertDataInvalidDataTest()
        {
            try
            {
                ICollection<ResultsData> data = Utilities.ConvertData("", null);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }
        [Test]
        public void ProbabilityIteratorTest()
        {
            try
            {
                List<ResultsData> data = new List<ResultsData>();
                SimulationResults results = new SimulationResults(10, 10);
                Utilities.ProbabilityIterator(data.GetEnumerator(), results);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Test]
        public void ProbabilityIteratorNullDataTest()
        {
            try
            {
                List<ResultsData> data = null;
                SimulationResults results = null;
                Utilities.ProbabilityIterator(data.GetEnumerator(), results);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }
        [Test]
        public void ProbabilityLinqTest()
        {
            try
            {
                List<ResultsData> data = new List<ResultsData>();
                SimulationResults results = new SimulationResults(10, 10);
                Utilities.ProbabilityLinq(data, results);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Test]
        public void ProbabilityLinqNullDataTest()
        {
            try
            {
                List<ResultsData> data = null;
                SimulationResults results = null;
                Utilities.ProbabilityLinq(data, results);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }
    }
}