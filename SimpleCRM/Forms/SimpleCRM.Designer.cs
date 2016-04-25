namespace SimpleCRM
{
    partial class SimpleCRM
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
            this.mstrpMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSalesOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findSalesOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mstrpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mstrpMain
            // 
            this.mstrpMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.productsToolStripMenuItem,
            this.salesOrdersToolStripMenuItem});
            this.mstrpMain.Location = new System.Drawing.Point(0, 0);
            this.mstrpMain.Name = "mstrpMain";
            this.mstrpMain.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.mstrpMain.Size = new System.Drawing.Size(383, 24);
            this.mstrpMain.TabIndex = 2;
            this.mstrpMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCustomerToolStripMenuItem,
            this.findCustomerToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(76, 20);
            this.toolStripMenuItem1.Text = "&Customers";
            // 
            // newCustomerToolStripMenuItem
            // 
            this.newCustomerToolStripMenuItem.Name = "newCustomerToolStripMenuItem";
            this.newCustomerToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.newCustomerToolStripMenuItem.Text = "New Customer";
            this.newCustomerToolStripMenuItem.Click += new System.EventHandler(this.newCustomerToolStripMenuItem_Click);
            // 
            // findCustomerToolStripMenuItem
            // 
            this.findCustomerToolStripMenuItem.Name = "findCustomerToolStripMenuItem";
            this.findCustomerToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.findCustomerToolStripMenuItem.Text = "Find Customer";
            this.findCustomerToolStripMenuItem.Click += new System.EventHandler(this.findCustomerToolStripMenuItem_Click);
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findProductToolStripMenuItem,
            this.addProductToolStripMenuItem});
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.productsToolStripMenuItem.Text = "&Products";
            // 
            // findProductToolStripMenuItem
            // 
            this.findProductToolStripMenuItem.Name = "findProductToolStripMenuItem";
            this.findProductToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.findProductToolStripMenuItem.Text = "Find Product";
            this.findProductToolStripMenuItem.Click += new System.EventHandler(this.findProductToolStripMenuItem_Click);
            // 
            // addProductToolStripMenuItem
            // 
            this.addProductToolStripMenuItem.Name = "addProductToolStripMenuItem";
            this.addProductToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.addProductToolStripMenuItem.Text = "Add Product";
            this.addProductToolStripMenuItem.Click += new System.EventHandler(this.addProductToolStripMenuItem_Click);
            // 
            // salesOrdersToolStripMenuItem
            // 
            this.salesOrdersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSalesOrderToolStripMenuItem,
            this.findSalesOrderToolStripMenuItem});
            this.salesOrdersToolStripMenuItem.Name = "salesOrdersToolStripMenuItem";
            this.salesOrdersToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.salesOrdersToolStripMenuItem.Text = "&Sales Orders";
            // 
            // newSalesOrderToolStripMenuItem
            // 
            this.newSalesOrderToolStripMenuItem.Name = "newSalesOrderToolStripMenuItem";
            this.newSalesOrderToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.newSalesOrderToolStripMenuItem.Text = "New Sales Order";
            this.newSalesOrderToolStripMenuItem.Click += new System.EventHandler(this.newSalesOrderToolStripMenuItem_Click);
            // 
            // findSalesOrderToolStripMenuItem
            // 
            this.findSalesOrderToolStripMenuItem.Name = "findSalesOrderToolStripMenuItem";
            this.findSalesOrderToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.findSalesOrderToolStripMenuItem.Text = "Find Sales Order";
            this.findSalesOrderToolStripMenuItem.Click += new System.EventHandler(this.findSalesOrderToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SimpleCRM.Properties.Resources.company_logo1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(359, 159);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // SimpleCRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 198);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mstrpMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SimpleCRM";
            this.Text = "SimpleCRM";
            this.mstrpMain.ResumeLayout(false);
            this.mstrpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mstrpMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSalesOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findSalesOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addProductToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}