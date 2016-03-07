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
    public partial class FindCustomerForm : Form
    {

        public FindCustomerForm()
        {
            InitializeComponent();
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            //Create instance of IGetCustomerInfo
            IGetCustomerInfo customerInfo = DependencyInjectorUtility.GetCustomerInfo();

            //Validate search
            if (string.IsNullOrWhiteSpace(txtSearch.Text)) { MessageBox.Show("Product Search Value Required"); return; }

            List<Customer> searchResults = customerInfo.SearchCustomer(txtSearch.Text);

            List<CustomerSearchViewModel> csvCollection = new List<CustomerSearchViewModel>();
            foreach(Customer customerToAdd in searchResults)
            {
                CustomerSearchViewModel customerVM = new CustomerSearchViewModel(customerToAdd);
                csvCollection.Add(customerVM);
            }

            dgvCustomerInfo.DataSource = null;
            dgvCustomerInfo.DataSource = csvCollection;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFindCustomer_Click(sender, e);

            }
        }

        private void dgvCustomerInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CustomerSearchViewModel customerVM = null;
            if (dgvCustomerInfo.SelectedRows.Count > 0)
            {
                customerVM = (CustomerSearchViewModel)dgvCustomerInfo.SelectedRows[0].DataBoundItem;
            }

            if (customerVM == null) 
            {
                    return;
            }
            ViewCustomerInfoForm customerInfoForm = new ViewCustomerInfoForm(customerVM.CustomerID);
            customerInfoForm.ShowDialog();
            btnFindCustomer_Click(sender, e);
        }
    }
}
