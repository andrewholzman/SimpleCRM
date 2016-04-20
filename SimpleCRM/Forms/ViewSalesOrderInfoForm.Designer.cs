namespace SimpleCRM.Forms
{
    partial class ViewSalesOrderInfoForm
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
            this.dgvProductInfo = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSalesOrderNumber = new System.Windows.Forms.TextBox();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalDue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtShipDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDueDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductInfo
            // 
            this.dgvProductInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductInfo.Location = new System.Drawing.Point(16, 98);
            this.dgvProductInfo.Name = "dgvProductInfo";
            this.dgvProductInfo.Size = new System.Drawing.Size(660, 166);
            this.dgvProductInfo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sales Order Number:";
            // 
            // txtSalesOrderNumber
            // 
            this.txtSalesOrderNumber.Location = new System.Drawing.Point(124, 10);
            this.txtSalesOrderNumber.Name = "txtSalesOrderNumber";
            this.txtSalesOrderNumber.ReadOnly = true;
            this.txtSalesOrderNumber.Size = new System.Drawing.Size(100, 20);
            this.txtSalesOrderNumber.TabIndex = 2;
            this.txtSalesOrderNumber.Text = "Order#";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Location = new System.Drawing.Point(124, 36);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.ReadOnly = true;
            this.txtAccountNumber.Size = new System.Drawing.Size(100, 20);
            this.txtAccountNumber.TabIndex = 4;
            this.txtAccountNumber.Text = "Account#";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Account Number:";
            // 
            // txtTotalDue
            // 
            this.txtTotalDue.Location = new System.Drawing.Point(124, 62);
            this.txtTotalDue.Name = "txtTotalDue";
            this.txtTotalDue.ReadOnly = true;
            this.txtTotalDue.Size = new System.Drawing.Size(100, 20);
            this.txtTotalDue.TabIndex = 6;
            this.txtTotalDue.Text = "TotalDue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Total Due:";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(250, 10);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(159, 20);
            this.lblCustomerName.TabIndex = 7;
            this.lblCustomerName.Text = "FirstName LastName";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Location = new System.Drawing.Point(251, 31);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(103, 16);
            this.lblCompanyName.TabIndex = 8;
            this.lblCompanyName.Text = "ComapnyName";
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailAddress.Location = new System.Drawing.Point(251, 48);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(93, 16);
            this.lblEmailAddress.TabIndex = 9;
            this.lblEmailAddress.Text = "EmailAddress";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.Location = new System.Drawing.Point(251, 65);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(95, 16);
            this.lblPhoneNumber.TabIndex = 10;
            this.lblPhoneNumber.Text = "PhoneNumber";
            // 
            // txtShipDate
            // 
            this.txtShipDate.Location = new System.Drawing.Point(532, 61);
            this.txtShipDate.Name = "txtShipDate";
            this.txtShipDate.ReadOnly = true;
            this.txtShipDate.Size = new System.Drawing.Size(144, 20);
            this.txtShipDate.TabIndex = 16;
            this.txtShipDate.Text = "ShipDate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(460, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Ship Date";
            // 
            // txtDueDate
            // 
            this.txtDueDate.Location = new System.Drawing.Point(532, 35);
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.ReadOnly = true;
            this.txtDueDate.Size = new System.Drawing.Size(144, 20);
            this.txtDueDate.TabIndex = 14;
            this.txtDueDate.Text = "DueDate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(460, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Due Date:";
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Location = new System.Drawing.Point(532, 9);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.ReadOnly = true;
            this.txtOrderDate.Size = new System.Drawing.Size(144, 20);
            this.txtOrderDate.TabIndex = 12;
            this.txtOrderDate.Text = "OrderDate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(460, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Order Date:";
            // 
            // ViewSalesOrderInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 276);
            this.Controls.Add(this.txtShipDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDueDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.lblEmailAddress);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.txtTotalDue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAccountNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSalesOrderNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvProductInfo);
            this.Name = "ViewSalesOrderInfoForm";
            this.Text = "ViewSalesOrderInfoForm";
            this.Load += new System.EventHandler(this.ViewSalesOrderInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSalesOrderNumber;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalDue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtShipDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDueDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.Label label6;
    }
}