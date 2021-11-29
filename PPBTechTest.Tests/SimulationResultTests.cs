using NUnit.Framework;
using PPBTechTest.Models;
using System;
using System.Collections.Generic;

namespace PPBTechTest.Tests
{
    [TestFixture]
    public class SimulationResultTests
    {
        [Test]
        public void SimulationResultsTest()
        {
            SimulationResult simulationResult = new SimulationResult(10, 5);
            Assert.IsNotNull(simulationResult);
        }
        [Test]
        public void SimulationResultsMaxValuesTest()
        {
            SimulationResult simulationResult = new SimulationResult(Int32.MaxValue, double.MaxValue);
            Assert.IsNotNull(simulationResult);
        }
        [Test]
        public void PrintResultsTest()
        {
            try
            {
                SimulationResult simulationResult = new SimulationResult(Int32.MaxValue, double.MaxValue);
                Assert.IsNotNull(simulationResult);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Test]
        public void AddSimulationDataIteratorTest()
        {
            SimulationResult simulationResult = new SimulationResult(Int32.MaxValue, double.MaxValue);
            Results results = new Results(new List<Result>() { new Result(true, false, 50, 40) } );
            simulationResult.AddSimulationDataIterator(results.ResultsData.GetEnumerator());
        }
        [Test]
        public void AddSimulationDataIteratorNullTest()
        {
            try
            {
                SimulationResult simulationResult = new SimulationResult(Int32.MaxValue, double.MaxValue);
                Results results = new Results(new List<Result>() { new Result(true, false, 50, 40) });
                simulationResult.AddSimulationDataIterator(null);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex.Message);
            }
        }
        [Test]
        public void AddSimulationDataLinqTest()
        {
            SimulationResult simulationResult = new SimulationResult(Int32.MaxValue, double.MaxValue);
            Results results = new Results(new List<Result>() { new Result(true, false, 50, 40) });
            simulationResult.AddSimulationDataLinq(results.ResultsData);
        }
        [Test]
        public void AddSimulationDataLinqNullTest()
        {
            try
            {
                SimulationResult simulationResult = new SimulationResult(Int32.MaxValue, double.MaxValue);
                Results results = new Results(new List<Result>() { new Result(true, false, 50, 40) });
                simulationResult.AddSimulationDataLinq(null);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex.Message);
            }
        }
    }
}