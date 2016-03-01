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
            this.newProuductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSalesOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findSalesOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mstrpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mstrpMain
            // 
            this.mstrpMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.productsToolStripMenuItem,
            this.salesOrdersToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mstrpMain.Location = new System.Drawing.Point(0, 0);
            this.mstrpMain.Name = "mstrpMain";
            this.mstrpMain.Size = new System.Drawing.Size(511, 24);
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            this.newProuductToolStripMenuItem,
            this.findProductToolStripMenuItem});
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.productsToolStripMenuItem.Text = "&Products";
            // 
            // newProuductToolStripMenuItem
            // 
            this.newProuductToolStripMenuItem.Name = "newProuductToolStripMenuItem";
            this.newProuductToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.newProuductToolStripMenuItem.Text = "New Prouduct";
            // 
            // findProductToolStripMenuItem
            // 
            this.findProductToolStripMenuItem.Name = "findProductToolStripMenuItem";
            this.findProductToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.findProductToolStripMenuItem.Text = "Find Product";
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
            // 
            // findSalesOrderToolStripMenuItem
            // 
            this.findSalesOrderToolStripMenuItem.Name = "findSalesOrderToolStripMenuItem";
            this.findSalesOrderToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.findSalesOrderToolStripMenuItem.Text = "Find Sales Order";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // SimpleCRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 244);
            this.Controls.Add(this.mstrpMain);
            this.Name = "SimpleCRM";
            this.Text = "SimpleCRM";
            this.mstrpMain.ResumeLayout(false);
            this.mstrpMain.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem newProuductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSalesOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findSalesOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}