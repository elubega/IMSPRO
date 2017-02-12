namespace IMSPRO
{
    partial class editUnitMeasure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editUnitMeasure));
            this.btn_saveUnitMeasure = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_UnitMeasure = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // btn_saveUnitMeasure
            // 
            this.btn_saveUnitMeasure.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_saveUnitMeasure.Location = new System.Drawing.Point(240, 101);
            this.btn_saveUnitMeasure.Name = "btn_saveUnitMeasure";
            this.btn_saveUnitMeasure.Size = new System.Drawing.Size(75, 23);
            this.btn_saveUnitMeasure.TabIndex = 0;
            this.btn_saveUnitMeasure.Text = "Save";
            this.btn_saveUnitMeasure.UseVisualStyleBackColor = true;
            this.btn_saveUnitMeasure.Click += new System.EventHandler(this.btn_saveUnitMeasure_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unit Name:";
            // 
            // txt_UnitMeasure
            // 
            this.txt_UnitMeasure.Location = new System.Drawing.Point(109, 56);
            this.txt_UnitMeasure.Name = "txt_UnitMeasure";
            this.txt_UnitMeasure.Size = new System.Drawing.Size(206, 20);
            this.txt_UnitMeasure.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 128);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit Unit Measure";
            // 
            // editUnitMeasure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 155);
            this.Controls.Add(this.txt_UnitMeasure);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_saveUnitMeasure);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "editUnitMeasure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Unit Measure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_saveUnitMeasure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_UnitMeasure;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}