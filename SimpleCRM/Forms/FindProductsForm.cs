using AdventureWorks.Business.Data;
using AdventureWorks.Business.Models;
using SimpleCRM.Forms;
using SimpleCRM.Forms.UserControls;
using SimpleCRM.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCRM.Forms
{
    public partial class FindProductsForm : Form
    {
        public FindProductsForm()
        {
            InitializeComponent();
        }

        private void btnFindProduct_Click(object sender, EventArgs e)
        {
            flpProducts.Controls.Clear(); //remove controls
            IGetProductInfo productInfo = DependencyInjectorUtility.GetProductInfo();

            if (string.IsNullOrWhiteSpace(txtSearch.Text)) { MessageBox.Show("Product Search Value Required"); return; }

            List<Product> searchResults = productInfo.SearchProduct(txtSearch.Text);

            foreach (Product productDTO in searchResults)
            {
                ProductUserControl puc = new ProductUserControl(productDTO);
                flpProducts.Controls.Add(puc);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFindProduct_Click(sender, e);

            }
        }
    }
}
