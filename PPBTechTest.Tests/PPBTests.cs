using NUnit.Framework;
using PPBTechTest.Models;
using System.Collections.Generic;

namespace PPBTechTest.Tests
{
    [TestFixture]
    public class PPBTests
    {
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
    }
}