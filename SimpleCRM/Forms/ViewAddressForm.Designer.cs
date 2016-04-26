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
            this.lblLat = new System.Windows.Forms.Label();
            this.lblLon = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wbMapView
            // 
            this.wbMapView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbMapView.Location = new System.Drawing.Point(12, 12);
            this.wbMapView.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbMapView.Name = "wbMapView";
            this.wbMapView.Size = new System.Drawing.Size(667, 317);
            this.wbMapView.TabIndex = 0;
            // 
            // lblLat
            // 
            this.lblLat.AutoSize = true;
            this.lblLat.Location = new System.Drawing.Point(13, 336);
            this.lblLat.Name = "lblLat";
            this.lblLat.Size = new System.Drawing.Size(48, 13);
            this.lblLat.TabIndex = 1;
            this.lblLat.Text = "Latitude:";
            // 
            // lblLon
            // 
            this.lblLon.AutoSize = true;
            this.lblLon.Location = new System.Drawing.Point(184, 336);
            this.lblLon.Name = "lblLon";
            this.lblLon.Size = new System.Drawing.Size(57, 13);
            this.lblLon.TabIndex = 2;
            this.lblLon.Text = "Longitude:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(604, 335);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ViewAddressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 367);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblLon);
            this.Controls.Add(this.lblLat);
            this.Controls.Add(this.wbMapView);
            this.Name = "ViewAddressForm";
            this.Text = "ViewAddressForm";
            this.Load += new System.EventHandler(this.ViewAddressForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbMapView;
        private System.Windows.Forms.Label lblLat;
        private System.Windows.Forms.Label lblLon;
        private System.Windows.Forms.Button btnClose;
    }
}