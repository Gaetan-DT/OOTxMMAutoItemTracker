using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI.OcarinaOfTimeLogicCreator
{
    public partial class OcarinaOfTimeLogicCreator : Form
    {

        OcarinaOfTimeLogicCreatorController controller = new OcarinaOfTimeLogicCreatorController();

        public OcarinaOfTimeLogicCreator()
        {
            InitializeComponent();
        }

        private void OcarinaOfTimeLogicCreator_Load(object sender, EventArgs e)
        {
            controller.LoadLogic();
        }
    }
}
