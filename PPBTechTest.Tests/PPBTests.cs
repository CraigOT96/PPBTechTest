using NUnit.Framework;
using PPBTechTest.Models;
using System;
using System.Collections.Generic;

namespace PPBTechTest.Tests
{
    [TestFixture]
    public class PPBTests
    {
        [Test]
        public void RunMain()
        {
            try
            {
                Program.Main(null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void RunProgramTest()
        {
            Assert.True(Program.RunProgram());
        }

        [Test]
        public void GetSimulationDataTest()
        {
            List<ResultsData> data = Program.GetSimulationData();
            Assert.True(data.Count > 0);
        }

        [Test]
        public void GetMedianTest()
        {
            List<ResultsData> data = Program.GetSimulationData();
            double median = Program.GetMedian(data);
            Assert.True(median > 0);
        }

        [Test]
        public void GetMedianNoDataTest()
        {
            double median = Program.GetMedian(null);
            Assert.AreEqual(median, 0);
        }

        // Speed Tests
        // ------

        [Test]
        public void ResultsDataTest()
        {
            ResultsData data = new ResultsData(false, true, 71, 81);
            Assert.IsNotNull(data);
        }

        [Test]
        public void ResultsDataMinMaxValueTest()
        {
            ResultsData data = new ResultsData(false, true, Int32.MinValue, Int32.MaxValue);
            Assert.IsNotNull(data);
        }


        [Test]
        public void ResultsDataCSVLineTest()
        {
            ResultsData data = new ResultsData("0, 1, 71, 81");
            Assert.IsNotNull(data);
        }

        [Test]
        public void ResultsDataInvalidCSVLineTest()
        {
            try
            {
                ResultsData data = new ResultsData("0, 1, 71, ");
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [Test]
        public void ResultsDataInvalidCSVDataTest1()
        {
            try
            {
                ResultsData data = new ResultsData("h, h, 71, 81");
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [Test]
        public void ResultsDataInvalidCSVDataTest2()
        {
            try
            {
                ResultsData data = new ResultsData("0, 1, 1238612876381263876128736812763, 0987609689680968680689");
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [Test]
        public void SimulationResultsTest()
        {
            SimulationResults result = new SimulationResults(10, 5);
            Assert.IsNotNull(result);
        }

        [Test]
        public void SimulationResultsMaxValuesTest()
        {
            SimulationResults result = new SimulationResults(Int32.MaxValue, double.MaxValue);
            Assert.IsNotNull(result);
        }

        [Test]
        public void SimulationResultsPrintResultsTest()
        {
            try
            {
                SimulationResults result = new SimulationResults(Int32.MaxValue, double.MaxValue);
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void SimulationResultsAddSimulationDataTest()
        {
            SimulationResults result = new SimulationResults(Int32.MaxValue, double.MaxValue);
            ResultsData data = new ResultsData(true, false, 50, 40);
            result.AddSimulationData(data);
        }

        [Test]
        public void SimulationResultsAddInvalidSimulationDataTest()
        {
            try
            {
                SimulationResults result = new SimulationResults(Int32.MaxValue, double.MaxValue);
                ResultsData data = null;
                result.AddSimulationData(data);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex.Message);
            }
        }
    }
}