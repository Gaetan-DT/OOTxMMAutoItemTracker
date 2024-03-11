
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
            this.btnLoadFromCategory = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textCheckId = new System.Windows.Forms.TextBox();
            this.textCheckSquareX = new System.Windows.Forms.TextBox();
            this.textCheckIsAvailable = new System.Windows.Forms.TextBox();
            this.textCheckIsClaim = new System.Windows.Forms.TextBox();
            this.textCheckSquareY = new System.Windows.Forms.TextBox();
            this.textCheckZone = new System.Windows.Forms.TextBox();
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
            this.btnLoadCheck.Location = new System.Drawing.Point(672, 14);
            this.btnLoadCheck.Name = "btnLoadCheck";
            this.btnLoadCheck.Size = new System.Drawing.Size(116, 23);
            this.btnLoadCheck.TabIndex = 2;
            this.btnLoadCheck.Text = "Open check file";
            this.btnLoadCheck.UseVisualStyleBackColor = true;
            this.btnLoadCheck.Click += new System.EventHandler(this.btnLoadCheck_Click);
            // 
            // btnSaveCheck
            // 
            this.btnSaveCheck.Location = new System.Drawing.Point(672, 43);
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
            this.lbLogic.Location = new System.Drawing.Point(15, 72);
            this.lbLogic.Name = "lbLogic";
            this.lbLogic.Size = new System.Drawing.Size(364, 368);
            this.lbLogic.TabIndex = 4;
            this.lbLogic.DoubleClick += new System.EventHandler(this.lbLogic_DoubleClick);
            // 
            // lbCheck
            // 
            this.lbCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCheck.FormattingEnabled = true;
            this.lbCheck.Location = new System.Drawing.Point(451, 72);
            this.lbCheck.Name = "lbCheck";
            this.lbCheck.Size = new System.Drawing.Size(337, 264);
            this.lbCheck.TabIndex = 5;
            this.lbCheck.SelectedIndexChanged += new System.EventHandler(this.lbCheck_SelectedIndexChanged);
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
            this.textLogicFilter.Location = new System.Drawing.Point(15, 33);
            this.textLogicFilter.Name = "textLogicFilter";
            this.textLogicFilter.Size = new System.Drawing.Size(364, 20);
            this.textLogicFilter.TabIndex = 7;
            this.textLogicFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // btnLoadFromCategory
            // 
            this.btnLoadFromCategory.Location = new System.Drawing.Point(540, 14);
            this.btnLoadFromCategory.Name = "btnLoadFromCategory";
            this.btnLoadFromCategory.Size = new System.Drawing.Size(116, 23);
            this.btnLoadFromCategory.TabIndex = 8;
            this.btnLoadFromCategory.Text = "Load from category";
            this.btnLoadFromCategory.UseVisualStyleBackColor = true;
            this.btnLoadFromCategory.Click += new System.EventHandler(this.btnLoadFromCategory_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(492, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(476, 371);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Zone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(457, 397);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Square X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(631, 401);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Square Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(448, 427);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Is available";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(640, 427);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Is claim";
            // 
            // textCheckId
            // 
            this.textCheckId.Location = new System.Drawing.Point(514, 342);
            this.textCheckId.Name = "textCheckId";
            this.textCheckId.Size = new System.Drawing.Size(274, 20);
            this.textCheckId.TabIndex = 15;
            // 
            // textCheckSquareX
            // 
            this.textCheckSquareX.Location = new System.Drawing.Point(514, 394);
            this.textCheckSquareX.Name = "textCheckSquareX";
            this.textCheckSquareX.Size = new System.Drawing.Size(100, 20);
            this.textCheckSquareX.TabIndex = 16;
            // 
            // textCheckIsAvailable
            // 
            this.textCheckIsAvailable.Location = new System.Drawing.Point(514, 420);
            this.textCheckIsAvailable.Name = "textCheckIsAvailable";
            this.textCheckIsAvailable.Size = new System.Drawing.Size(100, 20);
            this.textCheckIsAvailable.TabIndex = 17;
            // 
            // textCheckIsClaim
            // 
            this.textCheckIsClaim.Location = new System.Drawing.Point(688, 420);
            this.textCheckIsClaim.Name = "textCheckIsClaim";
            this.textCheckIsClaim.Size = new System.Drawing.Size(100, 20);
            this.textCheckIsClaim.TabIndex = 18;
            // 
            // textCheckSquareY
            // 
            this.textCheckSquareY.Location = new System.Drawing.Point(688, 394);
            this.textCheckSquareY.Name = "textCheckSquareY";
            this.textCheckSquareY.Size = new System.Drawing.Size(100, 20);
            this.textCheckSquareY.TabIndex = 19;
            // 
            // textCheckZone
            // 
            this.textCheckZone.Location = new System.Drawing.Point(514, 368);
            this.textCheckZone.Name = "textCheckZone";
            this.textCheckZone.Size = new System.Drawing.Size(274, 20);
            this.textCheckZone.TabIndex = 20;
            // 
            // CheckLogicEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textCheckZone);
            this.Controls.Add(this.textCheckSquareY);
            this.Controls.Add(this.textCheckIsClaim);
            this.Controls.Add(this.textCheckIsAvailable);
            this.Controls.Add(this.textCheckSquareX);
            this.Controls.Add(this.textCheckId);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLoadFromCategory);
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
        private System.Windows.Forms.Button btnLoadFromCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textCheckId;
        private System.Windows.Forms.TextBox textCheckSquareX;
        private System.Windows.Forms.TextBox textCheckIsAvailable;
        private System.Windows.Forms.TextBox textCheckIsClaim;
        private System.Windows.Forms.TextBox textCheckSquareY;
        private System.Windows.Forms.TextBox textCheckZone;
    }
}