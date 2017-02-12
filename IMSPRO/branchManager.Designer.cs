namespace IMSPRO
{
    partial class branchManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(branchManager));
            this.grdBranchNames = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_branchName = new System.Windows.Forms.TextBox();
            this.btn_addBranch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdBranchNames)).BeginInit();
            this.SuspendLayout();
            // 
            // grdBranchNames
            // 
            this.grdBranchNames.AllowUserToAddRows = false;
            this.grdBranchNames.AllowUserToDeleteRows = false;
            this.grdBranchNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBranchNames.Location = new System.Drawing.Point(30, 97);
            this.grdBranchNames.Name = "grdBranchNames";
            this.grdBranchNames.ReadOnly = true;
            this.grdBranchNames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdBranchNames.Size = new System.Drawing.Size(472, 252);
            this.grdBranchNames.TabIndex = 0;
            this.grdBranchNames.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdBranchNames_KeyDown);
            this.grdBranchNames.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdBranchNames_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter New Branch Name:";
            // 
            // txt_branchName
            // 
            this.txt_branchName.Location = new System.Drawing.Point(162, 61);
            this.txt_branchName.Name = "txt_branchName";
            this.txt_branchName.Size = new System.Drawing.Size(252, 20);
            this.txt_branchName.TabIndex = 2;
            // 
            // btn_addBranch
            // 
            this.btn_addBranch.Location = new System.Drawing.Point(421, 60);
            this.btn_addBranch.Name = "btn_addBranch";
            this.btn_addBranch.Size = new System.Drawing.Size(75, 23);
            this.btn_addBranch.TabIndex = 3;
            this.btn_addBranch.Text = "Add";
            this.btn_addBranch.UseVisualStyleBackColor = true;
            this.btn_addBranch.Click += new System.EventHandler(this.btn_addBranch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 341);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Branch Management";
            // 
            // branchManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 377);
            this.Controls.Add(this.btn_addBranch);
            this.Controls.Add(this.txt_branchName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdBranchNames);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "branchManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Branch Manager";
            ((System.ComponentModel.ISupportInitialize)(this.grdBranchNames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdBranchNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_branchName;
        private System.Windows.Forms.Button btn_addBranch;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}