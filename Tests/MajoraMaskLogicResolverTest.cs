using Microsoft.VisualStudio.TestTools.UnitTesting;
using MajoraAutoItemTracker.Logic;
using MajoraAutoItemTracker.Model.Logic;
using MajoraAutoItemTracker.Model.Item;
using System.Collections.Generic;
using MajoraAutoItemTracker.Model.CheckLogic;

namespace Tests
{
    [TestClass]
    public class MajoraMaskLogicResolverTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var logicFile = LogicFileUtils.LoadMajoraMaskFromRessource();

            var majoraMaskLogicResolver = new MajoraMaskLogicResolver(logicFile);
            var listItemLogic = new List<ItemLogic>();
            var checkLogicList = new List<MajoraMaskCheckLogic>();

            var result = majoraMaskLogicResolver.UpdateCheckAndReturnListOfUpdatedCheck(
                listItemLogic,
                checkLogicList,
                false);

            //result.Find((it) => it.Id)

            // TODO: https://learn.microsoft.com/fr-fr/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022#create-the-test-class
            Assert.IsNotNull(majoraMaskLogicResolver);
        }


    }
}
