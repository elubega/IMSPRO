namespace IMSPRO
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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProcessOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_orderNumber);
            this.groupBox1.Controls.Add(this.lbl_OrderNo);
            this.groupBox1.Controls.Add(this.btn_cancelOrder);
            this.groupBox1.Controls.Add(this.btn_processOrder);
            this.groupBox1.Controls.Add(this.grdProcessOrder);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(956, 501);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Details";
            // 
            // grdProcessOrder
            // 
            this.grdProcessOrder.AllowUserToAddRows = false;
            this.grdProcessOrder.AllowUserToDeleteRows = false;
            this.grdProcessOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProcessOrder.Location = new System.Drawing.Point(332, 96);
            this.grdProcessOrder.Name = "grdProcessOrder";
            this.grdProcessOrder.ReadOnly = true;
            this.grdProcessOrder.RowTemplate.Height = 24;
            this.grdProcessOrder.Size = new System.Drawing.Size(617, 345);
            this.grdProcessOrder.TabIndex = 0;
            // 
            // btn_processOrder
            // 
            this.btn_processOrder.Location = new System.Drawing.Point(717, 457);
            this.btn_processOrder.Name = "btn_processOrder";
            this.btn_processOrder.Size = new System.Drawing.Size(119, 35);
            this.btn_processOrder.TabIndex = 1;
            this.btn_processOrder.Text = "Process Order";
            this.btn_processOrder.UseVisualStyleBackColor = true;
            // 
            // btn_cancelOrder
            // 
            this.btn_cancelOrder.Location = new System.Drawing.Point(842, 457);
            this.btn_cancelOrder.Name = "btn_cancelOrder";
            this.btn_cancelOrder.Size = new System.Drawing.Size(107, 35);
            this.btn_cancelOrder.TabIndex = 2;
            this.btn_cancelOrder.Text = "Cancel Order";
            this.btn_cancelOrder.UseVisualStyleBackColor = true;
            // 
            // lbl_OrderNo
            // 
            this.lbl_OrderNo.AutoSize = true;
            this.lbl_OrderNo.Location = new System.Drawing.Point(653, 57);
            this.lbl_OrderNo.Name = "lbl_OrderNo";
            this.lbl_OrderNo.Size = new System.Drawing.Size(87, 17);
            this.lbl_OrderNo.TabIndex = 3;
            this.lbl_OrderNo.Text = "Working On:";
            // 
            // lbl_orderNumber
            // 
            this.lbl_orderNumber.AutoSize = true;
            this.lbl_orderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_orderNumber.ForeColor = System.Drawing.Color.Red;
            this.lbl_orderNumber.Location = new System.Drawing.Point(746, 51);
            this.lbl_orderNumber.Name = "lbl_orderNumber";
            this.lbl_orderNumber.Size = new System.Drawing.Size(181, 29);
            this.lbl_orderNumber.TabIndex = 4;
            this.lbl_orderNumber.Text = "Order Number";
            // 
            // workOnOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 526);
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
    }
}