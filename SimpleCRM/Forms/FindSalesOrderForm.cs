using AdventureWorks.Business.Data;
using AdventureWorks.Business.Models;
using SimpleCRM.Forms;
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

        //event handler to allow users to double click a sales order and open up a SalesOrderInfoForm w/ desired SalesOrder info
        private void dgvSalesOrderInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SalesOrderSearchViewModel salesOrderVM = null;
            if (dgvSalesOrderInfo.SelectedRows.Count > 0)
            {
                salesOrderVM = (SalesOrderSearchViewModel)dgvSalesOrderInfo.SelectedRows[0].DataBoundItem;
            }

            if (salesOrderVM == null)
            {
                return;
            }
            ViewSalesOrderInfoForm salesOrderInfoForm = new ViewSalesOrderInfoForm(salesOrderVM.SalesOrderID);
            salesOrderInfoForm.ShowDialog();
            btnFindSalesOrder_Click(sender, e);
        }

        //event handler to allow users to hit enter rather than press the 'Find' button
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFindSalesOrder_Click(sender, e);

            }
        }
    }
}
