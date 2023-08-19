
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
            this.pictureBoxMMItemList = new System.Windows.Forms.PictureBox();
            this.lbCheckListMM = new System.Windows.Forms.ListBox();
            this.mapMm = new System.Windows.Forms.Panel();
            this.cbEmulatorList = new System.Windows.Forms.ComboBox();
            this.tabGameMenu = new System.Windows.Forms.TabControl();
            this.tabOcarinaOfTime = new System.Windows.Forms.TabPage();
            this.tabMajoraMask = new System.Windows.Forms.TabPage();
            this.cbRomTypeList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefreshGameAndRom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMMItemList)).BeginInit();
            this.tabGameMenu.SuspendLayout();
            this.tabOcarinaOfTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDebug
            // 
            this.lblDebug.AutoSize = true;
            this.lblDebug.Location = new System.Drawing.Point(1342, 89);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(42, 13);
            this.lblDebug.TabIndex = 0;
            this.lblDebug.Text = "Debug:";
            // 
            // btnStartListener
            // 
            this.btnStartListener.Location = new System.Drawing.Point(1536, 79);
            this.btnStartListener.Name = "btnStartListener";
            this.btnStartListener.Size = new System.Drawing.Size(77, 23);
            this.btnStartListener.TabIndex = 1;
            this.btnStartListener.Text = "Start";
            this.btnStartListener.UseVisualStyleBackColor = true;
            this.btnStartListener.Click += new System.EventHandler(this.BtnStartListenerClick);
            // 
            // btnStopListener
            // 
            this.btnStopListener.Location = new System.Drawing.Point(1619, 79);
            this.btnStopListener.Name = "btnStopListener";
            this.btnStopListener.Size = new System.Drawing.Size(77, 23);
            this.btnStopListener.TabIndex = 2;
            this.btnStopListener.Text = "Stop";
            this.btnStopListener.UseVisualStyleBackColor = true;
            this.btnStopListener.Click += new System.EventHandler(this.BtnStopListener_Click);
            // 
            // tboxDebug
            // 
            this.tboxDebug.Location = new System.Drawing.Point(1342, 105);
            this.tboxDebug.Multiline = true;
            this.tboxDebug.Name = "tboxDebug";
            this.tboxDebug.Size = new System.Drawing.Size(360, 717);
            this.tboxDebug.TabIndex = 3;
            // 
            // pictureBoxMMItemList
            // 
            this.pictureBoxMMItemList.InitialImage = null;
            this.pictureBoxMMItemList.Location = new System.Drawing.Point(6, 3);
            this.pictureBoxMMItemList.Name = "pictureBoxMMItemList";
            this.pictureBoxMMItemList.Size = new System.Drawing.Size(320, 522);
            this.pictureBoxMMItemList.TabIndex = 4;
            this.pictureBoxMMItemList.TabStop = false;
            // 
            // lbCheckListMM
            // 
            this.lbCheckListMM.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbCheckListMM.FormattingEnabled = true;
            this.lbCheckListMM.Location = new System.Drawing.Point(6, 531);
            this.lbCheckListMM.Name = "lbCheckListMM";
            this.lbCheckListMM.Size = new System.Drawing.Size(320, 264);
            this.lbCheckListMM.TabIndex = 67;
            // 
            // mapMm
            // 
            this.mapMm.Location = new System.Drawing.Point(332, 3);
            this.mapMm.Name = "mapMm";
            this.mapMm.Size = new System.Drawing.Size(978, 792);
            this.mapMm.TabIndex = 68;
            // 
            // cbEmulatorList
            // 
            this.cbEmulatorList.FormattingEnabled = true;
            this.cbEmulatorList.Location = new System.Drawing.Point(1446, 12);
            this.cbEmulatorList.Name = "cbEmulatorList";
            this.cbEmulatorList.Size = new System.Drawing.Size(250, 21);
            this.cbEmulatorList.TabIndex = 69;
            // 
            // tabGameMenu
            // 
            this.tabGameMenu.Controls.Add(this.tabOcarinaOfTime);
            this.tabGameMenu.Controls.Add(this.tabMajoraMask);
            this.tabGameMenu.Location = new System.Drawing.Point(6, 1);
            this.tabGameMenu.Name = "tabGameMenu";
            this.tabGameMenu.SelectedIndex = 0;
            this.tabGameMenu.Size = new System.Drawing.Size(1330, 825);
            this.tabGameMenu.TabIndex = 70;
            // 
            // tabOcarinaOfTime
            // 
            this.tabOcarinaOfTime.Controls.Add(this.pictureBoxMMItemList);
            this.tabOcarinaOfTime.Controls.Add(this.mapMm);
            this.tabOcarinaOfTime.Controls.Add(this.lbCheckListMM);
            this.tabOcarinaOfTime.Location = new System.Drawing.Point(4, 22);
            this.tabOcarinaOfTime.Name = "tabOcarinaOfTime";
            this.tabOcarinaOfTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabOcarinaOfTime.Size = new System.Drawing.Size(1322, 799);
            this.tabOcarinaOfTime.TabIndex = 0;
            this.tabOcarinaOfTime.Text = "Ocarina of time";
            this.tabOcarinaOfTime.UseVisualStyleBackColor = true;
            // 
            // tabMajoraMask
            // 
            this.tabMajoraMask.Location = new System.Drawing.Point(4, 22);
            this.tabMajoraMask.Name = "tabMajoraMask";
            this.tabMajoraMask.Padding = new System.Windows.Forms.Padding(3);
            this.tabMajoraMask.Size = new System.Drawing.Size(1322, 799);
            this.tabMajoraMask.TabIndex = 1;
            this.tabMajoraMask.Text = "Majora mask";
            this.tabMajoraMask.UseVisualStyleBackColor = true;
            // 
            // cbRomTypeList
            // 
            this.cbRomTypeList.FormattingEnabled = true;
            this.cbRomTypeList.Location = new System.Drawing.Point(1446, 39);
            this.cbRomTypeList.Name = "cbRomTypeList";
            this.cbRomTypeList.Size = new System.Drawing.Size(250, 21);
            this.cbRomTypeList.TabIndex = 71;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1342, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "Emulator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1342, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "Rom type";
            // 
            // btnRefreshGameAndRom
            // 
            this.btnRefreshGameAndRom.Location = new System.Drawing.Point(1453, 79);
            this.btnRefreshGameAndRom.Name = "btnRefreshGameAndRom";
            this.btnRefreshGameAndRom.Size = new System.Drawing.Size(77, 23);
            this.btnRefreshGameAndRom.TabIndex = 74;
            this.btnRefreshGameAndRom.Text = "Refresh";
            this.btnRefreshGameAndRom.UseVisualStyleBackColor = true;
            this.btnRefreshGameAndRom.Click += new System.EventHandler(this.btnRefreshGameAndRom_Click);
            // 
            // MainUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1708, 829);
            this.Controls.Add(this.btnRefreshGameAndRom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbRomTypeList);
            this.Controls.Add(this.tabGameMenu);
            this.Controls.Add(this.cbEmulatorList);
            this.Controls.Add(this.tboxDebug);
            this.Controls.Add(this.btnStopListener);
            this.Controls.Add(this.btnStartListener);
            this.Controls.Add(this.lblDebug);
            this.Name = "MainUIForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.OnMainUiFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMMItemList)).EndInit();
            this.tabGameMenu.ResumeLayout(false);
            this.tabOcarinaOfTime.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDebug;
        private System.Windows.Forms.Button btnStartListener;
        private System.Windows.Forms.Button btnStopListener;
        private System.Windows.Forms.TextBox tboxDebug;
        private System.Windows.Forms.PictureBox pictureBoxMMItemList;
        private System.Windows.Forms.ListBox lbCheckListMM;
        private System.Windows.Forms.Panel mapMm;
        private System.Windows.Forms.ComboBox cbEmulatorList;
        private System.Windows.Forms.TabControl tabGameMenu;
        private System.Windows.Forms.TabPage tabOcarinaOfTime;
        private System.Windows.Forms.TabPage tabMajoraMask;
        private System.Windows.Forms.ComboBox cbRomTypeList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefreshGameAndRom;
    }
}

