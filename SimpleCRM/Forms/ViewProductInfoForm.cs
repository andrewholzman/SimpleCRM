using AdventureWorks.Business.Data;
using AdventureWorks.Business.Models;
using SimpleCRM.Forms.UserControls;
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
    public partial class ViewProductInfoForm : Form
    {
        public int productID;
        public ViewProductInfoForm(int productID)
        {
            InitializeComponent();
            this.productID = productID;
        }

        private void ViewProductInfoForm_Load(object sender, EventArgs e)
        {
            flpProduct.Controls.Clear(); //remove controls
            IGetProductInfo productInfo = DependencyInjectorUtility.GetProductInfo();

            Product productDTO = new Product();
            productDTO = productInfo.GetProduct(productID);


            ProductUserControl puc = new ProductUserControl(productDTO);
            flpProduct.Controls.Add(puc);

        }
    }
}
