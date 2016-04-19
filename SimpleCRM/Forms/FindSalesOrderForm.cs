using AdventureWorks.Business.Data;
using AdventureWorks.Business.Models;
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

namespace SimpleCRM
{
    public partial class FindSalesOrderForm : Form
    {
        public FindSalesOrderForm()
        {
            InitializeComponent();
        }

        private void btnFindSalesOrder_Click(object sender, EventArgs e)
        {
            //Create instance of IGetCustomerInfo
            IGetSalesOrderInfo salesOrderInfo = DependencyInjectorUtility.GetSalesInfo();

            //Validate search
            if (string.IsNullOrWhiteSpace(txtSearch.Text)) { MessageBox.Show("Product Search Value Required"); return; }

            List<SalesOrder> searchResults = salesOrderInfo.SearchSalesOrder(txtSearch.Text);

            List<SalesOrderSearchViewModel> sosvCollection = new List<SalesOrderSearchViewModel>();
            foreach(SalesOrder salesOrderToAdd in searchResults)
            {
                SalesOrderSearchViewModel salesOrderVM = new SalesOrderSearchViewModel(salesOrderToAdd);
                sosvCollection.Add(salesOrderVM);
            }

            dgvSalesOrderInfo.DataSource = null;
            dgvSalesOrderInfo.DataSource = sosvCollection;
        }
    }
}
