using NUnit.Framework;
using PPBTechTest.Models;
using System;
using System.Collections.Generic;

namespace PPBTechTest.Tests
{
    [TestFixture]
    public class ResultsDataTests
    {
        [Test]
        public void ResultsTest()
        {
            Results data = new Results(new List<ResultsData>());
            Assert.IsNotNull(data.Data);
        }
        [Test]
        public void ResultsNullListTest()
        {
            Results data = new Results(null);
            Assert.IsNull(data.Data);
        }
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
    }
}