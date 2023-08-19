using MajoraAutoItemTracker.Model;
using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.Model.Item;
using MajoraAutoItemTracker.Model.Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI.LogicTester
{
    public partial class LogicTester : Form
    {
        private LogicFile _logicFile;
        private List<OcarinaOfTimeCheckLogic> _checkLogics;
        private List<ItemLogic> _itemLogics;

        public LogicTester()
        {
            InitializeComponent();
        }

        private void LogicTester_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnLoadLogic_Click(object sender, EventArgs e)
        {
            try
            {
                _logicFile = LogicFile.FromJson(File.ReadAllText(GetPathOfJson()));
                Log($"logic file loaded: ({_logicFile.Logic.Count} logic)");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        private void BtnLoadCheck_Click(object sender, EventArgs e)
        {
            try
            {
                _checkLogics = OcarinaOfTimeCheckLogic.Deserialize(GetPathOfJson());
                Log($"check file loaded: ({_checkLogics.Count} check)");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLoadItem_Click(object sender, EventArgs e)
        {
            try
            {
                _itemLogics = ItemLogicMethod.Deserialize(GetPathOfJson());
                Log($"item file loaded: ({_itemLogics.Count} item)");
                var enabledCount = 0;
                foreach (var itemLogic in _itemLogics)
                    if (itemLogic.hasItem)
                        enabledCount++;
                Log($"{enabledCount} item enabled");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetPathOfJson()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = Application.StartupPath,
                Title = "Select check json file",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "json",
                Filter = "json files (*.json)|*.json",
                FilterIndex = 2,
                //RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true

            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                return openFileDialog.FileName;
            else
                return "";
        }

        private void BtnResolve_Click(object sender, EventArgs e)
        {
            if (_logicFile == null)
            {
                Log("logic is null");
                return;
            }
            if (_checkLogics == null)
            {
                Log("check logic is null");
                return;
            }
            if (_itemLogics == null)
            {
                Log("item logic is null");
                return;
            }
            LogicResolver logicResolver = new LogicResolver(_logicFile);
            logicResolver.UpdateCheckForItem(_itemLogics, _checkLogics, chkAllowTrick.Checked);
            _checkLogics.ForEach(x => Log($"check: {x.Id}; IsAvailable={x.IsAvailable}"));
        }

        private void Log(string message)
        {
            Debug.WriteLine(message);
            textOutput.Text += message + "\r\n";
        }

        private void BtnRunUnitTest_Click(object sender, EventArgs e)
        {
            Action[] arrayTest =
            {
                TestRequireItemClaim,
                TestConditionalItemClaim,
                TestConditionalAndRequiredItemClaim
            };
            foreach (var test in arrayTest)
            {
                Log($"Running test: {test.Method.Name}");
                test();
            }
            Log("Test finished without issue");
        }

        private void TestRequireItemClaim()
        {
            // Logic item
            var strItemRequireZoraMask = "Zora mask";
            var strItemAccesToTheUnderwaterZone = "Acces to the underwater zone";
            var strItemCheckUnderwaterChest = "Under water chest logic";

            // object Item Logic
            var itemLogicZoraMask = LogicTesterHelper.QuickCreateItemLogic(new string[] { strItemRequireZoraMask }, false, 0);

            // Claim to lookup
            var checkUnderWaterChest = LogicTesterHelper.QuickCreateCheckLogic(strItemCheckUnderwaterChest);

            // Sample logic file
            LogicFile logicFile = LogicTesterHelper.CreateLogicFile(new List<JsonFormatLogicItem>
            {
                LogicTesterHelper.QuickCreateJsonItemLogic(strItemCheckUnderwaterChest, new List<string> { strItemRequireZoraMask, strItemAccesToTheUnderwaterZone }),
                LogicTesterHelper.QuickCreateJsonItemLogic(strItemRequireZoraMask),
                LogicTesterHelper.QuickCreateJsonItemLogic(strItemAccesToTheUnderwaterZone)
            });          

            // Sample item
            List<ItemLogic> itemLogicList = new List<ItemLogic>() { itemLogicZoraMask };

            // Sample check            
            List<OcarinaOfTimeCheckLogic> checkLogicList = new List<OcarinaOfTimeCheckLogic>() { checkUnderWaterChest };

            // Try to resolve
            LogicResolver logicResolver = new LogicResolver(logicFile) { debugMode = true };
            // TEST 1
            itemLogicZoraMask.hasItem = false;
            logicResolver.UpdateCheckForItem(itemLogicList, checkLogicList, true);
            Assert(checkUnderWaterChest.IsAvailable, false, "underwater chest must be false");
            // TEST 2
            itemLogicZoraMask.hasItem = true;
            logicResolver.UpdateCheckForItem(itemLogicList, checkLogicList, true);
            Assert(checkUnderWaterChest.IsAvailable, true, "underwater chest must be true");
        }

        private void TestConditionalItemClaim()
        {
            // Case: Need zora mask to acces underwater chest

            // Logic item
            var strItemRequireZoraMask = "Zora mask";
            var strItemOtherUnderwaterMask = "Other underwater mask";

            var strItemCheckUnderwaterChest = "Under water chest logic";

            // object Item Logic
            var itemLogicZoraMask = LogicTesterHelper.QuickCreateItemLogic(new string[] { strItemRequireZoraMask }, false, 0);
            var itemLogicOtherUnderwaterMask = LogicTesterHelper.QuickCreateItemLogic(new string[] { strItemOtherUnderwaterMask }, false, 0);

            // Claim to lookup
            var checkUnderWaterChest = LogicTesterHelper.QuickCreateCheckLogic(strItemCheckUnderwaterChest);

            // Sample logic file
            LogicFile logicFile = LogicTesterHelper.CreateLogicFile(new List<JsonFormatLogicItem>
            {
                LogicTesterHelper.QuickCreateJsonItemLogic(strItemCheckUnderwaterChest, new List<List<string>> {
                    new List<string>() { strItemRequireZoraMask },
                    new List<string>() { strItemOtherUnderwaterMask }
                }),
                LogicTesterHelper.QuickCreateJsonItemLogic(strItemRequireZoraMask),
                LogicTesterHelper.QuickCreateJsonItemLogic(strItemOtherUnderwaterMask),
            });

            // Sample item
            List<ItemLogic> itemLogicList = new List<ItemLogic>()
            {
                itemLogicZoraMask,
                itemLogicOtherUnderwaterMask
            };

            // Sample check            
            List<OcarinaOfTimeCheckLogic> checkLogicList = new List<OcarinaOfTimeCheckLogic>()
            {
                checkUnderWaterChest
            };

            // Try to resolve
            LogicResolver logicResolver = new LogicResolver(logicFile)
            {
                debugMode = true
            };

            // Test 1, both item as false
            itemLogicZoraMask.hasItem = false;
            itemLogicOtherUnderwaterMask.hasItem = false;
            logicResolver.UpdateCheckForItem(itemLogicList, checkLogicList, true);
            Assert(checkUnderWaterChest.IsAvailable, false, "Test1: check must be false");
            // Test 2, one item true
            itemLogicZoraMask.hasItem = true;
            itemLogicOtherUnderwaterMask.hasItem = false;
            logicResolver.UpdateCheckForItem(itemLogicList, checkLogicList, true);
            Assert(checkUnderWaterChest.IsAvailable, true, "Test2: check must be true");
            // Test 3, other item true
            itemLogicZoraMask.hasItem = false;
            itemLogicOtherUnderwaterMask.hasItem = true;
            logicResolver.UpdateCheckForItem(itemLogicList, checkLogicList, true);
            Assert(checkUnderWaterChest.IsAvailable, true, "Test3: check must be true");
            // Test 4, both item true
            itemLogicZoraMask.hasItem = true;
            itemLogicOtherUnderwaterMask.hasItem = true;
            logicResolver.UpdateCheckForItem(itemLogicList, checkLogicList, true);
            Assert(checkUnderWaterChest.IsAvailable, true, "Test4: check must be true");
        }

        private void TestConditionalAndRequiredItemClaim()
        {
            // Case: Need zora mask to acces underwater chest

            // Logic item
            var strItemRequireZoraMask = "Zora mask";
            var strItemOtherUnderwaterMask = "Other underwater mask";

            var strItemAccesToTheUnderwaterZone = "Acces to the underwater zone";

            var strItemCheckUnderwaterChest = "Under water chest logic";

            // object Item Logic
            var itemLogicZoraMask = LogicTesterHelper.QuickCreateItemLogic(new string[] { strItemRequireZoraMask }, false, 0);
            var itemLogicOtherUnderwaterMask = LogicTesterHelper.QuickCreateItemLogic(new string[] { strItemOtherUnderwaterMask }, false, 0);

            // Claim to lookup
            var checkUnderWaterChest = LogicTesterHelper.QuickCreateCheckLogic(strItemCheckUnderwaterChest);

            // Sample logic file
            LogicFile logicFile = LogicTesterHelper.CreateLogicFile(new List<JsonFormatLogicItem>
            {
                LogicTesterHelper.QuickCreateJsonItemLogic(
                    strItemCheckUnderwaterChest, 
                    new List<string>
                    {
                        strItemAccesToTheUnderwaterZone
                    },
                    new List<List<string>> {
                        new List<string>() { strItemRequireZoraMask },
                        new List<string>() { strItemOtherUnderwaterMask }
                    }
                ),
                LogicTesterHelper.QuickCreateJsonItemLogic(strItemRequireZoraMask),
                LogicTesterHelper.QuickCreateJsonItemLogic(strItemOtherUnderwaterMask),
                LogicTesterHelper.QuickCreateJsonItemLogic(strItemAccesToTheUnderwaterZone),
            });

            // Sample item
            List<ItemLogic> itemLogicList = new List<ItemLogic>()
            {
                itemLogicZoraMask,
                itemLogicOtherUnderwaterMask
            };

            // Sample check            
            List<OcarinaOfTimeCheckLogic> checkLogicList = new List<OcarinaOfTimeCheckLogic>()
            {
                checkUnderWaterChest
            };

            // Try to resolve
            LogicResolver logicResolver = new LogicResolver(logicFile)
            {
                debugMode = true
            };

            // Test 1, both item as false
            itemLogicZoraMask.hasItem = false;
            itemLogicOtherUnderwaterMask.hasItem = false;
            logicResolver.UpdateCheckForItem(itemLogicList, checkLogicList, true);
            Assert(checkUnderWaterChest.IsAvailable, false, "Test1: check must be false");
            // Test 2, one item true
            itemLogicZoraMask.hasItem = true;
            itemLogicOtherUnderwaterMask.hasItem = false;
            logicResolver.UpdateCheckForItem(itemLogicList, checkLogicList, true);
            Assert(checkUnderWaterChest.IsAvailable, true, "Test2: check must be true");
            // Test 3, other item true
            itemLogicZoraMask.hasItem = false;
            itemLogicOtherUnderwaterMask.hasItem = true;
            logicResolver.UpdateCheckForItem(itemLogicList, checkLogicList, true);
            Assert(checkUnderWaterChest.IsAvailable, true, "Test3: check must be true");
            // Test 4, both item true
            itemLogicZoraMask.hasItem = true;
            itemLogicOtherUnderwaterMask.hasItem = true;
            logicResolver.UpdateCheckForItem(itemLogicList, checkLogicList, true);
            Assert(checkUnderWaterChest.IsAvailable, true, "Test4: check must be true");
        }

        private void Assert(bool curValue, bool expectValue, string exceptionStr)
        {
            if (curValue != expectValue)
                throw new Exception(exceptionStr);
        }
    }
}

class LogicTesterHelper // class helper to create logic file from logic and check added
{
    public static LogicFile CreateLogicFile(List<JsonFormatLogicItem> jsonFormatLogicItem)
    {
        return new LogicFile()
        {
            Logic = jsonFormatLogicItem
        };
    }

    public static JsonFormatLogicItem QuickCreateJsonItemLogic(string id)
    {
        return QuickCreateJsonItemLogic(id, new List<string>(), new List<List<string>>());
    }

    public static JsonFormatLogicItem QuickCreateJsonItemLogic(string id, List<string> arrayRequireId)
    {
        return QuickCreateJsonItemLogic(id, arrayRequireId, new List<List<string>>());
    }

    public static JsonFormatLogicItem QuickCreateJsonItemLogic(string id, List<List<string>> arrayArrayConditionalItem)
    {
        return QuickCreateJsonItemLogic(id, new List<string>(), arrayArrayConditionalItem);
    }

    public static JsonFormatLogicItem QuickCreateJsonItemLogic(
        string id,
        List<string> arrayRequireId,
        List<List<string>> arrayArrayConditionalItem)
    {
        return new JsonFormatLogicItem()
        {
            Id = id,
            RequiredItems = arrayRequireId,
            ConditionalItems = arrayArrayConditionalItem
        };
    }

    public static ItemLogic QuickCreateItemLogic(string[] arrayVariantId, bool hasItem, int currentVariant = 0)
    {
        List<ItemLogicVariant> variantList = new List<ItemLogicVariant>();
        foreach (var variantId in arrayVariantId)
            variantList.Add(new ItemLogicVariant() { idLogic = variantId });
        return new ItemLogic()
        {
            variants = variantList.ToArray(),
            hasItem = hasItem,
            CurrentVariant = currentVariant,
        };
    }

    public static OcarinaOfTimeCheckLogic QuickCreateCheckLogic(string id)
    {
        return new OcarinaOfTimeCheckLogic()
        {
            Id = id,
            IsAvailable = false,
            IsClaim = false
        };
    }
}