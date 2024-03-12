using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.Model.Logic;
using MajoraAutoItemTracker.Model.Logic.MM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

#nullable enable

namespace MajoraAutoItemTracker.UI.CheckLogicEditor
{
    public partial class CheckLogicEditor : Form
    {

        private LogicFile<MajoraMaskJsonFormatLogicItem>? _logicFile;
        private List<OcarinaOfTimeCheckLogic> checkLogics = new List<OcarinaOfTimeCheckLogic>();

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
            _logicFile = LogicFileUtils.FromJson<MajoraMaskJsonFormatLogicItem>(File.ReadAllText(Application.StartupPath + @"\Resource\Logics\REQ_CASUAL_12.json"));
            lbLogicVerion.Text = "V:" + (_logicFile?.Version ?? -1);
            UpdateLogicFile();
        }

        private void UpdateLogicFile()
        {
            var filter = textLogicFilter.Text;
            lbLogic.Items.Clear();
            var filteredData = _logicFile?.Logic.FindAll(x => filter.Length == 0 || (x.Id?.ToLower().Contains(filter.ToLower()) ?? false));
            filteredData?.ForEach(x => lbLogic.Items.Add(x));
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
            var logic = _logicFile?.Logic.Find(x => x.Id == itemId);
            if (remove)
            {
                if (check != null)
                    checkLogics.Remove(check);
            } 
            else
            {
                if (logic == null || check != null)
                    return;

                checkLogics.Add(new OcarinaOfTimeCheckLogic()
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
            {
                var id = (lbLogic.Items[lbLogic.SelectedIndex] as MajoraMaskJsonFormatLogicItem)?.Id;
                if (id != null)
                    addRemoveToCheck(id);
            } 
            else if (sender == lbCheck)
            {
                var id = (lbCheck.Items[lbCheck.SelectedIndex] as OcarinaOfTimeCheckLogic)?.Id;
                if (id != null)
                    addRemoveToCheck(id, true);
            }
                
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
                    checkLogics = OcarinaOfTimeCheckLogic.Deserialize(openFileDialog.FileName)!;
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
                FileName = OcarinaOfTimeCheckLogic.CST_DEFAULT_FILE_NAME
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    sw.WriteLine(OcarinaOfTimeCheckLogic.ToJson(checkLogics));
                }
            }
        }

        private void btnLoadFromCategory_Click(object sender, EventArgs e)
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
                    var header = CheckLogicCategoryUtils.LoadOcarinaOfTimeFromFile(openFileDialog.FileName)!;
                    checkLogics = OcarinaOfTimeCheckLogic.FromHeader(header);
                    UpdateCheckListBox();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lbCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCheck.SelectedIndex < 0)
                return;
            var selectedItem = (OcarinaOfTimeCheckLogic) lbCheck.Items[lbCheck.SelectedIndex];
            textCheckId.Text = selectedItem.Id?.ToString();
            textCheckIsAvailable.Text = selectedItem.IsAvailable.ToString();
            textCheckIsClaim.Text = selectedItem.IsClaim.ToString();
            textCheckSquareX.Text = selectedItem.SquarePositionX.ToString();
            textCheckSquareY.Text = selectedItem.SquarePositionY.ToString();
            textCheckZone.Text = selectedItem.Zone.ToString();
        }
    }
}
