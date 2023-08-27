﻿using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI.MainUI
{
    class SaveCheckController
    {
        const string CST_SAVE_PATH = @"\Resource\Save";
        const string CST_AUTO_SAVE_NAME = "AutoSave.json";

        private string autoSavePath = Application.StartupPath + CST_SAVE_PATH;

        public CheckSaveFormatHeader LoadFromAutoSave(RomType romType)
        {
            return Load(autoSavePath + GetAutoSaveFileName(romType));
        }

        public void SaveToAutoSave(RomType romType, CheckSaveFormatHeader data)
        {
            Save(autoSavePath + GetAutoSaveFileName(romType), data);
        }

        public CheckSaveFormatHeader LoadFromFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = autoSavePath,
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
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return null;
            var filePathWithFileName = openFileDialog.FileName;
            return Load(filePathWithFileName);
        }

        public void SaveToFile(CheckSaveFormatHeader data)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                InitialDirectory = autoSavePath,
                Title = "Select check json file",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "json",
                Filter = "json files (*.json)|*.json",
                FilterIndex = 2,
                RestoreDirectory = true,
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            var filePathWithFileName = saveFileDialog.FileName;
            Save(filePathWithFileName, data);
        }

        private CheckSaveFormatHeader Load(string filePathWithName)
        {
            return CheckSaveMethod.DeserializeFromFile(filePathWithName);
        }

        private void Save(string filePathWithName, CheckSaveFormatHeader checkSaveFormatHeader)
        {
            CheckSaveMethod.SerializeToFile(checkSaveFormatHeader, filePathWithName);
        }

        private string GetAutoSaveFileName(RomType romType)
        {
            string prefix;
            switch (romType)
            {
                case RomType.MAJORA_MASK_USA_V0:
                    prefix = "MM_";
                    break;
                case RomType.OCARINA_OF_TIME_USA_V0:
                    prefix = "OOT_";
                    break;
                case RomType.RANDOMIZE_OOT_X_MM:
                    prefix = "OOT_X_MM_";
                    break;
                default:
                    throw new Exception($"Unknown RomType: {romType}");
            }
            return prefix + CST_AUTO_SAVE_NAME;
        }
    }
}
