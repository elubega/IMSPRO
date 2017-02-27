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
            this.btn_CancelOrder = new System.Windows.Forms.Button();
            this.btn_MakeOrder = new System.Windows.Forms.Button();
            this.txt_orderNo = new System.Windows.Forms.TextBox();
            this.txt_dateOrdered = new System.Windows.Forms.TextBox();
            this.cbm_branchName = new System.Windows.Forms.ComboBox();
            this.cbm_orderedBy = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grdOrderForm = new System.Windows.Forms.DataGridView();
            this.txt_barCode = new System.Windows.Forms.TextBox();
            this.txt_productName = new System.Windows.Forms.TextBox();
            this.txt_qty = new System.Windows.Forms.TextBox();
            this.btn_addOrder = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_UnitMeasure = new System.Windows.Forms.TextBox();
            this.txt_customer = new System.Windows.Forms.TextBox();
            this.txt_phoneNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_price = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderForm)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(424, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order Request Form";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txt_phoneNo);
            this.groupBox1.Controls.Add(this.txt_customer);
            this.groupBox1.Controls.Add(this.txt_orderNo);
            this.groupBox1.Controls.Add(this.txt_dateOrdered);
            this.groupBox1.Controls.Add(this.cbm_branchName);
            this.groupBox1.Controls.Add(this.cbm_orderedBy);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 63);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1153, 163);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Information";
            // 
            // btn_CancelOrder
            // 
            this.btn_CancelOrder.Location = new System.Drawing.Point(1046, 679);
            this.btn_CancelOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CancelOrder.Name = "btn_CancelOrder";
            this.btn_CancelOrder.Size = new System.Drawing.Size(120, 59);
            this.btn_CancelOrder.TabIndex = 9;
            this.btn_CancelOrder.Text = "Cancel Order";
            this.btn_CancelOrder.UseVisualStyleBackColor = true;
            this.btn_CancelOrder.Click += new System.EventHandler(this.btn_CancelOrder_Click);
            // 
            // btn_MakeOrder
            // 
            this.btn_MakeOrder.Location = new System.Drawing.Point(906, 679);
            this.btn_MakeOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btn_MakeOrder.Name = "btn_MakeOrder";
            this.btn_MakeOrder.Size = new System.Drawing.Size(132, 59);
            this.btn_MakeOrder.TabIndex = 8;
            this.btn_MakeOrder.Text = "Make Order";
            this.btn_MakeOrder.UseVisualStyleBackColor = true;
            this.btn_MakeOrder.Click += new System.EventHandler(this.btn_MakeOrder_Click);
            // 
            // txt_orderNo
            // 
            this.txt_orderNo.Enabled = false;
            this.txt_orderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_orderNo.ForeColor = System.Drawing.Color.Red;
            this.txt_orderNo.Location = new System.Drawing.Point(985, 35);
            this.txt_orderNo.Margin = new System.Windows.Forms.Padding(4);
            this.txt_orderNo.Name = "txt_orderNo";
            this.txt_orderNo.Size = new System.Drawing.Size(160, 29);
            this.txt_orderNo.TabIndex = 7;
            this.txt_orderNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_dateOrdered
            // 
            this.txt_dateOrdered.Enabled = false;
            this.txt_dateOrdered.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dateOrdered.Location = new System.Drawing.Point(945, 72);
            this.txt_dateOrdered.Margin = new System.Windows.Forms.Padding(4);
            this.txt_dateOrdered.Name = "txt_dateOrdered";
            this.txt_dateOrdered.Size = new System.Drawing.Size(201, 26);
            this.txt_dateOrdered.TabIndex = 6;
            this.txt_dateOrdered.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbm_branchName
            // 
            this.cbm_branchName.FormattingEnabled = true;
            this.cbm_branchName.Location = new System.Drawing.Point(135, 64);
            this.cbm_branchName.Margin = new System.Windows.Forms.Padding(4);
            this.cbm_branchName.Name = "cbm_branchName";
            this.cbm_branchName.Size = new System.Drawing.Size(201, 24);
            this.cbm_branchName.TabIndex = 1;
            // 
            // cbm_orderedBy
            // 
            this.cbm_orderedBy.FormattingEnabled = true;
            this.cbm_orderedBy.Location = new System.Drawing.Point(135, 32);
            this.cbm_orderedBy.Margin = new System.Windows.Forms.Padding(4);
            this.cbm_orderedBy.Name = "cbm_orderedBy";
            this.cbm_orderedBy.Size = new System.Drawing.Size(201, 24);
            this.cbm_orderedBy.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 35);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ordered By:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Branch:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(838, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Date Ordered:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(902, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Order No.:";
            // 
            // grdOrderForm
            // 
            this.grdOrderForm.AllowUserToAddRows = false;
            this.grdOrderForm.AllowUserToDeleteRows = false;
            this.grdOrderForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdOrderForm.Location = new System.Drawing.Point(16, 304);
            this.grdOrderForm.Margin = new System.Windows.Forms.Padding(4);
            this.grdOrderForm.Name = "grdOrderForm";
            this.grdOrderForm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdOrderForm.Size = new System.Drawing.Size(1150, 367);
            this.grdOrderForm.TabIndex = 2;
            this.grdOrderForm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdOrderForm_KeyDown);
            // 
            // txt_barCode
            // 
            this.txt_barCode.Location = new System.Drawing.Point(16, 270);
            this.txt_barCode.Margin = new System.Windows.Forms.Padding(4);
            this.txt_barCode.Name = "txt_barCode";
            this.txt_barCode.Size = new System.Drawing.Size(220, 22);
            this.txt_barCode.TabIndex = 3;
            this.txt_barCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_barCode_KeyDown);
            // 
            // txt_productName
            // 
            this.txt_productName.Location = new System.Drawing.Point(247, 270);
            this.txt_productName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_productName.Name = "txt_productName";
            this.txt_productName.Size = new System.Drawing.Size(379, 22);
            this.txt_productName.TabIndex = 4;
            this.txt_productName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_productName_KeyDown);
            // 
            // txt_qty
            // 
            this.txt_qty.Location = new System.Drawing.Point(636, 270);
            this.txt_qty.Margin = new System.Windows.Forms.Padding(4);
            this.txt_qty.Name = "txt_qty";
            this.txt_qty.Size = new System.Drawing.Size(91, 22);
            this.txt_qty.TabIndex = 5;
            this.txt_qty.TextChanged += new System.EventHandler(this.txt_qty_TextChanged);
            this.txt_qty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_qty_KeyDown);
            // 
            // btn_addOrder
            // 
            this.btn_addOrder.Location = new System.Drawing.Point(1015, 267);
            this.btn_addOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btn_addOrder.Name = "btn_addOrder";
            this.btn_addOrder.Size = new System.Drawing.Size(151, 29);
            this.btn_addOrder.TabIndex = 7;
            this.btn_addOrder.Text = "Add";
            this.btn_addOrder.UseVisualStyleBackColor = true;
            this.btn_addOrder.Click += new System.EventHandler(this.btn_addOrder_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 247);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Barcode:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(247, 247);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Product Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(636, 245);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "Qty:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(739, 245);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "Unit Measure";
            // 
            // txt_UnitMeasure
            // 
            this.txt_UnitMeasure.Enabled = false;
            this.txt_UnitMeasure.Location = new System.Drawing.Point(735, 271);
            this.txt_UnitMeasure.Name = "txt_UnitMeasure";
            this.txt_UnitMeasure.Size = new System.Drawing.Size(125, 22);
            this.txt_UnitMeasure.TabIndex = 12;
            // 
            // txt_customer
            // 
            this.txt_customer.Location = new System.Drawing.Point(135, 95);
            this.txt_customer.Name = "txt_customer";
            this.txt_customer.Size = new System.Drawing.Size(201, 22);
            this.txt_customer.TabIndex = 10;
            // 
            // txt_phoneNo
            // 
            this.txt_phoneNo.Location = new System.Drawing.Point(135, 123);
            this.txt_phoneNo.Name = "txt_phoneNo";
            this.txt_phoneNo.Size = new System.Drawing.Size(201, 22);
            this.txt_phoneNo.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 17);
            this.label10.TabIndex = 12;
            this.label10.Text = "Customer Tel:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 17);
            this.label11.TabIndex = 13;
            this.label11.Text = "Customer Name:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(869, 246);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 17);
            this.label12.TabIndex = 13;
            this.label12.Text = "Price";
            // 
            // txt_price
            // 
            this.txt_price.Location = new System.Drawing.Point(866, 271);
            this.txt_price.Name = "txt_price";
            this.txt_price.Size = new System.Drawing.Size(142, 22);
            this.txt_price.TabIndex = 14;
            // 
            // orderRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 748);
            this.Controls.Add(this.txt_price);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_UnitMeasure);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btn_CancelOrder);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_MakeOrder);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_addOrder);
            this.Controls.Add(this.txt_qty);
            this.Controls.Add(this.txt_productName);
            this.Controls.Add(this.txt_barCode);
            this.Controls.Add(this.grdOrderForm);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Button btn_addOrder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_CancelOrder;
        private System.Windows.Forms.Button btn_MakeOrder;
        private System.Windows.Forms.TextBox txt_UnitMeasure;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_phoneNo;
        private System.Windows.Forms.TextBox txt_customer;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_price;
    }
}