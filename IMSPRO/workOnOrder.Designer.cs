﻿namespace IMSPRO
{
    partial class workOnOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(workOnOrder));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdProcessOrder = new System.Windows.Forms.DataGridView();
            this.btn_processOrder = new System.Windows.Forms.Button();
            this.btn_cancelOrder = new System.Windows.Forms.Button();
            this.lbl_OrderNo = new System.Windows.Forms.Label();
            this.lbl_orderNumber = new System.Windows.Forms.Label();
            this.txt_orderedBy = new System.Windows.Forms.TextBox();
            this.txt_Branch = new System.Windows.Forms.TextBox();
            this.txt_dateOrdered = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_OrderNumber = new System.Windows.Forms.TextBox();
            this.cbm_deliveredBy = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProcessOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbm_deliveredBy);
            this.groupBox1.Controls.Add(this.txt_OrderNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_dateOrdered);
            this.groupBox1.Controls.Add(this.txt_Branch);
            this.groupBox1.Controls.Add(this.txt_orderedBy);
            this.groupBox1.Controls.Add(this.lbl_orderNumber);
            this.groupBox1.Controls.Add(this.lbl_OrderNo);
            this.groupBox1.Controls.Add(this.btn_cancelOrder);
            this.groupBox1.Controls.Add(this.btn_processOrder);
            this.groupBox1.Controls.Add(this.grdProcessOrder);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1125, 501);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Details";
            // 
            // grdProcessOrder
            // 
            this.grdProcessOrder.AllowUserToAddRows = false;
            this.grdProcessOrder.AllowUserToDeleteRows = false;
            this.grdProcessOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProcessOrder.Location = new System.Drawing.Point(358, 96);
            this.grdProcessOrder.Name = "grdProcessOrder";
            this.grdProcessOrder.ReadOnly = true;
            this.grdProcessOrder.RowTemplate.Height = 24;
            this.grdProcessOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdProcessOrder.Size = new System.Drawing.Size(746, 345);
            this.grdProcessOrder.TabIndex = 0;
            this.grdProcessOrder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdProcessOrder_CellContentClick);
            // 
            // btn_processOrder
            // 
            this.btn_processOrder.Location = new System.Drawing.Point(869, 457);
            this.btn_processOrder.Name = "btn_processOrder";
            this.btn_processOrder.Size = new System.Drawing.Size(121, 35);
            this.btn_processOrder.TabIndex = 1;
            this.btn_processOrder.Text = "Confrim Order";
            this.btn_processOrder.UseVisualStyleBackColor = true;
            this.btn_processOrder.Click += new System.EventHandler(this.btn_processOrder_Click);
            // 
            // btn_cancelOrder
            // 
            this.btn_cancelOrder.Location = new System.Drawing.Point(994, 457);
            this.btn_cancelOrder.Name = "btn_cancelOrder";
            this.btn_cancelOrder.Size = new System.Drawing.Size(109, 35);
            this.btn_cancelOrder.TabIndex = 2;
            this.btn_cancelOrder.Text = "Cancel Order";
            this.btn_cancelOrder.UseVisualStyleBackColor = true;
            // 
            // lbl_OrderNo
            // 
            this.lbl_OrderNo.AutoSize = true;
            this.lbl_OrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OrderNo.Location = new System.Drawing.Point(31, 174);
            this.lbl_OrderNo.Name = "lbl_OrderNo";
            this.lbl_OrderNo.Size = new System.Drawing.Size(98, 17);
            this.lbl_OrderNo.TabIndex = 3;
            this.lbl_OrderNo.Text = "Working On:";
            // 
            // lbl_orderNumber
            // 
            this.lbl_orderNumber.AutoSize = true;
            this.lbl_orderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_orderNumber.ForeColor = System.Drawing.Color.Red;
            this.lbl_orderNumber.Location = new System.Drawing.Point(471, 35);
            this.lbl_orderNumber.Name = "lbl_orderNumber";
            this.lbl_orderNumber.Size = new System.Drawing.Size(304, 29);
            this.lbl_orderNumber.TabIndex = 4;
            this.lbl_orderNumber.Text = "Order Confirmation Form";
            // 
            // txt_orderedBy
            // 
            this.txt_orderedBy.Enabled = false;
            this.txt_orderedBy.Location = new System.Drawing.Point(134, 285);
            this.txt_orderedBy.Name = "txt_orderedBy";
            this.txt_orderedBy.Size = new System.Drawing.Size(202, 22);
            this.txt_orderedBy.TabIndex = 5;
            // 
            // txt_Branch
            // 
            this.txt_Branch.Enabled = false;
            this.txt_Branch.Location = new System.Drawing.Point(134, 244);
            this.txt_Branch.Name = "txt_Branch";
            this.txt_Branch.Size = new System.Drawing.Size(202, 22);
            this.txt_Branch.TabIndex = 6;
            // 
            // txt_dateOrdered
            // 
            this.txt_dateOrdered.Enabled = false;
            this.txt_dateOrdered.Location = new System.Drawing.Point(134, 208);
            this.txt_dateOrdered.Name = "txt_dateOrdered";
            this.txt_dateOrdered.Size = new System.Drawing.Size(202, 22);
            this.txt_dateOrdered.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Date Ordered:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Branch:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ordered By:";
            // 
            // txt_OrderNumber
            // 
            this.txt_OrderNumber.Enabled = false;
            this.txt_OrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_OrderNumber.ForeColor = System.Drawing.Color.Red;
            this.txt_OrderNumber.Location = new System.Drawing.Point(135, 166);
            this.txt_OrderNumber.Multiline = true;
            this.txt_OrderNumber.Name = "txt_OrderNumber";
            this.txt_OrderNumber.Size = new System.Drawing.Size(201, 33);
            this.txt_OrderNumber.TabIndex = 11;
            // 
            // cbm_deliveredBy
            // 
            this.cbm_deliveredBy.FormattingEnabled = true;
            this.cbm_deliveredBy.Location = new System.Drawing.Point(135, 325);
            this.cbm_deliveredBy.Name = "cbm_deliveredBy";
            this.cbm_deliveredBy.Size = new System.Drawing.Size(201, 24);
            this.cbm_deliveredBy.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Develivered By:";
            // 
            // workOnOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 526);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "workOnOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Complete Order Request Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProcessOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdProcessOrder;
        private System.Windows.Forms.Button btn_cancelOrder;
        private System.Windows.Forms.Button btn_processOrder;
        private System.Windows.Forms.Label lbl_orderNumber;
        private System.Windows.Forms.Label lbl_OrderNo;
        private System.Windows.Forms.TextBox txt_orderedBy;
        private System.Windows.Forms.TextBox txt_Branch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_dateOrdered;
        private System.Windows.Forms.TextBox txt_OrderNumber;
        private System.Windows.Forms.ComboBox cbm_deliveredBy;
        private System.Windows.Forms.Label label4;
    }
}