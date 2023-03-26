using MajoraAutoItemTracker.Model;
using MajoraAutoItemTracker.Model.Check;
using MajoraAutoItemTracker.Model.Item;
using MajoraAutoItemTracker.Model.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI.LogicTester
{
    public partial class LogicTester : Form
    {
        private LogicFile _logicFile;
        private List<CheckLogic> _checkLogics;
        private List<ItemLogic> _itemLogics;

        public LogicTester()
        {
            InitializeComponent();
        }

        private void LogicTester_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLoadLogic_Click(object sender, EventArgs e)
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

        private void btnLoadCheck_Click(object sender, EventArgs e)
        {
            try
            {
                _checkLogics = CheckLogicMethod.Deserialize(GetPathOfJson());
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
                    foreach (var itemVariant in itemLogic.variants)
                        if (itemVariant.hasItem)
                            enabledCount++;
                Log($"{enabledCount} item variant enabled");
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
                RestoreDirectory = true,

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
            logicResolver.UpdateCheckForItem(_itemLogics, _checkLogics);
            _checkLogics.ForEach(x => Log($"check: {x.Id}; IsAvailable={x.IsAvailable}"));
        }

        private void Log(string message)
        {
            Debug.WriteLine(message);
            textOutput.Text += message + "\r\n";
        }
    }
}
