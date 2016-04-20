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
            //create of list of Customers 
            List<Customer> searchResults = customerInfo.SearchCustomer(txtSearch.Text);
            //create a list view models to set as the data source for the data grid viiew
            List<CustomerSearchViewModel> csvCollection = new List<CustomerSearchViewModel>();
            //loop through the Customers in searchResults and add them to the collection
            foreach(Customer customerToAdd in searchResults)
            {
                CustomerSearchViewModel customerVM = new CustomerSearchViewModel(customerToAdd);
                csvCollection.Add(customerVM);
            }

            //set datasource for dgv to the collection of Customers
            dgvCustomerInfo.DataSource = null;
            dgvCustomerInfo.DataSource = csvCollection;
        }

        //event handler to make the search box respond to the enter key being pressed
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFindCustomer_Click(sender, e);

            }
        }

        //open up the ViewCustomerInfoForm if the user double clicks a cell
        private void dgvCustomerInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Create new view model
            CustomerSearchViewModel customerVM = null;
            if (dgvCustomerInfo.SelectedRows.Count > 0) //ensure there are rows returned
            {
                customerVM = (CustomerSearchViewModel)dgvCustomerInfo.SelectedRows[0].DataBoundItem; //set the ViewModel to the current row clicked
            }

            if (customerVM == null) //exit if the above loop fails, if there isnt a customer to view details for
            {
                    return;
            }

            //create a new instance of the customer info form and open it
            ViewCustomerInfoForm customerInfoForm = new ViewCustomerInfoForm(customerVM.CustomerID); 
            customerInfoForm.ShowDialog();
            btnFindCustomer_Click(sender, e);
        }
    }
}
