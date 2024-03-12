using Microsoft.VisualStudio.TestTools.UnitTesting;
using MajoraAutoItemTracker.Logic;
using MajoraAutoItemTracker.Model.Logic;
using MajoraAutoItemTracker.Model.Item;
using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.Model.Enum;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class MajoraMaskLogicResolverTest
    {
        [TestMethod]
        public void TestKafeiMaskCheck()
        {
            var kafeiMaskPropertyName = MajoraMaskItemLogicPopertyNameMethod
                .ToString(MajoraMaskItemLogicPopertyName.KafeiMask);

            var checkLogicId = "MaskKafei";

            Assert.AreEqual("KafeiMask", kafeiMaskPropertyName);

            var logicFile = LogicFileUtils.LoadMajoraMaskFromRessource();
            var majoraMaskLogicResolver = new MajoraMaskLogicResolver(logicFile);
            majoraMaskLogicResolver.debugMode = true;

            var listItemLogic = ItemLogicMethod
                .LoadMajoraMaskItemLogicFromRessource()
                .Where((it) => it.propertyName == kafeiMaskPropertyName)
                .ToList();

            var checkLogicList = MajoraMaskCheckLogic
                .FromHeader(CheckLogicCategoryUtils.LoadMajoraMaskFromRessource())
                .Where((it) => it.Id == checkLogicId)
                .ToList();

            majoraMaskLogicResolver.UpdateCheckForItem(
                listItemLogic,
                checkLogicList,
                false);

            // Update kafei mask
            listItemLogic
                .First((it) => it.propertyName == kafeiMaskPropertyName)
                .hasItem = true;

            var result = majoraMaskLogicResolver.UpdateCheckAndReturnListOfUpdatedCheck(
                listItemLogic,
                checkLogicList,
                false);

            var kafeiMaskCheckLogic = result.Find((it) => it.Id == kafeiMaskPropertyName);

            Assert.IsNotNull(
                kafeiMaskCheckLogic,
                "Result should return Kafei mask");
            Assert.IsTrue(
                kafeiMaskCheckLogic.IsAvailable,
                "Kafei mask should be availble");
            // TODO: https://learn.microsoft.com/fr-fr/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022#create-the-test-class
        }


    }
}
