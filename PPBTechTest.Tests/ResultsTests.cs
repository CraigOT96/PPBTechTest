using NUnit.Framework;
using PPBTechTest.Models;
using System;
using System.Collections.Generic;

namespace PPBTechTest.Tests
{
    [TestFixture]
    public class ResultsTests
    {
        [Test]
        public void ResultsTest()
        {
            Results results = new Results(new List<Result>());
            Assert.IsNotNull(results.ResultsData);
        }
        [Test]
        public void ResultsNullListTest()
        {
            Results results = new Results(null);
            Assert.IsNull(results.ResultsData);
        }
        [Test]
        public void ResultsDataTest()
        {
            Result result = new Result(false, true, 71, 81);
            Assert.IsNotNull(result);
        }
        [Test]
        public void ResultsDataMinMaxValueTest()
        {
            Result result = new Result(false, true, Int32.MinValue, Int32.MaxValue);
            Assert.IsNotNull(result);
        }
        [Test]
        public void ResultsDataCSVLineTest()
        {
            Result result = new Result("0, 1, 71, 81");
            Assert.IsNotNull(result);
        }
        [Test]
        public void ResultsDataInvalidCSVLineTest()
        {
            try
            {
                Result result = new Result("0, 1, 71, ");
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
                Result result = new Result("h, h, 71, 81");
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
                Result result = new Result("0, 1, 1238612876381263876128736812763, 0987609689680968680689");
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }
    }
}