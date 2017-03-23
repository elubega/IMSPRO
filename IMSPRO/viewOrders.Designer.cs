namespace IMSPRO
{
    partial class viewOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewOrders));
            this.allOrders = new System.Windows.Forms.TabControl();
            this.pendingOrders = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.txt_searchOrder = new System.Windows.Forms.TextBox();
            this.btn_searchOrders = new System.Windows.Forms.Button();
            this.grdPendingOrders = new System.Windows.Forms.DataGridView();
            this.completedOrders = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdCompletedOrders = new System.Windows.Forms.DataGridView();
            this.allOrders.SuspendLayout();
            this.pendingOrders.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPendingOrders)).BeginInit();
            this.completedOrders.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompletedOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // allOrders
            // 
            this.allOrders.Controls.Add(this.pendingOrders);
            this.allOrders.Controls.Add(this.completedOrders);
            this.allOrders.Location = new System.Drawing.Point(23, 28);
            this.allOrders.Name = "allOrders";
            this.allOrders.SelectedIndex = 0;
            this.allOrders.Size = new System.Drawing.Size(1426, 477);
            this.allOrders.TabIndex = 0;
            this.allOrders.SelectedIndexChanged += new System.EventHandler(this.allOrders_SelectedIndexChanged);
            // 
            // pendingOrders
            // 
            this.pendingOrders.Controls.Add(this.groupBox1);
            this.pendingOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pendingOrders.Location = new System.Drawing.Point(4, 25);
            this.pendingOrders.Name = "pendingOrders";
            this.pendingOrders.Padding = new System.Windows.Forms.Padding(3);
            this.pendingOrders.Size = new System.Drawing.Size(1418, 448);
            this.pendingOrders.TabIndex = 0;
            this.pendingOrders.Text = "Pending Orders";
            this.pendingOrders.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_refresh);
            this.groupBox1.Controls.Add(this.txt_searchOrder);
            this.groupBox1.Controls.Add(this.btn_searchOrders);
            this.groupBox1.Controls.Add(this.grdPendingOrders);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(28, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1384, 404);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pending Orders";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(1279, 24);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(99, 35);
            this.btn_refresh.TabIndex = 3;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // txt_searchOrder
            // 
            this.txt_searchOrder.Location = new System.Drawing.Point(830, 25);
            this.txt_searchOrder.Multiline = true;
            this.txt_searchOrder.Name = "txt_searchOrder";
            this.txt_searchOrder.Size = new System.Drawing.Size(320, 33);
            this.txt_searchOrder.TabIndex = 2;
            this.txt_searchOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_searchOrder_KeyDown);
            // 
            // btn_searchOrders
            // 
            this.btn_searchOrders.Location = new System.Drawing.Point(1156, 24);
            this.btn_searchOrders.Name = "btn_searchOrders";
            this.btn_searchOrders.Size = new System.Drawing.Size(113, 35);
            this.btn_searchOrders.TabIndex = 1;
            this.btn_searchOrders.Text = "Search Order";
            this.btn_searchOrders.UseVisualStyleBackColor = true;
            this.btn_searchOrders.Click += new System.EventHandler(this.btn_searchOrders_Click);
            // 
            // grdPendingOrders
            // 
            this.grdPendingOrders.AllowUserToAddRows = false;
            this.grdPendingOrders.AllowUserToDeleteRows = false;
            this.grdPendingOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPendingOrders.Location = new System.Drawing.Point(7, 64);
            this.grdPendingOrders.Name = "grdPendingOrders";
            this.grdPendingOrders.ReadOnly = true;
            this.grdPendingOrders.RowTemplate.Height = 24;
            this.grdPendingOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPendingOrders.Size = new System.Drawing.Size(1371, 325);
            this.grdPendingOrders.TabIndex = 0;
            this.grdPendingOrders.DoubleClick += new System.EventHandler(this.grdPendingOrders_DoubleClick);
            // 
            // completedOrders
            // 
            this.completedOrders.Controls.Add(this.groupBox2);
            this.completedOrders.Location = new System.Drawing.Point(4, 25);
            this.completedOrders.Name = "completedOrders";
            this.completedOrders.Padding = new System.Windows.Forms.Padding(3);
            this.completedOrders.Size = new System.Drawing.Size(1418, 448);
            this.completedOrders.TabIndex = 1;
            this.completedOrders.Text = "Completed Orders";
            this.completedOrders.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdCompletedOrders);
            this.groupBox2.Location = new System.Drawing.Point(16, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1396, 404);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Completed Orders";
            // 
            // grdCompletedOrders
            // 
            this.grdCompletedOrders.AllowUserToAddRows = false;
            this.grdCompletedOrders.AllowUserToDeleteRows = false;
            this.grdCompletedOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCompletedOrders.Location = new System.Drawing.Point(17, 31);
            this.grdCompletedOrders.Name = "grdCompletedOrders";
            this.grdCompletedOrders.ReadOnly = true;
            this.grdCompletedOrders.RowTemplate.Height = 24;
            this.grdCompletedOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCompletedOrders.Size = new System.Drawing.Size(1373, 353);
            this.grdCompletedOrders.TabIndex = 0;
            this.grdCompletedOrders.DoubleClick += new System.EventHandler(this.grdCompletedOrders_DoubleClick);
            // 
            // viewOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 517);
            this.Controls.Add(this.allOrders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "viewOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View All Orders";
            this.Load += new System.EventHandler(this.viewOrders_Load);
            this.allOrders.ResumeLayout(false);
            this.pendingOrders.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPendingOrders)).EndInit();
            this.completedOrders.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCompletedOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl allOrders;
        private System.Windows.Forms.TabPage pendingOrders;
        private System.Windows.Forms.TabPage completedOrders;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_searchOrder;
        private System.Windows.Forms.Button btn_searchOrders;
        private System.Windows.Forms.DataGridView grdPendingOrders;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grdCompletedOrders;
    }
}