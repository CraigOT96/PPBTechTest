using NUnit.Framework;
using PPBTechTest.Models;
using System;
using System.Collections.Generic;

namespace PPBTechTest.Tests
{
    [TestFixture]
    public class SimulationResultsTests
    {
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
        public void SimulationResultsAddSimulationDataIteratorTest()
        {
            SimulationResults result = new SimulationResults(Int32.MaxValue, double.MaxValue);
            Results data = new Results(new List<ResultsData>() { new ResultsData(true, false, 50, 40) } );
            result.AddSimulationDataIterator(data.Data.GetEnumerator());
        }
        [Test]
        public void SimulationResultsAddSimulationDataIteratorNullTest()
        {
            try
            {
                SimulationResults result = new SimulationResults(Int32.MaxValue, double.MaxValue);
                Results data = new Results(new List<ResultsData>() { new ResultsData(true, false, 50, 40) });
                result.AddSimulationDataIterator(null);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex.Message);
            }
        }
        [Test]
        public void SimulationResultsAddSimulationDataLinqTest()
        {
            SimulationResults result = new SimulationResults(Int32.MaxValue, double.MaxValue);
            Results data = new Results(new List<ResultsData>() { new ResultsData(true, false, 50, 40) });
            result.AddSimulationDataLinq(data.Data);
        }
        [Test]
        public void SimulationResultsAddSimulationDataLinqNullTest()
        {
            try
            {
                SimulationResults result = new SimulationResults(Int32.MaxValue, double.MaxValue);
                Results data = new Results(new List<ResultsData>() { new ResultsData(true, false, 50, 40) });
                result.AddSimulationDataLinq(null);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex.Message);
            }
        }
    }
}