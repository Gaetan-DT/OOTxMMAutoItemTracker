using MajoraAutoItemTracker.Model.CheckLogic;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.Core.Utils
{
    public static class CheckItemUtils
    {
        public static CheckSaveFormatHeader? GetCheckSaveFromMemoryOrNull()
        {
            try
            {
                return CheckSaveMethod.DeserializeFromStringOrThrow(Properties.Settings.Default.MemoryCheckJsonStr);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        private static CheckSaveFormatHeader? GetCheckSaveFromPathOrNull(string filePathWithName)
        {
            try
            {
                return CheckSaveMethod.DeserializeFromPathOrThrow(filePathWithName);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }

        }

        public static void SaveCheckSaveToMemory(CheckSaveFormatHeader checkSaveFormatHeader)
        {
            Properties.Settings.Default.MemoryCheckJsonStr = CheckSaveMethod.SerializeOrThrow(checkSaveFormatHeader);
        }

        private static void SaveCheckSaveToFile(string filePathWithName, CheckSaveFormatHeader checkSaveFormatHeader)
        {
            CheckSaveMethod.SerializeToFile(checkSaveFormatHeader, filePathWithName);
        }

        public static void RazCheckSaveFromMemory()
        {
            Properties.Settings.Default.MemoryCheckJsonStr = "";
        }

        public static CheckSaveFormatHeader? LoadFromFile()
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
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return null;
            var filePathWithFileName = openFileDialog.FileName;
            return GetCheckSaveFromPathOrNull(filePathWithFileName);
        }

        public static void SaveToFile(CheckSaveFormatHeader data)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                InitialDirectory = Application.StartupPath,
                Title = "Select check json file",

                CheckFileExists = false,
                CheckPathExists = false,

                DefaultExt = "json",
                Filter = "json files (*.json)|*.json",
                FilterIndex = 2,
                RestoreDirectory = true,
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            var filePathWithFileName = saveFileDialog.FileName;
            SaveCheckSaveToFile(filePathWithFileName, data);
        }
    }
}
