using Microsoft.VisualStudio.TestTools.UnitTesting;
using MajoraAutoItemTracker.Logic;
using MajoraAutoItemTracker.Model.Logic.OOT;
using MajoraAutoItemTracker.Model.Logic;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            LogicFile<OcarinaOfTimeJsonFormatLogicItem> logicFile = new LogicFile<OcarinaOfTimeJsonFormatLogicItem>();
            var foo = new OcarinaOfTimeLogicResolver(logicFile);
            // TODO: https://learn.microsoft.com/fr-fr/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022#create-the-test-class
            Assert.IsNotNull(foo);
        }
    }
}
