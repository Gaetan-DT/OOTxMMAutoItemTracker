using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MajoraAutoItemTracker
{
    public partial class Form1 : Form
    {
        MemoryListener mMemoryListener = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log("Attaching to modloader");
            ModLoader64Wrapper modLoader64Wrapper = new ModLoader64Wrapper();
            MajoraMemoryDataObserver majoraMemoryDataObserver = new MajoraMemoryDataObserver();
            Log("Initializing thread");
            mMemoryListener = new MemoryListener(modLoader64Wrapper, majoraMemoryDataObserver, CallBackMemoryListener);
            mMemoryListener.Start();
            Log("Thread started");
            majoraMemoryDataObserver.CurrentLinkTransformation.Subscribe(foo =>
            {
                Debug.WriteLine("Update link transformatin: " + foo);
            });
        }

        private void BtnStopListener_Click(object sender, EventArgs e)
        {
            mMemoryListener.Stop();
            mMemoryListener = null;
            Log("Thread Stoped");
        }

        private void CallBackMemoryListener(String message)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (message != null)
                    this.Log(message);
            });
        }

        private void Log(String message)
        {            
            tboxDebug.AppendText(message + "\r\n");
            Debug.WriteLine(message);
        }
    }
}
