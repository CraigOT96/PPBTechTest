using NUnit.Framework;
using System;

namespace PPBTechTest.Tests
{
    [TestFixture]
    public class ProgramTests
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
    }
}