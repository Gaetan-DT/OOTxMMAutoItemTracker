using MajoraAutoItemTracker.Model.Logic;
using MajoraAutoItemTracker.Model.Logic.OOT;
using System.Collections.Generic;
using System.Windows.Forms;

#nullable enable

namespace MajoraAutoItemTracker.UI.OcarinaOfTimeLogicCreator
{
    class OcarinaOfTimeLogicCreatorController
    {
        const string CST_REQ_CASUAL_PATH = @"\Resource\Logics\";
        const string CST_REQ_FILE_NAME = "OOT_CUSTOM_REQ_CASUAL_1.json";
        const string CST_REQ_FILE_NAME_UPDATED = "OOT_CUSTOM_REQ_CASUAL_1_updated.json";

        public LogicFile<OcarinaOfTimeJsonFormatLogicItem>? logicFile;

        public void LoadLogic()
        {
            logicFile = LogicFileUtils.FromFile<OcarinaOfTimeJsonFormatLogicItem>(GetFilPath(true, false));
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

        public void SaveLogic(int version, List<OcarinaOfTimeJsonFormatLogicItem> logicFile)
        {
            LogicFileUtils.Save<OcarinaOfTimeJsonFormatLogicItem>(GetFilPath(true, true), new LogicFile<OcarinaOfTimeJsonFormatLogicItem>()
            {
                Version = version,
                Logic = logicFile
            });
            System.Diagnostics.Process.Start(GetFilPath(false, false));
        }

    }
}
