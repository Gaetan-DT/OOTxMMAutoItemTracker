
namespace MajoraAutoItemTracker.UI.LogicTester
{
    partial class LogicTester
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
            this.btnLoadLogic = new System.Windows.Forms.Button();
            this.btnLoadCheck = new System.Windows.Forms.Button();
            this.BtnLoadItem = new System.Windows.Forms.Button();
            this.BtnResolve = new System.Windows.Forms.Button();
            this.textOutput = new System.Windows.Forms.TextBox();
            this.labelOutput = new System.Windows.Forms.Label();
            this.chkAllowTrick = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnLoadLogic
            // 
            this.btnLoadLogic.Location = new System.Drawing.Point(12, 12);
            this.btnLoadLogic.Name = "btnLoadLogic";
            this.btnLoadLogic.Size = new System.Drawing.Size(75, 23);
            this.btnLoadLogic.TabIndex = 0;
            this.btnLoadLogic.Text = "Load logic";
            this.btnLoadLogic.UseVisualStyleBackColor = true;
            this.btnLoadLogic.Click += new System.EventHandler(this.btnLoadLogic_Click);
            // 
            // btnLoadCheck
            // 
            this.btnLoadCheck.Location = new System.Drawing.Point(12, 41);
            this.btnLoadCheck.Name = "btnLoadCheck";
            this.btnLoadCheck.Size = new System.Drawing.Size(75, 23);
            this.btnLoadCheck.TabIndex = 1;
            this.btnLoadCheck.Text = "Load check";
            this.btnLoadCheck.UseVisualStyleBackColor = true;
            this.btnLoadCheck.Click += new System.EventHandler(this.btnLoadCheck_Click);
            // 
            // BtnLoadItem
            // 
            this.BtnLoadItem.Location = new System.Drawing.Point(12, 70);
            this.BtnLoadItem.Name = "BtnLoadItem";
            this.BtnLoadItem.Size = new System.Drawing.Size(75, 23);
            this.BtnLoadItem.TabIndex = 2;
            this.BtnLoadItem.Text = "Load Item list";
            this.BtnLoadItem.UseVisualStyleBackColor = true;
            this.BtnLoadItem.Click += new System.EventHandler(this.BtnLoadItem_Click);
            // 
            // BtnResolve
            // 
            this.BtnResolve.Location = new System.Drawing.Point(12, 99);
            this.BtnResolve.Name = "BtnResolve";
            this.BtnResolve.Size = new System.Drawing.Size(75, 23);
            this.BtnResolve.TabIndex = 3;
            this.BtnResolve.Text = "Resolve";
            this.BtnResolve.UseVisualStyleBackColor = true;
            this.BtnResolve.Click += new System.EventHandler(this.BtnResolve_Click);
            // 
            // textOutput
            // 
            this.textOutput.Location = new System.Drawing.Point(93, 29);
            this.textOutput.Multiline = true;
            this.textOutput.Name = "textOutput";
            this.textOutput.ReadOnly = true;
            this.textOutput.Size = new System.Drawing.Size(695, 409);
            this.textOutput.TabIndex = 4;
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(94, 12);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(39, 13);
            this.labelOutput.TabIndex = 5;
            this.labelOutput.Text = "Output";
            // 
            // chkAllowTrick
            // 
            this.chkAllowTrick.AutoSize = true;
            this.chkAllowTrick.Location = new System.Drawing.Point(12, 129);
            this.chkAllowTrick.Name = "chkAllowTrick";
            this.chkAllowTrick.Size = new System.Drawing.Size(74, 17);
            this.chkAllowTrick.TabIndex = 6;
            this.chkAllowTrick.Text = "Allow trick";
            this.chkAllowTrick.UseVisualStyleBackColor = true;
            // 
            // LogicTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chkAllowTrick);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.textOutput);
            this.Controls.Add(this.BtnResolve);
            this.Controls.Add(this.BtnLoadItem);
            this.Controls.Add(this.btnLoadCheck);
            this.Controls.Add(this.btnLoadLogic);
            this.Name = "LogicTester";
            this.Text = "LogicTester";
            this.Load += new System.EventHandler(this.LogicTester_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadLogic;
        private System.Windows.Forms.Button btnLoadCheck;
        private System.Windows.Forms.Button BtnLoadItem;
        private System.Windows.Forms.Button BtnResolve;
        private System.Windows.Forms.TextBox textOutput;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.CheckBox chkAllowTrick;
    }
}