using MajoraAutoItemTracker.Model.Check;
using MajoraAutoItemTracker.Model.Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI.CheckLogicEditor
{
    public partial class CheckLogicEditor : Form
    {

        private LogicFile _logicFile;
        private List<CheckLogic> checkLogics = new List<CheckLogic>();

        public CheckLogicEditor()
        {
            InitializeComponent();
        }

        private void CheckLogicEditor_Load(object sender, EventArgs e)
        {
            // Load logic file
            LoadJsonFile();
        }

        private void LoadJsonFile()
        {
            _logicFile = LogicFile.FromJson(File.ReadAllText(Application.StartupPath + @"\Resource\Logics\REQ_CASUAL_12.json"));
            lbLogicVerion.Text = "V:" + _logicFile.Version;
            UpdateLogicFile();
        }

        private void UpdateLogicFile()
        {
            var filter = textLogicFilter.Text;
            lbLogic.Items.Clear();
            var filteredData = _logicFile.Logic.FindAll(x => filter.Length == 0 || x.Id.ToLower().Contains(filter.ToLower()));
            filteredData.ForEach(x => lbLogic.Items.Add(x));
            lbLogic.DisplayMember = "Id";
        }

        private void UpdateCheckListBox()
        {
            lbCheck.Items.Clear();
            checkLogics.ForEach(x => lbCheck.Items.Add(x));
            lbCheck.DisplayMember = "Id";
        }

        private void addRemoveToCheck(string itemId, bool remove = false)
        {
            var check = checkLogics.Find(x => x.Id == itemId);
            var logic = _logicFile.Logic.Find(x => x.Id == itemId);
            if (remove)
            {
                if (check != null)
                    checkLogics.Remove(check);
            } 
            else
            {
                if (logic == null || check != null)
                    return;

                checkLogics.Add(new CheckLogic()
                {
                    Id = itemId,
                    IsAvailable = false,
                    IsClaim = false
                }) ;
            }
            UpdateCheckListBox();
        }

        private void lbLogic_DoubleClick(object sender, EventArgs e)
        {
            if (sender == lbLogic)
                addRemoveToCheck((lbLogic.Items[lbLogic.SelectedIndex] as JsonFormatLogicItem).Id);
            else if (sender == lbCheck)
                addRemoveToCheck((lbCheck.Items[lbCheck.SelectedIndex] as CheckLogic).Id, true);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateLogicFile();
        }

        private void btnLoadCheck_Click(object sender, EventArgs e)
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
            {
                try
                {
                    checkLogics = CheckLogicMethod.Deserialize(openFileDialog.FileName);
                    UpdateCheckListBox();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSaveCheck_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                InitialDirectory = Application.StartupPath,
                //CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "json",
                Filter = "Json files (*.json)|*.json|All files (*.*)|*.*",
                FileName = CheckLogicMethod.CST_DEFAULT_FILE_NAME
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    sw.WriteLine(CheckLogicMethod.ToJson(checkLogics));
                }
            }
        }
    }
}
