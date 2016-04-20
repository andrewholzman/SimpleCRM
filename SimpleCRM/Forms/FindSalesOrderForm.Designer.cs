namespace SimpleCRM
{
    partial class FindSalesOrderForm
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
            this.dgvSalesOrderInfo = new System.Windows.Forms.DataGridView();
            this.btnFindSalesOrder = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesOrderInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSalesOrderInfo
            // 
            this.dgvSalesOrderInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSalesOrderInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesOrderInfo.Location = new System.Drawing.Point(14, 42);
            this.dgvSalesOrderInfo.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSalesOrderInfo.Name = "dgvSalesOrderInfo";
            this.dgvSalesOrderInfo.RowTemplate.Height = 24;
            this.dgvSalesOrderInfo.Size = new System.Drawing.Size(576, 168);
            this.dgvSalesOrderInfo.TabIndex = 7;
            this.dgvSalesOrderInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesOrderInfo_CellDoubleClick);
            // 
            // btnFindSalesOrder
            // 
            this.btnFindSalesOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindSalesOrder.Location = new System.Drawing.Point(527, 8);
            this.btnFindSalesOrder.Margin = new System.Windows.Forms.Padding(2);
            this.btnFindSalesOrder.Name = "btnFindSalesOrder";
            this.btnFindSalesOrder.Size = new System.Drawing.Size(63, 26);
            this.btnFindSalesOrder.TabIndex = 6;
            this.btnFindSalesOrder.Text = "Find";
            this.btnFindSalesOrder.UseVisualStyleBackColor = true;
            this.btnFindSalesOrder.Click += new System.EventHandler(this.btnFindSalesOrder_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(78, 12);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(445, 20);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sales Order:";
            // 
            // FindSalesOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 219);
            this.Controls.Add(this.dgvSalesOrderInfo);
            this.Controls.Add(this.btnFindSalesOrder);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Name = "FindSalesOrderForm";
            this.Text = "FindSalesOrderForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesOrderInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSalesOrderInfo;
        private System.Windows.Forms.Button btnFindSalesOrder;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
    }
}