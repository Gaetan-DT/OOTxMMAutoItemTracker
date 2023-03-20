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

namespace WindowsFormsApp1
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
            Log("Initializing thread");
            mMemoryListener = new MemoryListener(modLoader64Wrapper, CallBackMemoryListener);
            mMemoryListener.start();
            Log("Thread started");
        }

        private void BtnStopListener_Click(object sender, EventArgs e)
        {
            mMemoryListener.stop();
            mMemoryListener = null;
            Log("Thread Stoped");
        }

        private void CallBackMemoryListener(String message)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (message != null)
                    this.Log(message);
                Log("Link transformation: " + mMemoryListener.getMemoryDump().currentLinkTransformation);
            });
        }

        private void Log(String message)
        {            
            tboxDebug.AppendText(message + "\r\n");
            Debug.WriteLine(message);
        }
    }
}
