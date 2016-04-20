namespace SimpleCRM.Forms.UserControls
{
    partial class ProductUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBoxProduct = new System.Windows.Forms.PictureBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblStandardCost = new System.Windows.Forms.Label();
            this.lblListPrice = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblProductModelID = new System.Windows.Forms.Label();
            this.lblProductCategoryID = new System.Windows.Forms.Label();
            this.lblDiscontinuedDate = new System.Windows.Forms.Label();
            this.lblSellEndDate = new System.Windows.Forms.Label();
            this.lblSellStartDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxProduct
            // 
            this.picBoxProduct.Location = new System.Drawing.Point(2, 2);
            this.picBoxProduct.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picBoxProduct.Name = "picBoxProduct";
            this.picBoxProduct.Size = new System.Drawing.Size(147, 167);
            this.picBoxProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxProduct.TabIndex = 0;
            this.picBoxProduct.TabStop = false;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(153, 2);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(148, 25);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "Product Name";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.Location = new System.Drawing.Point(154, 53);
            this.lblColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(45, 18);
            this.lblColor.TabIndex = 2;
            this.lblColor.Text = "Color";
            // 
            // lblStandardCost
            // 
            this.lblStandardCost.AutoSize = true;
            this.lblStandardCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandardCost.Location = new System.Drawing.Point(154, 79);
            this.lblStandardCost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStandardCost.Name = "lblStandardCost";
            this.lblStandardCost.Size = new System.Drawing.Size(103, 18);
            this.lblStandardCost.TabIndex = 3;
            this.lblStandardCost.Text = "Standard Cost";
            // 
            // lblListPrice
            // 
            this.lblListPrice.AutoSize = true;
            this.lblListPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListPrice.Location = new System.Drawing.Point(154, 105);
            this.lblListPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblListPrice.Name = "lblListPrice";
            this.lblListPrice.Size = new System.Drawing.Size(69, 18);
            this.lblListPrice.TabIndex = 4;
            this.lblListPrice.Text = "List Price";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(154, 129);
            this.lblSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(37, 18);
            this.lblSize.TabIndex = 5;
            this.lblSize.Text = "Size";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.Location = new System.Drawing.Point(154, 155);
            this.lblWeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(54, 18);
            this.lblWeight.TabIndex = 6;
            this.lblWeight.Text = "Weight";
            // 
            // lblProductModelID
            // 
            this.lblProductModelID.AutoSize = true;
            this.lblProductModelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductModelID.Location = new System.Drawing.Point(353, 155);
            this.lblProductModelID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProductModelID.Name = "lblProductModelID";
            this.lblProductModelID.Size = new System.Drawing.Size(115, 18);
            this.lblProductModelID.TabIndex = 11;
            this.lblProductModelID.Text = "ProductModelID";
            // 
            // lblProductCategoryID
            // 
            this.lblProductCategoryID.AutoSize = true;
            this.lblProductCategoryID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductCategoryID.Location = new System.Drawing.Point(353, 129);
            this.lblProductCategoryID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProductCategoryID.Name = "lblProductCategoryID";
            this.lblProductCategoryID.Size = new System.Drawing.Size(134, 18);
            this.lblProductCategoryID.TabIndex = 10;
            this.lblProductCategoryID.Text = "ProductCategoryID";
            // 
            // lblDiscontinuedDate
            // 
            this.lblDiscontinuedDate.AutoSize = true;
            this.lblDiscontinuedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscontinuedDate.Location = new System.Drawing.Point(353, 105);
            this.lblDiscontinuedDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiscontinuedDate.Name = "lblDiscontinuedDate";
            this.lblDiscontinuedDate.Size = new System.Drawing.Size(129, 18);
            this.lblDiscontinuedDate.TabIndex = 9;
            this.lblDiscontinuedDate.Text = "Discontinued Date";
            // 
            // lblSellEndDate
            // 
            this.lblSellEndDate.AutoSize = true;
            this.lblSellEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellEndDate.Location = new System.Drawing.Point(353, 79);
            this.lblSellEndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSellEndDate.Name = "lblSellEndDate";
            this.lblSellEndDate.Size = new System.Drawing.Size(97, 18);
            this.lblSellEndDate.TabIndex = 8;
            this.lblSellEndDate.Text = "Sell End Date";
            // 
            // lblSellStartDate
            // 
            this.lblSellStartDate.AutoSize = true;
            this.lblSellStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellStartDate.Location = new System.Drawing.Point(353, 53);
            this.lblSellStartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSellStartDate.Name = "lblSellStartDate";
            this.lblSellStartDate.Size = new System.Drawing.Size(102, 18);
            this.lblSellStartDate.TabIndex = 7;
            this.lblSellStartDate.Text = "Sell Start Date";
            // 
            // ProductUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblProductModelID);
            this.Controls.Add(this.lblProductCategoryID);
            this.Controls.Add(this.lblDiscontinuedDate);
            this.Controls.Add(this.lblSellEndDate);
            this.Controls.Add(this.lblSellStartDate);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblListPrice);
            this.Controls.Add(this.lblStandardCost);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.picBoxProduct);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ProductUserControl";
            this.Size = new System.Drawing.Size(590, 182);
            this.Load += new System.EventHandler(this.ProductUserControl_Load);
            this.DoubleClick += new System.EventHandler(this.ProductUserControl_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxProduct;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblStandardCost;
        private System.Windows.Forms.Label lblListPrice;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblProductModelID;
        private System.Windows.Forms.Label lblProductCategoryID;
        private System.Windows.Forms.Label lblDiscontinuedDate;
        private System.Windows.Forms.Label lblSellEndDate;
        private System.Windows.Forms.Label lblSellStartDate;
    }
}
