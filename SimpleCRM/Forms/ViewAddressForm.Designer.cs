namespace SimpleCRM.Forms
{
    partial class ViewAddressForm
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
            this.wbMapView = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbMapView
            // 
            this.wbMapView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbMapView.Location = new System.Drawing.Point(12, 12);
            this.wbMapView.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbMapView.Name = "wbMapView";
            this.wbMapView.Size = new System.Drawing.Size(667, 317);
            this.wbMapView.TabIndex = 0;
            // 
            // ViewAddressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 341);
            this.Controls.Add(this.wbMapView);
            this.Name = "ViewAddressForm";
            this.Text = "ViewAddressForm";
            this.Load += new System.EventHandler(this.ViewAddressForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbMapView;
    }
}