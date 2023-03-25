
namespace MajoraAutoItemTracker.UI.CheckLogicEditor
{
    partial class CheckLogicEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadCheck = new System.Windows.Forms.Button();
            this.btnSaveCheck = new System.Windows.Forms.Button();
            this.lbLogic = new System.Windows.Forms.ListBox();
            this.lbCheck = new System.Windows.Forms.ListBox();
            this.lbLogicVerion = new System.Windows.Forms.Label();
            this.textLogicFilter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Logic file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(448, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Check file";
            // 
            // btnLoadCheck
            // 
            this.btnLoadCheck.Location = new System.Drawing.Point(550, 12);
            this.btnLoadCheck.Name = "btnLoadCheck";
            this.btnLoadCheck.Size = new System.Drawing.Size(116, 23);
            this.btnLoadCheck.TabIndex = 2;
            this.btnLoadCheck.Text = "Open check file";
            this.btnLoadCheck.UseVisualStyleBackColor = true;
            this.btnLoadCheck.Click += new System.EventHandler(this.btnLoadCheck_Click);
            // 
            // btnSaveCheck
            // 
            this.btnSaveCheck.Location = new System.Drawing.Point(672, 12);
            this.btnSaveCheck.Name = "btnSaveCheck";
            this.btnSaveCheck.Size = new System.Drawing.Size(116, 23);
            this.btnSaveCheck.TabIndex = 3;
            this.btnSaveCheck.Text = "Save check file";
            this.btnSaveCheck.UseVisualStyleBackColor = true;
            this.btnSaveCheck.Click += new System.EventHandler(this.btnSaveCheck_Click);
            // 
            // lbLogic
            // 
            this.lbLogic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbLogic.FormattingEnabled = true;
            this.lbLogic.Location = new System.Drawing.Point(15, 33);
            this.lbLogic.Name = "lbLogic";
            this.lbLogic.Size = new System.Drawing.Size(364, 407);
            this.lbLogic.TabIndex = 4;
            this.lbLogic.DoubleClick += new System.EventHandler(this.lbLogic_DoubleClick);
            // 
            // lbCheck
            // 
            this.lbCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCheck.FormattingEnabled = true;
            this.lbCheck.Location = new System.Drawing.Point(451, 33);
            this.lbCheck.Name = "lbCheck";
            this.lbCheck.Size = new System.Drawing.Size(337, 407);
            this.lbCheck.TabIndex = 5;
            this.lbCheck.DoubleClick += new System.EventHandler(this.lbLogic_DoubleClick);
            // 
            // lbLogicVerion
            // 
            this.lbLogicVerion.AutoSize = true;
            this.lbLogicVerion.Location = new System.Drawing.Point(76, 17);
            this.lbLogicVerion.Name = "lbLogicVerion";
            this.lbLogicVerion.Size = new System.Drawing.Size(49, 13);
            this.lbLogicVerion.TabIndex = 6;
            this.lbLogicVerion.Text = "Logic file";
            // 
            // textLogicFilter
            // 
            this.textLogicFilter.Location = new System.Drawing.Point(183, 13);
            this.textLogicFilter.Name = "textLogicFilter";
            this.textLogicFilter.Size = new System.Drawing.Size(196, 20);
            this.textLogicFilter.TabIndex = 7;
            this.textLogicFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // CheckLogicEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textLogicFilter);
            this.Controls.Add(this.lbLogicVerion);
            this.Controls.Add(this.lbCheck);
            this.Controls.Add(this.lbLogic);
            this.Controls.Add(this.btnSaveCheck);
            this.Controls.Add(this.btnLoadCheck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CheckLogicEditor";
            this.Text = "CheckLogicEditor";
            this.Load += new System.EventHandler(this.CheckLogicEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadCheck;
        private System.Windows.Forms.Button btnSaveCheck;
        private System.Windows.Forms.ListBox lbLogic;
        private System.Windows.Forms.ListBox lbCheck;
        private System.Windows.Forms.Label lbLogicVerion;
        private System.Windows.Forms.TextBox textLogicFilter;
    }
}