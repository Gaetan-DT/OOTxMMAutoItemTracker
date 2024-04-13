namespace MajoraAutoItemTracker.UI.InitConfig
{
    partial class InitConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbDebug = new System.Windows.Forms.GroupBox();
            btnStartMmLogicCreator = new System.Windows.Forms.Button();
            btnStartOotLogicCreator = new System.Windows.Forms.Button();
            btnStartLogicTester = new System.Windows.Forms.Button();
            btnStartCheckLogicEditor = new System.Windows.Forms.Button();
            gbEmulatorSelection = new System.Windows.Forms.GroupBox();
            btnRefreshEmulatorList = new System.Windows.Forms.Button();
            cbEmulatorList = new System.Windows.Forms.ComboBox();
            gbRomType = new System.Windows.Forms.GroupBox();
            btnRefreshRomType = new System.Windows.Forms.Button();
            cbRomTypeList = new System.Windows.Forms.ComboBox();
            gbOcarinaOfTime = new System.Windows.Forms.GroupBox();
            btnClearOOTStartAddrs = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            tbOotStartAddress = new System.Windows.Forms.TextBox();
            btnStartFromOOT = new System.Windows.Forms.Button();
            btnStartFromMM = new System.Windows.Forms.Button();
            gbMajoraMask = new System.Windows.Forms.GroupBox();
            btnClearMmAddress = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            tbMmStartAddress = new System.Windows.Forms.TextBox();
            lbLastErrorText = new System.Windows.Forms.Label();
            groupBox3 = new System.Windows.Forms.GroupBox();
            btnResetCheckSave = new System.Windows.Forms.Button();
            btnLoadCheckSave = new System.Windows.Forms.Button();
            gbDebug.SuspendLayout();
            gbEmulatorSelection.SuspendLayout();
            gbRomType.SuspendLayout();
            gbOcarinaOfTime.SuspendLayout();
            gbMajoraMask.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // gbDebug
            // 
            gbDebug.Controls.Add(btnStartMmLogicCreator);
            gbDebug.Controls.Add(btnStartOotLogicCreator);
            gbDebug.Controls.Add(btnStartLogicTester);
            gbDebug.Controls.Add(btnStartCheckLogicEditor);
            gbDebug.Location = new System.Drawing.Point(12, 498);
            gbDebug.Name = "gbDebug";
            gbDebug.Size = new System.Drawing.Size(376, 81);
            gbDebug.TabIndex = 0;
            gbDebug.TabStop = false;
            gbDebug.Text = "Debug option";
            // 
            // btnStartMmLogicCreator
            // 
            btnStartMmLogicCreator.Location = new System.Drawing.Point(243, 51);
            btnStartMmLogicCreator.Name = "btnStartMmLogicCreator";
            btnStartMmLogicCreator.Size = new System.Drawing.Size(127, 23);
            btnStartMmLogicCreator.TabIndex = 3;
            btnStartMmLogicCreator.Text = "MM logic creator";
            btnStartMmLogicCreator.UseVisualStyleBackColor = true;
            btnStartMmLogicCreator.Click += btnStartMmLogicCreator_Click;
            // 
            // btnStartOotLogicCreator
            // 
            btnStartOotLogicCreator.Location = new System.Drawing.Point(243, 22);
            btnStartOotLogicCreator.Name = "btnStartOotLogicCreator";
            btnStartOotLogicCreator.Size = new System.Drawing.Size(127, 23);
            btnStartOotLogicCreator.TabIndex = 2;
            btnStartOotLogicCreator.Text = "OOT logic creator";
            btnStartOotLogicCreator.UseVisualStyleBackColor = true;
            btnStartOotLogicCreator.Click += btnStartOotLogicCreator_Click;
            // 
            // btnStartLogicTester
            // 
            btnStartLogicTester.Location = new System.Drawing.Point(6, 51);
            btnStartLogicTester.Name = "btnStartLogicTester";
            btnStartLogicTester.Size = new System.Drawing.Size(127, 23);
            btnStartLogicTester.TabIndex = 1;
            btnStartLogicTester.Text = "Logic tester";
            btnStartLogicTester.UseVisualStyleBackColor = true;
            btnStartLogicTester.Click += btnStartLogicTester_Click;
            // 
            // btnStartCheckLogicEditor
            // 
            btnStartCheckLogicEditor.Location = new System.Drawing.Point(6, 22);
            btnStartCheckLogicEditor.Name = "btnStartCheckLogicEditor";
            btnStartCheckLogicEditor.Size = new System.Drawing.Size(127, 23);
            btnStartCheckLogicEditor.TabIndex = 0;
            btnStartCheckLogicEditor.Text = "Check logic editor";
            btnStartCheckLogicEditor.UseVisualStyleBackColor = true;
            btnStartCheckLogicEditor.Click += btnStartCheckLogicEditor_Click;
            // 
            // gbEmulatorSelection
            // 
            gbEmulatorSelection.Controls.Add(btnRefreshEmulatorList);
            gbEmulatorSelection.Controls.Add(cbEmulatorList);
            gbEmulatorSelection.Location = new System.Drawing.Point(12, 12);
            gbEmulatorSelection.Name = "gbEmulatorSelection";
            gbEmulatorSelection.Size = new System.Drawing.Size(376, 59);
            gbEmulatorSelection.TabIndex = 1;
            gbEmulatorSelection.TabStop = false;
            gbEmulatorSelection.Text = "Emulator";
            // 
            // btnRefreshEmulatorList
            // 
            btnRefreshEmulatorList.Location = new System.Drawing.Point(295, 21);
            btnRefreshEmulatorList.Name = "btnRefreshEmulatorList";
            btnRefreshEmulatorList.Size = new System.Drawing.Size(75, 23);
            btnRefreshEmulatorList.TabIndex = 1;
            btnRefreshEmulatorList.Text = "Refresh";
            btnRefreshEmulatorList.UseVisualStyleBackColor = true;
            btnRefreshEmulatorList.Click += btnRefreshEmulatorList_Click;
            // 
            // cbEmulatorList
            // 
            cbEmulatorList.FormattingEnabled = true;
            cbEmulatorList.Location = new System.Drawing.Point(6, 22);
            cbEmulatorList.Name = "cbEmulatorList";
            cbEmulatorList.Size = new System.Drawing.Size(248, 23);
            cbEmulatorList.TabIndex = 0;
            // 
            // gbRomType
            // 
            gbRomType.Controls.Add(btnRefreshRomType);
            gbRomType.Controls.Add(cbRomTypeList);
            gbRomType.Location = new System.Drawing.Point(12, 98);
            gbRomType.Name = "gbRomType";
            gbRomType.Size = new System.Drawing.Size(376, 62);
            gbRomType.TabIndex = 2;
            gbRomType.TabStop = false;
            gbRomType.Text = "RomType";
            // 
            // btnRefreshRomType
            // 
            btnRefreshRomType.Location = new System.Drawing.Point(295, 21);
            btnRefreshRomType.Name = "btnRefreshRomType";
            btnRefreshRomType.Size = new System.Drawing.Size(75, 23);
            btnRefreshRomType.TabIndex = 2;
            btnRefreshRomType.Text = "Refresh";
            btnRefreshRomType.UseVisualStyleBackColor = true;
            btnRefreshRomType.Click += btnRefreshRomType_Click;
            // 
            // cbRomTypeList
            // 
            cbRomTypeList.FormattingEnabled = true;
            cbRomTypeList.Location = new System.Drawing.Point(6, 22);
            cbRomTypeList.Name = "cbRomTypeList";
            cbRomTypeList.Size = new System.Drawing.Size(248, 23);
            cbRomTypeList.TabIndex = 1;
            // 
            // gbOcarinaOfTime
            // 
            gbOcarinaOfTime.Controls.Add(btnClearOOTStartAddrs);
            gbOcarinaOfTime.Controls.Add(label1);
            gbOcarinaOfTime.Controls.Add(tbOotStartAddress);
            gbOcarinaOfTime.Controls.Add(btnStartFromOOT);
            gbOcarinaOfTime.Location = new System.Drawing.Point(12, 245);
            gbOcarinaOfTime.Name = "gbOcarinaOfTime";
            gbOcarinaOfTime.Size = new System.Drawing.Size(376, 84);
            gbOcarinaOfTime.TabIndex = 3;
            gbOcarinaOfTime.TabStop = false;
            gbOcarinaOfTime.Text = "groupBox1";
            // 
            // btnClearOOTStartAddrs
            // 
            btnClearOOTStartAddrs.Location = new System.Drawing.Point(209, 22);
            btnClearOOTStartAddrs.Name = "btnClearOOTStartAddrs";
            btnClearOOTStartAddrs.Size = new System.Drawing.Size(75, 23);
            btnClearOOTStartAddrs.TabIndex = 3;
            btnClearOOTStartAddrs.Text = "Clear";
            btnClearOOTStartAddrs.UseVisualStyleBackColor = true;
            btnClearOOTStartAddrs.Click += btnClearOOTStartAddrs_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(23, 25);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(74, 15);
            label1.TabIndex = 2;
            label1.Text = "Start address";
            // 
            // tbOotStartAddress
            // 
            tbOotStartAddress.Location = new System.Drawing.Point(103, 22);
            tbOotStartAddress.Name = "tbOotStartAddress";
            tbOotStartAddress.ReadOnly = true;
            tbOotStartAddress.Size = new System.Drawing.Size(100, 23);
            tbOotStartAddress.TabIndex = 1;
            // 
            // btnStartFromOOT
            // 
            btnStartFromOOT.Location = new System.Drawing.Point(6, 51);
            btnStartFromOOT.Name = "btnStartFromOOT";
            btnStartFromOOT.Size = new System.Drawing.Size(364, 23);
            btnStartFromOOT.TabIndex = 0;
            btnStartFromOOT.Text = "Start from ocarina of time";
            btnStartFromOOT.UseVisualStyleBackColor = true;
            btnStartFromOOT.Click += btnStartFromOOT_Click;
            // 
            // btnStartFromMM
            // 
            btnStartFromMM.Location = new System.Drawing.Point(6, 51);
            btnStartFromMM.Name = "btnStartFromMM";
            btnStartFromMM.Size = new System.Drawing.Size(364, 23);
            btnStartFromMM.TabIndex = 1;
            btnStartFromMM.Text = "Start from majora mask";
            btnStartFromMM.UseVisualStyleBackColor = true;
            btnStartFromMM.Click += btnStartFromMM_Click;
            // 
            // gbMajoraMask
            // 
            gbMajoraMask.Controls.Add(btnClearMmAddress);
            gbMajoraMask.Controls.Add(label2);
            gbMajoraMask.Controls.Add(tbMmStartAddress);
            gbMajoraMask.Controls.Add(btnStartFromMM);
            gbMajoraMask.Location = new System.Drawing.Point(12, 373);
            gbMajoraMask.Name = "gbMajoraMask";
            gbMajoraMask.Size = new System.Drawing.Size(376, 84);
            gbMajoraMask.TabIndex = 4;
            gbMajoraMask.TabStop = false;
            gbMajoraMask.Text = "groupBox2";
            // 
            // btnClearMmAddress
            // 
            btnClearMmAddress.Location = new System.Drawing.Point(209, 22);
            btnClearMmAddress.Name = "btnClearMmAddress";
            btnClearMmAddress.Size = new System.Drawing.Size(75, 23);
            btnClearMmAddress.TabIndex = 6;
            btnClearMmAddress.Text = "Clear";
            btnClearMmAddress.UseVisualStyleBackColor = true;
            btnClearMmAddress.Click += btnClearMmAddress_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(23, 25);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(74, 15);
            label2.TabIndex = 5;
            label2.Text = "Start address";
            // 
            // tbMmStartAddress
            // 
            tbMmStartAddress.Location = new System.Drawing.Point(103, 22);
            tbMmStartAddress.Name = "tbMmStartAddress";
            tbMmStartAddress.ReadOnly = true;
            tbMmStartAddress.Size = new System.Drawing.Size(100, 23);
            tbMmStartAddress.TabIndex = 4;
            // 
            // lbLastErrorText
            // 
            lbLastErrorText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lbLastErrorText.ForeColor = System.Drawing.Color.Red;
            lbLastErrorText.Location = new System.Drawing.Point(18, 460);
            lbLastErrorText.Name = "lbLastErrorText";
            lbLastErrorText.Size = new System.Drawing.Size(364, 26);
            lbLastErrorText.TabIndex = 5;
            lbLastErrorText.Text = "Waiting for command";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnResetCheckSave);
            groupBox3.Controls.Add(btnLoadCheckSave);
            groupBox3.Location = new System.Drawing.Point(12, 166);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(376, 73);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Check save";
            // 
            // btnResetCheckSave
            // 
            btnResetCheckSave.Location = new System.Drawing.Point(161, 32);
            btnResetCheckSave.Name = "btnResetCheckSave";
            btnResetCheckSave.Size = new System.Drawing.Size(75, 23);
            btnResetCheckSave.TabIndex = 4;
            btnResetCheckSave.Text = "Clear check";
            btnResetCheckSave.UseVisualStyleBackColor = true;
            btnResetCheckSave.Click += btnResetCheckSave_Click;
            // 
            // btnLoadCheckSave
            // 
            btnLoadCheckSave.Location = new System.Drawing.Point(22, 32);
            btnLoadCheckSave.Name = "btnLoadCheckSave";
            btnLoadCheckSave.Size = new System.Drawing.Size(111, 23);
            btnLoadCheckSave.TabIndex = 3;
            btnLoadCheckSave.Text = "Load from file";
            btnLoadCheckSave.UseVisualStyleBackColor = true;
            btnLoadCheckSave.Click += btnLoadCheckSave_Click;
            // 
            // InitConfigForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(400, 588);
            Controls.Add(groupBox3);
            Controls.Add(lbLastErrorText);
            Controls.Add(gbMajoraMask);
            Controls.Add(gbOcarinaOfTime);
            Controls.Add(gbRomType);
            Controls.Add(gbEmulatorSelection);
            Controls.Add(gbDebug);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InitConfigForm";
            Text = "InitConfigForm";
            Load += InitConfigForm_Load;
            gbDebug.ResumeLayout(false);
            gbEmulatorSelection.ResumeLayout(false);
            gbRomType.ResumeLayout(false);
            gbOcarinaOfTime.ResumeLayout(false);
            gbOcarinaOfTime.PerformLayout();
            gbMajoraMask.ResumeLayout(false);
            gbMajoraMask.PerformLayout();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox gbDebug;
        private System.Windows.Forms.GroupBox gbEmulatorSelection;
        private System.Windows.Forms.GroupBox gbRomType;
        private System.Windows.Forms.GroupBox gbOcarinaOfTime;
        private System.Windows.Forms.Button btnStartFromOOT;
        private System.Windows.Forms.Button btnStartFromMM;
        private System.Windows.Forms.GroupBox gbMajoraMask;
        private System.Windows.Forms.Button btnClearOOTStartAddrs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbOotStartAddress;
        private System.Windows.Forms.Button btnClearMmAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMmStartAddress;
        private System.Windows.Forms.Button btnStartCheckLogicEditor;
        private System.Windows.Forms.Button btnStartLogicTester;
        private System.Windows.Forms.Button btnStartMmLogicCreator;
        private System.Windows.Forms.Button btnStartOotLogicCreator;
        private System.Windows.Forms.Label lbLastErrorText;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRefreshEmulatorList;
        private System.Windows.Forms.ComboBox cbEmulatorList;
        private System.Windows.Forms.ComboBox cbRomTypeList;
        private System.Windows.Forms.Button btnRefreshRomType;
        private System.Windows.Forms.Button btnResetCheckSave;
        private System.Windows.Forms.Button btnLoadCheckSave;
    }
}