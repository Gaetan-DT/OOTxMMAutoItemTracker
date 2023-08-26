
using System;
using System.Threading;

namespace MajoraAutoItemTracker.UI.MainUI
{
    partial class MainUIForm
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
            this.lblDebug = new System.Windows.Forms.Label();
            this.btnStartListener = new System.Windows.Forms.Button();
            this.btnStopListener = new System.Windows.Forms.Button();
            this.tboxDebug = new System.Windows.Forms.TextBox();
            this.pictureBoxOOTItemList = new System.Windows.Forms.PictureBox();
            this.lbCheckListOOT = new System.Windows.Forms.ListBox();
            this.panelMapOOT = new System.Windows.Forms.Panel();
            this.cbEmulatorList = new System.Windows.Forms.ComboBox();
            this.tabGameMenu = new System.Windows.Forms.TabControl();
            this.tabOcarinaOfTime = new System.Windows.Forms.TabPage();
            this.tabMajoraMask = new System.Windows.Forms.TabPage();
            this.panelMapMM = new System.Windows.Forms.Panel();
            this.lbCheckListMM = new System.Windows.Forms.ListBox();
            this.pictureBoxMMItemList = new System.Windows.Forms.PictureBox();
            this.cbRomTypeList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefreshGameAndRom = new System.Windows.Forms.Button();
            this.btnOpenChekLogicEditor = new System.Windows.Forms.Button();
            this.btnOpenLogicTester = new System.Windows.Forms.Button();
            this.btnOotLogicCreator = new System.Windows.Forms.Button();
            this.panelConfig = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOOTItemList)).BeginInit();
            this.tabGameMenu.SuspendLayout();
            this.tabOcarinaOfTime.SuspendLayout();
            this.tabMajoraMask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMMItemList)).BeginInit();
            this.panelConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDebug
            // 
            this.lblDebug.AutoSize = true;
            this.lblDebug.Location = new System.Drawing.Point(8, 122);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(42, 13);
            this.lblDebug.TabIndex = 0;
            this.lblDebug.Text = "Debug:";
            // 
            // btnStartListener
            // 
            this.btnStartListener.Location = new System.Drawing.Point(198, 67);
            this.btnStartListener.Name = "btnStartListener";
            this.btnStartListener.Size = new System.Drawing.Size(77, 23);
            this.btnStartListener.TabIndex = 1;
            this.btnStartListener.Text = "Start";
            this.btnStartListener.UseVisualStyleBackColor = true;
            this.btnStartListener.Click += new System.EventHandler(this.BtnStartListenerClick);
            // 
            // btnStopListener
            // 
            this.btnStopListener.Location = new System.Drawing.Point(281, 67);
            this.btnStopListener.Name = "btnStopListener";
            this.btnStopListener.Size = new System.Drawing.Size(77, 23);
            this.btnStopListener.TabIndex = 2;
            this.btnStopListener.Text = "Stop";
            this.btnStopListener.UseVisualStyleBackColor = true;
            this.btnStopListener.Click += new System.EventHandler(this.BtnStopListener_Click);
            // 
            // tboxDebug
            // 
            this.tboxDebug.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tboxDebug.Location = new System.Drawing.Point(4, 138);
            this.tboxDebug.Multiline = true;
            this.tboxDebug.Name = "tboxDebug";
            this.tboxDebug.Size = new System.Drawing.Size(360, 687);
            this.tboxDebug.TabIndex = 3;
            // 
            // pictureBoxOOTItemList
            // 
            this.pictureBoxOOTItemList.InitialImage = null;
            this.pictureBoxOOTItemList.Location = new System.Drawing.Point(6, 3);
            this.pictureBoxOOTItemList.Name = "pictureBoxOOTItemList";
            this.pictureBoxOOTItemList.Size = new System.Drawing.Size(320, 522);
            this.pictureBoxOOTItemList.TabIndex = 4;
            this.pictureBoxOOTItemList.TabStop = false;
            // 
            // lbCheckListOOT
            // 
            this.lbCheckListOOT.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbCheckListOOT.FormattingEnabled = true;
            this.lbCheckListOOT.Location = new System.Drawing.Point(6, 531);
            this.lbCheckListOOT.Name = "lbCheckListOOT";
            this.lbCheckListOOT.Size = new System.Drawing.Size(320, 264);
            this.lbCheckListOOT.TabIndex = 67;
            // 
            // panelMapOOT
            // 
            this.panelMapOOT.Location = new System.Drawing.Point(332, 3);
            this.panelMapOOT.Name = "panelMapOOT";
            this.panelMapOOT.Size = new System.Drawing.Size(978, 792);
            this.panelMapOOT.TabIndex = 68;
            // 
            // cbEmulatorList
            // 
            this.cbEmulatorList.FormattingEnabled = true;
            this.cbEmulatorList.Location = new System.Drawing.Point(108, 13);
            this.cbEmulatorList.Name = "cbEmulatorList";
            this.cbEmulatorList.Size = new System.Drawing.Size(250, 21);
            this.cbEmulatorList.TabIndex = 69;
            // 
            // tabGameMenu
            // 
            this.tabGameMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabGameMenu.Controls.Add(this.tabOcarinaOfTime);
            this.tabGameMenu.Controls.Add(this.tabMajoraMask);
            this.tabGameMenu.Location = new System.Drawing.Point(0, 0);
            this.tabGameMenu.Name = "tabGameMenu";
            this.tabGameMenu.SelectedIndex = 0;
            this.tabGameMenu.Size = new System.Drawing.Size(1344, 826);
            this.tabGameMenu.TabIndex = 70;
            // 
            // tabOcarinaOfTime
            // 
            this.tabOcarinaOfTime.Controls.Add(this.panelMapOOT);
            this.tabOcarinaOfTime.Controls.Add(this.pictureBoxOOTItemList);
            this.tabOcarinaOfTime.Controls.Add(this.lbCheckListOOT);
            this.tabOcarinaOfTime.Location = new System.Drawing.Point(4, 22);
            this.tabOcarinaOfTime.Name = "tabOcarinaOfTime";
            this.tabOcarinaOfTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabOcarinaOfTime.Size = new System.Drawing.Size(1336, 800);
            this.tabOcarinaOfTime.TabIndex = 0;
            this.tabOcarinaOfTime.Text = "Ocarina of time";
            this.tabOcarinaOfTime.UseVisualStyleBackColor = true;
            // 
            // tabMajoraMask
            // 
            this.tabMajoraMask.Controls.Add(this.panelMapMM);
            this.tabMajoraMask.Controls.Add(this.lbCheckListMM);
            this.tabMajoraMask.Controls.Add(this.pictureBoxMMItemList);
            this.tabMajoraMask.Location = new System.Drawing.Point(4, 22);
            this.tabMajoraMask.Name = "tabMajoraMask";
            this.tabMajoraMask.Padding = new System.Windows.Forms.Padding(3);
            this.tabMajoraMask.Size = new System.Drawing.Size(1322, 799);
            this.tabMajoraMask.TabIndex = 1;
            this.tabMajoraMask.Text = "Majora mask";
            this.tabMajoraMask.UseVisualStyleBackColor = true;
            // 
            // panelMapMM
            // 
            this.panelMapMM.Location = new System.Drawing.Point(322, 3);
            this.panelMapMM.Name = "panelMapMM";
            this.panelMapMM.Size = new System.Drawing.Size(978, 792);
            this.panelMapMM.TabIndex = 69;
            // 
            // lbCheckListMM
            // 
            this.lbCheckListMM.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbCheckListMM.FormattingEnabled = true;
            this.lbCheckListMM.Location = new System.Drawing.Point(0, 528);
            this.lbCheckListMM.Name = "lbCheckListMM";
            this.lbCheckListMM.Size = new System.Drawing.Size(320, 264);
            this.lbCheckListMM.TabIndex = 68;
            // 
            // pictureBoxMMItemList
            // 
            this.pictureBoxMMItemList.InitialImage = null;
            this.pictureBoxMMItemList.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxMMItemList.Name = "pictureBoxMMItemList";
            this.pictureBoxMMItemList.Size = new System.Drawing.Size(320, 522);
            this.pictureBoxMMItemList.TabIndex = 5;
            this.pictureBoxMMItemList.TabStop = false;
            // 
            // cbRomTypeList
            // 
            this.cbRomTypeList.FormattingEnabled = true;
            this.cbRomTypeList.Location = new System.Drawing.Point(108, 40);
            this.cbRomTypeList.Name = "cbRomTypeList";
            this.cbRomTypeList.Size = new System.Drawing.Size(250, 21);
            this.cbRomTypeList.TabIndex = 71;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "Emulator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "Rom type";
            // 
            // btnRefreshGameAndRom
            // 
            this.btnRefreshGameAndRom.Location = new System.Drawing.Point(115, 67);
            this.btnRefreshGameAndRom.Name = "btnRefreshGameAndRom";
            this.btnRefreshGameAndRom.Size = new System.Drawing.Size(77, 23);
            this.btnRefreshGameAndRom.TabIndex = 74;
            this.btnRefreshGameAndRom.Text = "Refresh";
            this.btnRefreshGameAndRom.UseVisualStyleBackColor = true;
            this.btnRefreshGameAndRom.Click += new System.EventHandler(this.btnRefreshGameAndRom_Click);
            // 
            // btnOpenChekLogicEditor
            // 
            this.btnOpenChekLogicEditor.Location = new System.Drawing.Point(51, 96);
            this.btnOpenChekLogicEditor.Name = "btnOpenChekLogicEditor";
            this.btnOpenChekLogicEditor.Size = new System.Drawing.Size(109, 23);
            this.btnOpenChekLogicEditor.TabIndex = 75;
            this.btnOpenChekLogicEditor.Text = "Check logic editor";
            this.btnOpenChekLogicEditor.UseVisualStyleBackColor = true;
            this.btnOpenChekLogicEditor.Click += new System.EventHandler(this.btnOpenChekLogicEditor_Click);
            // 
            // btnOpenLogicTester
            // 
            this.btnOpenLogicTester.Location = new System.Drawing.Point(166, 96);
            this.btnOpenLogicTester.Name = "btnOpenLogicTester";
            this.btnOpenLogicTester.Size = new System.Drawing.Size(77, 23);
            this.btnOpenLogicTester.TabIndex = 76;
            this.btnOpenLogicTester.Text = "Logic Tester";
            this.btnOpenLogicTester.UseVisualStyleBackColor = true;
            this.btnOpenLogicTester.Click += new System.EventHandler(this.btnOpenLogicTester_Click);
            // 
            // btnOotLogicCreator
            // 
            this.btnOotLogicCreator.Location = new System.Drawing.Point(249, 96);
            this.btnOotLogicCreator.Name = "btnOotLogicCreator";
            this.btnOotLogicCreator.Size = new System.Drawing.Size(109, 23);
            this.btnOotLogicCreator.TabIndex = 77;
            this.btnOotLogicCreator.Text = "OOT Logic creator";
            this.btnOotLogicCreator.UseVisualStyleBackColor = true;
            this.btnOotLogicCreator.Click += new System.EventHandler(this.btnOotLogicCreator_Click);
            // 
            // panelConfig
            // 
            this.panelConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelConfig.Controls.Add(this.label1);
            this.panelConfig.Controls.Add(this.btnOpenChekLogicEditor);
            this.panelConfig.Controls.Add(this.tboxDebug);
            this.panelConfig.Controls.Add(this.btnOpenLogicTester);
            this.panelConfig.Controls.Add(this.btnOotLogicCreator);
            this.panelConfig.Controls.Add(this.cbEmulatorList);
            this.panelConfig.Controls.Add(this.cbRomTypeList);
            this.panelConfig.Controls.Add(this.label2);
            this.panelConfig.Controls.Add(this.btnRefreshGameAndRom);
            this.panelConfig.Controls.Add(this.lblDebug);
            this.panelConfig.Controls.Add(this.btnStartListener);
            this.panelConfig.Controls.Add(this.btnStopListener);
            this.panelConfig.Location = new System.Drawing.Point(1342, 1);
            this.panelConfig.Name = "panelConfig";
            this.panelConfig.Size = new System.Drawing.Size(364, 825);
            this.panelConfig.TabIndex = 78;
            // 
            // MainUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1708, 829);
            this.Controls.Add(this.panelConfig);
            this.Controls.Add(this.tabGameMenu);
            this.Name = "MainUIForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.OnMainUiFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOOTItemList)).EndInit();
            this.tabGameMenu.ResumeLayout(false);
            this.tabOcarinaOfTime.ResumeLayout(false);
            this.tabMajoraMask.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMMItemList)).EndInit();
            this.panelConfig.ResumeLayout(false);
            this.panelConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDebug;
        private System.Windows.Forms.Button btnStartListener;
        private System.Windows.Forms.Button btnStopListener;
        private System.Windows.Forms.TextBox tboxDebug;
        private System.Windows.Forms.PictureBox pictureBoxOOTItemList;
        private System.Windows.Forms.ListBox lbCheckListOOT;
        private System.Windows.Forms.Panel panelMapOOT;
        private System.Windows.Forms.ComboBox cbEmulatorList;
        private System.Windows.Forms.TabControl tabGameMenu;
        private System.Windows.Forms.TabPage tabOcarinaOfTime;
        private System.Windows.Forms.TabPage tabMajoraMask;
        private System.Windows.Forms.ComboBox cbRomTypeList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefreshGameAndRom;
        private System.Windows.Forms.Panel panelMapMM;
        private System.Windows.Forms.ListBox lbCheckListMM;
        private System.Windows.Forms.PictureBox pictureBoxMMItemList;
        private System.Windows.Forms.Button btnOpenChekLogicEditor;
        private System.Windows.Forms.Button btnOpenLogicTester;
        private System.Windows.Forms.Button btnOotLogicCreator;
        private System.Windows.Forms.Panel panelConfig;
    }
}

