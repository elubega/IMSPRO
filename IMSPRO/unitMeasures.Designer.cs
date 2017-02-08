namespace IMSPRO
{
    partial class unitMeasures
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(unitMeasures));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_untiMeasure = new System.Windows.Forms.TextBox();
            this.grd_UnitMeasures = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_measure = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grd_UnitMeasures)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unit Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_untiMeasure
            // 
            this.txt_untiMeasure.Location = new System.Drawing.Point(96, 33);
            this.txt_untiMeasure.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_untiMeasure.Name = "txt_untiMeasure";
            this.txt_untiMeasure.Size = new System.Drawing.Size(254, 23);
            this.txt_untiMeasure.TabIndex = 1;
            // 
            // grd_UnitMeasures
            // 
            this.grd_UnitMeasures.AllowUserToAddRows = false;
            this.grd_UnitMeasures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_UnitMeasures.Location = new System.Drawing.Point(12, 66);
            this.grd_UnitMeasures.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grd_UnitMeasures.Name = "grd_UnitMeasures";
            this.grd_UnitMeasures.RowTemplate.Height = 24;
            this.grd_UnitMeasures.Size = new System.Drawing.Size(415, 212);
            this.grd_UnitMeasures.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_measure);
            this.groupBox1.Controls.Add(this.txt_untiMeasure);
            this.groupBox1.Controls.Add(this.grd_UnitMeasures);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(22, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(439, 292);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unit Measure Management";
            // 
            // btn_measure
            // 
            this.btn_measure.ForeColor = System.Drawing.Color.Black;
            this.btn_measure.Location = new System.Drawing.Point(354, 28);
            this.btn_measure.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_measure.Name = "btn_measure";
            this.btn_measure.Size = new System.Drawing.Size(73, 33);
            this.btn_measure.TabIndex = 3;
            this.btn_measure.Text = "Add";
            this.btn_measure.UseVisualStyleBackColor = true;
            this.btn_measure.Click += new System.EventHandler(this.btn_measure_Click);
            // 
            // unitMeasures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 338);
            this.Controls.Add(this.groupBox1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "unitMeasures";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unit Measures";
            ((System.ComponentModel.ISupportInitialize)(this.grd_UnitMeasures)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_untiMeasure;
        private System.Windows.Forms.DataGridView grd_UnitMeasures;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_measure;
    }
}