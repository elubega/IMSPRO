namespace IMSPRO
{
    partial class ViewReport
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewReport));
            this.reportViewCustomers = new System.Windows.Forms.DataGridView();
            this.orderNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerPhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOrderedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportOrderInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_LoadReport = new System.Windows.Forms.Button();
            this.btn_ViewReport = new System.Windows.Forms.Button();
            this.ordersReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txt_SearchOrder = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.reportViewCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportOrderInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewCustomers
            // 
            this.reportViewCustomers.AllowUserToAddRows = false;
            this.reportViewCustomers.AllowUserToDeleteRows = false;
            this.reportViewCustomers.AutoGenerateColumns = false;
            this.reportViewCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportViewCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderNoDataGridViewTextBoxColumn,
            this.branchDataGridViewTextBoxColumn,
            this.customerNameDataGridViewTextBoxColumn,
            this.customerPhoneDataGridViewTextBoxColumn,
            this.dateOrderedDataGridViewTextBoxColumn});
            this.reportViewCustomers.DataSource = this.reportOrderInfoBindingSource;
            this.reportViewCustomers.Location = new System.Drawing.Point(13, 81);
            this.reportViewCustomers.Name = "reportViewCustomers";
            this.reportViewCustomers.ReadOnly = true;
            this.reportViewCustomers.RowTemplate.Height = 24;
            this.reportViewCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.reportViewCustomers.Size = new System.Drawing.Size(924, 293);
            this.reportViewCustomers.TabIndex = 0;
            // 
            // orderNoDataGridViewTextBoxColumn
            // 
            this.orderNoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.orderNoDataGridViewTextBoxColumn.DataPropertyName = "orderNo";
            this.orderNoDataGridViewTextBoxColumn.HeaderText = "Order No";
            this.orderNoDataGridViewTextBoxColumn.Name = "orderNoDataGridViewTextBoxColumn";
            this.orderNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // branchDataGridViewTextBoxColumn
            // 
            this.branchDataGridViewTextBoxColumn.DataPropertyName = "branch";
            this.branchDataGridViewTextBoxColumn.HeaderText = "Branch";
            this.branchDataGridViewTextBoxColumn.Name = "branchDataGridViewTextBoxColumn";
            this.branchDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerNameDataGridViewTextBoxColumn
            // 
            this.customerNameDataGridViewTextBoxColumn.DataPropertyName = "customerName";
            this.customerNameDataGridViewTextBoxColumn.HeaderText = "Customer Name";
            this.customerNameDataGridViewTextBoxColumn.Name = "customerNameDataGridViewTextBoxColumn";
            this.customerNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerPhoneDataGridViewTextBoxColumn
            // 
            this.customerPhoneDataGridViewTextBoxColumn.DataPropertyName = "customerPhone";
            this.customerPhoneDataGridViewTextBoxColumn.HeaderText = "Customer Phone";
            this.customerPhoneDataGridViewTextBoxColumn.Name = "customerPhoneDataGridViewTextBoxColumn";
            this.customerPhoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateOrderedDataGridViewTextBoxColumn
            // 
            this.dateOrderedDataGridViewTextBoxColumn.DataPropertyName = "dateOrdered";
            this.dateOrderedDataGridViewTextBoxColumn.HeaderText = "Date Ordered";
            this.dateOrderedDataGridViewTextBoxColumn.Name = "dateOrderedDataGridViewTextBoxColumn";
            this.dateOrderedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // reportOrderInfoBindingSource
            // 
            this.reportOrderInfoBindingSource.DataSource = typeof(IMSPRO.reportOrderInfo);
            // 
            // btn_LoadReport
            // 
            this.btn_LoadReport.BackColor = System.Drawing.SystemColors.Control;
            this.btn_LoadReport.Location = new System.Drawing.Point(828, 36);
            this.btn_LoadReport.Name = "btn_LoadReport";
            this.btn_LoadReport.Size = new System.Drawing.Size(109, 39);
            this.btn_LoadReport.TabIndex = 1;
            this.btn_LoadReport.Text = "Load Report";
            this.btn_LoadReport.UseVisualStyleBackColor = false;
            this.btn_LoadReport.Click += new System.EventHandler(this.btn_LoadReport_Click);
            // 
            // btn_ViewReport
            // 
            this.btn_ViewReport.Location = new System.Drawing.Point(828, 380);
            this.btn_ViewReport.Name = "btn_ViewReport";
            this.btn_ViewReport.Size = new System.Drawing.Size(109, 37);
            this.btn_ViewReport.TabIndex = 2;
            this.btn_ViewReport.Text = "Print Report";
            this.btn_ViewReport.UseVisualStyleBackColor = true;
            this.btn_ViewReport.Click += new System.EventHandler(this.btn_ViewReport_Click);
            // 
            // ordersReportBindingSource
            // 
            this.ordersReportBindingSource.DataSource = typeof(IMSPRO.OrdersReport);
            // 
            // txt_SearchOrder
            // 
            this.txt_SearchOrder.Location = new System.Drawing.Point(431, 36);
            this.txt_SearchOrder.Multiline = true;
            this.txt_SearchOrder.Name = "txt_SearchOrder";
            this.txt_SearchOrder.Size = new System.Drawing.Size(391, 39);
            this.txt_SearchOrder.TabIndex = 3;
            // 
            // ViewReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 429);
            this.Controls.Add(this.txt_SearchOrder);
            this.Controls.Add(this.btn_ViewReport);
            this.Controls.Add(this.btn_LoadReport);
            this.Controls.Add(this.reportViewCustomers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ViewReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orders Report";
            ((System.ComponentModel.ISupportInitialize)(this.reportViewCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportOrderInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersReportBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView reportViewCustomers;
        private System.Windows.Forms.Button btn_LoadReport;
        private System.Windows.Forms.BindingSource reportOrderInfoBindingSource;
        private System.Windows.Forms.Button btn_ViewReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn branchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerPhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOrderedDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource ordersReportBindingSource;
        private System.Windows.Forms.TextBox txt_SearchOrder;
    }
}