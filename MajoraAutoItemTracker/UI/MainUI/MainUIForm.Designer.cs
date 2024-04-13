
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUIForm));
            tboxDebug = new System.Windows.Forms.TextBox();
            pictureBoxOOTItemList = new System.Windows.Forms.PictureBox();
            lbCheckListOOT = new System.Windows.Forms.ListBox();
            tabGameMenu = new System.Windows.Forms.TabControl();
            tabOcarinaOfTime = new System.Windows.Forms.TabPage();
            splitContainerOotSideContent = new System.Windows.Forms.SplitContainer();
            splitContainerOotCheckListCheckItemSeparator = new System.Windows.Forms.SplitContainer();
            gbCheckListOOT = new System.Windows.Forms.GroupBox();
            imageBoxMapOOT = new Cyotek.Windows.Forms.ImageBox();
            tabMajoraMask = new System.Windows.Forms.TabPage();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            splitContainer2 = new System.Windows.Forms.SplitContainer();
            pictureBoxMMItemList = new System.Windows.Forms.PictureBox();
            gbCheckListMM = new System.Windows.Forms.GroupBox();
            lbCheckListMM = new System.Windows.Forms.ListBox();
            imageBoxMapMM = new Cyotek.Windows.Forms.ImageBox();
            tabPageLog = new System.Windows.Forms.TabPage();
            menuStripMain = new System.Windows.Forms.MenuStrip();
            menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clearCheckClaimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            cmsCheckList = new System.Windows.Forms.ContextMenuStrip(components);
            goToConfigScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOOTItemList).BeginInit();
            tabGameMenu.SuspendLayout();
            tabOcarinaOfTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerOotSideContent).BeginInit();
            splitContainerOotSideContent.Panel1.SuspendLayout();
            splitContainerOotSideContent.Panel2.SuspendLayout();
            splitContainerOotSideContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerOotCheckListCheckItemSeparator).BeginInit();
            splitContainerOotCheckListCheckItemSeparator.Panel1.SuspendLayout();
            splitContainerOotCheckListCheckItemSeparator.Panel2.SuspendLayout();
            splitContainerOotCheckListCheckItemSeparator.SuspendLayout();
            gbCheckListOOT.SuspendLayout();
            tabMajoraMask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMMItemList).BeginInit();
            gbCheckListMM.SuspendLayout();
            tabPageLog.SuspendLayout();
            menuStripMain.SuspendLayout();
            SuspendLayout();
            // 
            // tboxDebug
            // 
            tboxDebug.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tboxDebug.Location = new System.Drawing.Point(4, 4);
            tboxDebug.Margin = new System.Windows.Forms.Padding(4);
            tboxDebug.Multiline = true;
            tboxDebug.Name = "tboxDebug";
            tboxDebug.Size = new System.Drawing.Size(440, 615);
            tboxDebug.TabIndex = 3;
            // 
            // pictureBoxOOTItemList
            // 
            pictureBoxOOTItemList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxOOTItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBoxOOTItemList.InitialImage = null;
            pictureBoxOOTItemList.Location = new System.Drawing.Point(0, 0);
            pictureBoxOOTItemList.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxOOTItemList.Name = "pictureBoxOOTItemList";
            pictureBoxOOTItemList.Size = new System.Drawing.Size(300, 401);
            pictureBoxOOTItemList.TabIndex = 4;
            pictureBoxOOTItemList.TabStop = false;
            // 
            // lbCheckListOOT
            // 
            lbCheckListOOT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lbCheckListOOT.Dock = System.Windows.Forms.DockStyle.Fill;
            lbCheckListOOT.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            lbCheckListOOT.FormattingEnabled = true;
            lbCheckListOOT.ItemHeight = 17;
            lbCheckListOOT.Location = new System.Drawing.Point(3, 19);
            lbCheckListOOT.Margin = new System.Windows.Forms.Padding(0);
            lbCheckListOOT.Name = "lbCheckListOOT";
            lbCheckListOOT.Size = new System.Drawing.Size(294, 201);
            lbCheckListOOT.TabIndex = 67;
            // 
            // tabGameMenu
            // 
            tabGameMenu.Controls.Add(tabOcarinaOfTime);
            tabGameMenu.Controls.Add(tabMajoraMask);
            tabGameMenu.Controls.Add(tabPageLog);
            tabGameMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            tabGameMenu.Location = new System.Drawing.Point(0, 24);
            tabGameMenu.Margin = new System.Windows.Forms.Padding(0);
            tabGameMenu.Name = "tabGameMenu";
            tabGameMenu.SelectedIndex = 0;
            tabGameMenu.Size = new System.Drawing.Size(1264, 657);
            tabGameMenu.TabIndex = 70;
            // 
            // tabOcarinaOfTime
            // 
            tabOcarinaOfTime.Controls.Add(splitContainerOotSideContent);
            tabOcarinaOfTime.Location = new System.Drawing.Point(4, 25);
            tabOcarinaOfTime.Margin = new System.Windows.Forms.Padding(0);
            tabOcarinaOfTime.Name = "tabOcarinaOfTime";
            tabOcarinaOfTime.Size = new System.Drawing.Size(1256, 628);
            tabOcarinaOfTime.TabIndex = 0;
            tabOcarinaOfTime.Text = "Ocarina of time";
            tabOcarinaOfTime.UseVisualStyleBackColor = true;
            // 
            // splitContainerOotSideContent
            // 
            splitContainerOotSideContent.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainerOotSideContent.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            splitContainerOotSideContent.Location = new System.Drawing.Point(0, 0);
            splitContainerOotSideContent.Margin = new System.Windows.Forms.Padding(0);
            splitContainerOotSideContent.Name = "splitContainerOotSideContent";
            // 
            // splitContainerOotSideContent.Panel1
            // 
            splitContainerOotSideContent.Panel1.Controls.Add(splitContainerOotCheckListCheckItemSeparator);
            // 
            // splitContainerOotSideContent.Panel2
            // 
            splitContainerOotSideContent.Panel2.Controls.Add(imageBoxMapOOT);
            splitContainerOotSideContent.Size = new System.Drawing.Size(1256, 628);
            splitContainerOotSideContent.SplitterDistance = 300;
            splitContainerOotSideContent.SplitterWidth = 5;
            splitContainerOotSideContent.TabIndex = 71;
            // 
            // splitContainerOotCheckListCheckItemSeparator
            // 
            splitContainerOotCheckListCheckItemSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainerOotCheckListCheckItemSeparator.Location = new System.Drawing.Point(0, 0);
            splitContainerOotCheckListCheckItemSeparator.Margin = new System.Windows.Forms.Padding(0);
            splitContainerOotCheckListCheckItemSeparator.Name = "splitContainerOotCheckListCheckItemSeparator";
            splitContainerOotCheckListCheckItemSeparator.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerOotCheckListCheckItemSeparator.Panel1
            // 
            splitContainerOotCheckListCheckItemSeparator.Panel1.Controls.Add(pictureBoxOOTItemList);
            // 
            // splitContainerOotCheckListCheckItemSeparator.Panel2
            // 
            splitContainerOotCheckListCheckItemSeparator.Panel2.Controls.Add(gbCheckListOOT);
            splitContainerOotCheckListCheckItemSeparator.Size = new System.Drawing.Size(300, 628);
            splitContainerOotCheckListCheckItemSeparator.SplitterDistance = 401;
            splitContainerOotCheckListCheckItemSeparator.TabIndex = 0;
            // 
            // gbCheckListOOT
            // 
            gbCheckListOOT.Controls.Add(lbCheckListOOT);
            gbCheckListOOT.Dock = System.Windows.Forms.DockStyle.Fill;
            gbCheckListOOT.Location = new System.Drawing.Point(0, 0);
            gbCheckListOOT.Name = "gbCheckListOOT";
            gbCheckListOOT.Size = new System.Drawing.Size(300, 223);
            gbCheckListOOT.TabIndex = 68;
            gbCheckListOOT.TabStop = false;
            gbCheckListOOT.Text = "Zone";
            // 
            // imageBoxMapOOT
            // 
            imageBoxMapOOT.Dock = System.Windows.Forms.DockStyle.Fill;
            imageBoxMapOOT.Location = new System.Drawing.Point(0, 0);
            imageBoxMapOOT.Margin = new System.Windows.Forms.Padding(0);
            imageBoxMapOOT.Name = "imageBoxMapOOT";
            imageBoxMapOOT.Size = new System.Drawing.Size(951, 628);
            imageBoxMapOOT.TabIndex = 0;
            // 
            // tabMajoraMask
            // 
            tabMajoraMask.Controls.Add(splitContainer1);
            tabMajoraMask.Location = new System.Drawing.Point(4, 24);
            tabMajoraMask.Margin = new System.Windows.Forms.Padding(0);
            tabMajoraMask.Name = "tabMajoraMask";
            tabMajoraMask.Size = new System.Drawing.Size(1256, 629);
            tabMajoraMask.TabIndex = 1;
            tabMajoraMask.Text = "Majora mask";
            tabMajoraMask.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(imageBoxMapMM);
            splitContainer1.Size = new System.Drawing.Size(1256, 629);
            splitContainer1.SplitterDistance = 300;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 70;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer2.Location = new System.Drawing.Point(0, 0);
            splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(pictureBoxMMItemList);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(gbCheckListMM);
            splitContainer2.Size = new System.Drawing.Size(300, 629);
            splitContainer2.SplitterDistance = 401;
            splitContainer2.TabIndex = 0;
            // 
            // pictureBoxMMItemList
            // 
            pictureBoxMMItemList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxMMItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBoxMMItemList.InitialImage = null;
            pictureBoxMMItemList.Location = new System.Drawing.Point(0, 0);
            pictureBoxMMItemList.Margin = new System.Windows.Forms.Padding(0);
            pictureBoxMMItemList.Name = "pictureBoxMMItemList";
            pictureBoxMMItemList.Size = new System.Drawing.Size(300, 401);
            pictureBoxMMItemList.TabIndex = 5;
            pictureBoxMMItemList.TabStop = false;
            // 
            // gbCheckListMM
            // 
            gbCheckListMM.Controls.Add(lbCheckListMM);
            gbCheckListMM.Dock = System.Windows.Forms.DockStyle.Fill;
            gbCheckListMM.Location = new System.Drawing.Point(0, 0);
            gbCheckListMM.Name = "gbCheckListMM";
            gbCheckListMM.Size = new System.Drawing.Size(300, 224);
            gbCheckListMM.TabIndex = 69;
            gbCheckListMM.TabStop = false;
            gbCheckListMM.Text = "Zone";
            // 
            // lbCheckListMM
            // 
            lbCheckListMM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lbCheckListMM.Dock = System.Windows.Forms.DockStyle.Fill;
            lbCheckListMM.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            lbCheckListMM.FormattingEnabled = true;
            lbCheckListMM.ItemHeight = 17;
            lbCheckListMM.Location = new System.Drawing.Point(3, 19);
            lbCheckListMM.Margin = new System.Windows.Forms.Padding(0);
            lbCheckListMM.Name = "lbCheckListMM";
            lbCheckListMM.Size = new System.Drawing.Size(294, 202);
            lbCheckListMM.TabIndex = 68;
            // 
            // imageBoxMapMM
            // 
            imageBoxMapMM.Dock = System.Windows.Forms.DockStyle.Fill;
            imageBoxMapMM.Location = new System.Drawing.Point(0, 0);
            imageBoxMapMM.Name = "imageBoxMapMM";
            imageBoxMapMM.Size = new System.Drawing.Size(951, 629);
            imageBoxMapMM.TabIndex = 0;
            // 
            // tabPageLog
            // 
            tabPageLog.Controls.Add(tboxDebug);
            tabPageLog.Location = new System.Drawing.Point(4, 24);
            tabPageLog.Name = "tabPageLog";
            tabPageLog.Size = new System.Drawing.Size(1256, 629);
            tabPageLog.TabIndex = 2;
            tabPageLog.Text = "Log";
            tabPageLog.UseVisualStyleBackColor = true;
            // 
            // menuStripMain
            // 
            menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { menuToolStripMenuItem });
            menuStripMain.Location = new System.Drawing.Point(0, 0);
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Size = new System.Drawing.Size(1264, 24);
            menuStripMain.TabIndex = 79;
            menuStripMain.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { clearCheckClaimToolStripMenuItem, saveToFileToolStripMenuItem, goToConfigScreenToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            menuToolStripMenuItem.Text = "File";
            // 
            // clearCheckClaimToolStripMenuItem
            // 
            clearCheckClaimToolStripMenuItem.Name = "clearCheckClaimToolStripMenuItem";
            clearCheckClaimToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            clearCheckClaimToolStripMenuItem.Text = "Reset check claim";
            clearCheckClaimToolStripMenuItem.Click += OnResetCheckClaimClick;
            // 
            // saveToFileToolStripMenuItem
            // 
            saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            saveToFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            saveToFileToolStripMenuItem.Text = "Save to file";
            saveToFileToolStripMenuItem.Click += saveToFileToolStripMenuItem_Click;
            // 
            // cmsCheckList
            // 
            cmsCheckList.Name = "cmsCheckMenu";
            cmsCheckList.Size = new System.Drawing.Size(61, 4);
            // 
            // goToConfigScreenToolStripMenuItem
            // 
            goToConfigScreenToolStripMenuItem.Name = "goToConfigScreenToolStripMenuItem";
            goToConfigScreenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            goToConfigScreenToolStripMenuItem.Text = "Go to config screen";
            goToConfigScreenToolStripMenuItem.Click += goToConfigScreenToolStripMenuItem_Click;
            // 
            // MainUIForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1264, 681);
            Controls.Add(tabGameMenu);
            Controls.Add(menuStripMain);
            DoubleBuffered = true;
            Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStripMain;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "MainUIForm";
            Text = "Ocarin Of Time And Majora Mask Auto Tracker By Rukko";
            FormClosing += OnFormClosing;
            Load += OnMainUiFormLoad;
            ((System.ComponentModel.ISupportInitialize)pictureBoxOOTItemList).EndInit();
            tabGameMenu.ResumeLayout(false);
            tabOcarinaOfTime.ResumeLayout(false);
            splitContainerOotSideContent.Panel1.ResumeLayout(false);
            splitContainerOotSideContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerOotSideContent).EndInit();
            splitContainerOotSideContent.ResumeLayout(false);
            splitContainerOotCheckListCheckItemSeparator.Panel1.ResumeLayout(false);
            splitContainerOotCheckListCheckItemSeparator.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerOotCheckListCheckItemSeparator).EndInit();
            splitContainerOotCheckListCheckItemSeparator.ResumeLayout(false);
            gbCheckListOOT.ResumeLayout(false);
            tabMajoraMask.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxMMItemList).EndInit();
            gbCheckListMM.ResumeLayout(false);
            tabPageLog.ResumeLayout(false);
            tabPageLog.PerformLayout();
            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox tboxDebug;
        private System.Windows.Forms.PictureBox pictureBoxOOTItemList;
        private System.Windows.Forms.ListBox lbCheckListOOT;
        private System.Windows.Forms.TabControl tabGameMenu;
        private System.Windows.Forms.TabPage tabOcarinaOfTime;
        private System.Windows.Forms.TabPage tabMajoraMask;
        private System.Windows.Forms.ListBox lbCheckListMM;
        private System.Windows.Forms.PictureBox pictureBoxMMItemList;
        private System.Windows.Forms.SplitContainer splitContainerOotSideContent;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.SplitContainer splitContainerOotCheckListCheckItemSeparator;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem clearCheckClaimToolStripMenuItem;
        private Cyotek.Windows.Forms.ImageBox imageBoxMapOOT;
        private Cyotek.Windows.Forms.ImageBox imageBoxMapMM;
        private System.Windows.Forms.GroupBox gbCheckListOOT;
        private System.Windows.Forms.GroupBox gbCheckListMM;
        private System.Windows.Forms.ContextMenuStrip cmsCheckList;
        private System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToConfigScreenToolStripMenuItem;
    }
}

