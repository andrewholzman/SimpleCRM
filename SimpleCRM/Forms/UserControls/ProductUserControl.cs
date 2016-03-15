using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdventureWorks.Business.Models;
using System.IO;

namespace SimpleCRM.Forms.UserControls
{
    public partial class ProductUserControl : UserControl
    {
        private Product _product;

        public ProductUserControl()
        {
            InitializeComponent();
        }

        public ProductUserControl(Product product) : this()
        {
            _product = product;
        }

        private void ProductUserControl_Load(object sender, EventArgs e)
        {
            lblProductName.Text = _product.ProductName;
            lblColor.Text = "Color: " + _product.Color;
            lblStandardCost.Text = "Standard Cost: " + string.Format("{0:c}", _product.StandardCost);
            lblListPrice.Text = "List Price: " + string.Format("{0:c}", _product.ListPrice);
            lblSize.Text = "Size: " + _product.Size;
            lblWeight.Text = "Weight: " + string.Format("",_product.Weight);
            lblProductCategoryID.Text = "Category ID: " + _product.ProductCategoryID.ToString();
            lblProductModelID.Text = "Model ID: " + _product.ProductModelID.ToString();
            lblSellStartDate.Text = "Start Date: " + string.Format("{0:M/d/yyyy}", _product.SellStartDate);

            string endDate = string.Format("{0:M/d/yyyy}", _product.SellEndDate);
            if (endDate == "1/1/0001") { lblSellEndDate.Text = "End Date:"; }
            else { lblSellEndDate.Text = "End Date: " + endDate; }
            string discontinuedDate = string.Format("{0:M/d/yyyy}", _product.DiscontinuedDate);
            if (discontinuedDate == "1/1/0001") { lblDiscontinuedDate.Text = "Discontinued Date:"; }
            else { lblDiscontinuedDate.Text = "Discontinued Date: " + discontinuedDate; }




            Stream picStream = new MemoryStream(_product.ThumbNailPhoto);
            picBoxProduct.Image = new System.Drawing.Bitmap(picStream);

            

        }
    }
}
