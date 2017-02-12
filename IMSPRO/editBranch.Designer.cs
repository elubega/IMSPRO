namespace IMSPRO
{
    partial class editBranch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editBranch));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_BranchName = new System.Windows.Forms.TextBox();
            this.btn_saveBranch = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_saveBranch);
            this.groupBox1.Controls.Add(this.txt_BranchName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit Branch Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Branch Name:";
            // 
            // txt_BranchName
            // 
            this.txt_BranchName.Location = new System.Drawing.Point(89, 39);
            this.txt_BranchName.Name = "txt_BranchName";
            this.txt_BranchName.Size = new System.Drawing.Size(231, 20);
            this.txt_BranchName.TabIndex = 1;
            // 
            // btn_saveBranch
            // 
            this.btn_saveBranch.Location = new System.Drawing.Point(239, 66);
            this.btn_saveBranch.Name = "btn_saveBranch";
            this.btn_saveBranch.Size = new System.Drawing.Size(81, 23);
            this.btn_saveBranch.TabIndex = 2;
            this.btn_saveBranch.Text = "Save";
            this.btn_saveBranch.UseVisualStyleBackColor = true;
            this.btn_saveBranch.Click += new System.EventHandler(this.btn_saveBranch_Click);
            // 
            // editBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 131);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "editBranch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Branch";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_saveBranch;
        private System.Windows.Forms.TextBox txt_BranchName;
        private System.Windows.Forms.Label label1;
    }
}