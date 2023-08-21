using MajoraAutoItemTracker.Model.Logic;
using MajoraAutoItemTracker.Model.Logic.OOT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI.OcarinaOfTimeLogicCreator
{
    class OcarinaOfTimeLogicCreatorController
    {
        const string CST_REQ_CASUAL_PATH = @"\Resource\Logics\OOT_CUSTOM_REQ_CASUAL_1.json";

        public LogicFile<OcarinaOfTimeJsonFormatLogicItem> logicFile;

        public void LoadLogic()
        {
            logicFile = LogicFile<OcarinaOfTimeJsonFormatLogicItem>.FromFile(Application.StartupPath + CST_REQ_CASUAL_PATH);
        }

        public int GetLogicFileVersion()
        {
            return logicFile.Version;
        }

    }
}
