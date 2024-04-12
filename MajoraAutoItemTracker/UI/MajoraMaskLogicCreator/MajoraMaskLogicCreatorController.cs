using MajoraAutoItemTracker.Model.Logic;
using MajoraAutoItemTracker.Model.Logic.MM;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI.MajoraMaskLogicCreator
{
    class MajoraMaskLogicCreatorController
    {
        const string CST_REQ_CASUAL_PATH = @"\";
        const string CST_REQ_FILE_NAME = "MM_CUSTOM_REQ_CASUAL_1.json";
        const string CST_REQ_FILE_NAME_UPDATED = "MM_CUSTOM_REQ_CASUAL_1_updated.json";

        public LogicFile<MajoraMaskJsonFormatLogicItem>? logicFile;

        public void LoadLogic()
        {
            logicFile = LogicFileUtils.LoadMajoraMaskFromRessource();
        }

        private string GetFilPath(bool withFileName, bool updatedFile)
        {
            var fileName = CST_REQ_FILE_NAME;
            if (updatedFile)
                fileName = CST_REQ_FILE_NAME_UPDATED;
            if (!withFileName)
                fileName = "";
            return Application.StartupPath + CST_REQ_CASUAL_PATH + fileName;
        }

        public int GetLogicFileVersion()
        {
            return logicFile?.Version ?? -1;
        }

        public void SaveLogic(int version, List<MajoraMaskJsonFormatLogicItem> logicFile)
        {
            LogicFileUtils.Save<MajoraMaskJsonFormatLogicItem>(GetFilPath(true, true), new LogicFile<MajoraMaskJsonFormatLogicItem>()
            {
                Version = version,
                Logic = logicFile
            });
            System.Diagnostics.Process.Start(GetFilPath(false, false));
        }

    }
}
