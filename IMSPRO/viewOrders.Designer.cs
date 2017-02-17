﻿namespace IMSPRO
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
            this.completedOrders = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdPendingOrders = new System.Windows.Forms.DataGridView();
            this.btn_searchOrders = new System.Windows.Forms.Button();
            this.txt_searchOrder = new System.Windows.Forms.TextBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.allOrders.SuspendLayout();
            this.pendingOrders.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPendingOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // allOrders
            // 
            this.allOrders.Controls.Add(this.pendingOrders);
            this.allOrders.Controls.Add(this.completedOrders);
            this.allOrders.Location = new System.Drawing.Point(23, 28);
            this.allOrders.Name = "allOrders";
            this.allOrders.SelectedIndex = 0;
            this.allOrders.Size = new System.Drawing.Size(954, 477);
            this.allOrders.TabIndex = 0;
            // 
            // pendingOrders
            // 
            this.pendingOrders.Controls.Add(this.groupBox1);
            this.pendingOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pendingOrders.Location = new System.Drawing.Point(4, 25);
            this.pendingOrders.Name = "pendingOrders";
            this.pendingOrders.Padding = new System.Windows.Forms.Padding(3);
            this.pendingOrders.Size = new System.Drawing.Size(946, 448);
            this.pendingOrders.TabIndex = 0;
            this.pendingOrders.Text = "Pending Orders";
            this.pendingOrders.UseVisualStyleBackColor = true;
            // 
            // completedOrders
            // 
            this.completedOrders.Location = new System.Drawing.Point(4, 25);
            this.completedOrders.Name = "completedOrders";
            this.completedOrders.Padding = new System.Windows.Forms.Padding(3);
            this.completedOrders.Size = new System.Drawing.Size(946, 448);
            this.completedOrders.TabIndex = 1;
            this.completedOrders.Text = "Completed Orders";
            this.completedOrders.UseVisualStyleBackColor = true;
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
            this.groupBox1.Size = new System.Drawing.Size(900, 404);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pending Orders";
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
            this.grdPendingOrders.Size = new System.Drawing.Size(887, 325);
            this.grdPendingOrders.TabIndex = 0;
            // 
            // btn_searchOrders
            // 
            this.btn_searchOrders.Location = new System.Drawing.Point(675, 24);
            this.btn_searchOrders.Name = "btn_searchOrders";
            this.btn_searchOrders.Size = new System.Drawing.Size(113, 35);
            this.btn_searchOrders.TabIndex = 1;
            this.btn_searchOrders.Text = "Search Order";
            this.btn_searchOrders.UseVisualStyleBackColor = true;
            this.btn_searchOrders.Click += new System.EventHandler(this.btn_searchOrders_Click);
            // 
            // txt_searchOrder
            // 
            this.txt_searchOrder.Location = new System.Drawing.Point(349, 25);
            this.txt_searchOrder.Multiline = true;
            this.txt_searchOrder.Name = "txt_searchOrder";
            this.txt_searchOrder.Size = new System.Drawing.Size(320, 33);
            this.txt_searchOrder.TabIndex = 2;
            this.txt_searchOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_searchOrder_KeyDown);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(795, 24);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(99, 35);
            this.btn_refresh.TabIndex = 3;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // viewOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 517);
            this.Controls.Add(this.allOrders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "viewOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View All Orders";
            this.allOrders.ResumeLayout(false);
            this.pendingOrders.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPendingOrders)).EndInit();
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
    }
}