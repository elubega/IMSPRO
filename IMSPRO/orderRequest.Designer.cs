namespace IMSPRO
{
    partial class orderRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(orderRequest));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbm_orderedBy = new System.Windows.Forms.ComboBox();
            this.cbm_branchName = new System.Windows.Forms.ComboBox();
            this.txt_dateOrdered = new System.Windows.Forms.TextBox();
            this.txt_orderNo = new System.Windows.Forms.TextBox();
            this.grdOrderForm = new System.Windows.Forms.DataGridView();
            this.txt_barCode = new System.Windows.Forms.TextBox();
            this.txt_productName = new System.Windows.Forms.TextBox();
            this.txt_qty = new System.Windows.Forms.TextBox();
            this.cbm_unitMeasure = new System.Windows.Forms.ComboBox();
            this.btn_addOrder = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderForm)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(295, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order Request Form";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_orderNo);
            this.groupBox1.Controls.Add(this.txt_dateOrdered);
            this.groupBox1.Controls.Add(this.cbm_branchName);
            this.groupBox1.Controls.Add(this.cbm_orderedBy);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 231);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Order No.:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Date Ordered:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Branch:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ordered By:";
            // 
            // cbm_orderedBy
            // 
            this.cbm_orderedBy.FormattingEnabled = true;
            this.cbm_orderedBy.Location = new System.Drawing.Point(104, 125);
            this.cbm_orderedBy.Name = "cbm_orderedBy";
            this.cbm_orderedBy.Size = new System.Drawing.Size(152, 21);
            this.cbm_orderedBy.TabIndex = 4;
            // 
            // cbm_branchName
            // 
            this.cbm_branchName.FormattingEnabled = true;
            this.cbm_branchName.Location = new System.Drawing.Point(104, 93);
            this.cbm_branchName.Name = "cbm_branchName";
            this.cbm_branchName.Size = new System.Drawing.Size(152, 21);
            this.cbm_branchName.TabIndex = 5;
            // 
            // txt_dateOrdered
            // 
            this.txt_dateOrdered.Enabled = false;
            this.txt_dateOrdered.Location = new System.Drawing.Point(104, 67);
            this.txt_dateOrdered.Name = "txt_dateOrdered";
            this.txt_dateOrdered.Size = new System.Drawing.Size(152, 20);
            this.txt_dateOrdered.TabIndex = 6;
            // 
            // txt_orderNo
            // 
            this.txt_orderNo.Enabled = false;
            this.txt_orderNo.Location = new System.Drawing.Point(104, 37);
            this.txt_orderNo.Name = "txt_orderNo";
            this.txt_orderNo.Size = new System.Drawing.Size(121, 20);
            this.txt_orderNo.TabIndex = 7;
            // 
            // grdOrderForm
            // 
            this.grdOrderForm.AllowUserToAddRows = false;
            this.grdOrderForm.AllowUserToDeleteRows = false;
            this.grdOrderForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdOrderForm.Location = new System.Drawing.Point(328, 121);
            this.grdOrderForm.Name = "grdOrderForm";
            this.grdOrderForm.ReadOnly = true;
            this.grdOrderForm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdOrderForm.Size = new System.Drawing.Size(803, 191);
            this.grdOrderForm.TabIndex = 2;
            // 
            // txt_barCode
            // 
            this.txt_barCode.Location = new System.Drawing.Point(328, 95);
            this.txt_barCode.Name = "txt_barCode";
            this.txt_barCode.Size = new System.Drawing.Size(166, 20);
            this.txt_barCode.TabIndex = 3;
            // 
            // txt_productName
            // 
            this.txt_productName.Location = new System.Drawing.Point(501, 95);
            this.txt_productName.Name = "txt_productName";
            this.txt_productName.Size = new System.Drawing.Size(285, 20);
            this.txt_productName.TabIndex = 4;
            // 
            // txt_qty
            // 
            this.txt_qty.Location = new System.Drawing.Point(793, 95);
            this.txt_qty.Name = "txt_qty";
            this.txt_qty.Size = new System.Drawing.Size(69, 20);
            this.txt_qty.TabIndex = 5;
            // 
            // cbm_unitMeasure
            // 
            this.cbm_unitMeasure.FormattingEnabled = true;
            this.cbm_unitMeasure.Location = new System.Drawing.Point(869, 95);
            this.cbm_unitMeasure.Name = "cbm_unitMeasure";
            this.cbm_unitMeasure.Size = new System.Drawing.Size(142, 21);
            this.cbm_unitMeasure.TabIndex = 6;
            // 
            // btn_addOrder
            // 
            this.btn_addOrder.Location = new System.Drawing.Point(1018, 95);
            this.btn_addOrder.Name = "btn_addOrder";
            this.btn_addOrder.Size = new System.Drawing.Size(113, 23);
            this.btn_addOrder.TabIndex = 7;
            this.btn_addOrder.Text = "Add";
            this.btn_addOrder.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Barcode:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(501, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Product Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(793, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Qty:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(869, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Unit Measure";
            // 
            // orderRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 401);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_addOrder);
            this.Controls.Add(this.cbm_unitMeasure);
            this.Controls.Add(this.txt_qty);
            this.Controls.Add(this.txt_productName);
            this.Controls.Add(this.txt_barCode);
            this.Controls.Add(this.grdOrderForm);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "orderRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Request";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_orderNo;
        private System.Windows.Forms.TextBox txt_dateOrdered;
        private System.Windows.Forms.ComboBox cbm_branchName;
        private System.Windows.Forms.ComboBox cbm_orderedBy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdOrderForm;
        private System.Windows.Forms.TextBox txt_barCode;
        private System.Windows.Forms.TextBox txt_productName;
        private System.Windows.Forms.TextBox txt_qty;
        private System.Windows.Forms.ComboBox cbm_unitMeasure;
        private System.Windows.Forms.Button btn_addOrder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}