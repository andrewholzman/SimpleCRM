using AdventureWorks.Business.Data;
using AdventureWorks.Business.Models;
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
    public partial class ViewCustomerInfoForm : Form
    {
        public int customerID;
        Customer customer;
        Address address;
        CustomerAddress customerAddress = new CustomerAddress();
        public ViewCustomerInfoForm(int customerID) //initialize with the customerID associated to the DGV Cell that was clicked
        {
            InitializeComponent();
            this.customerID = customerID;
        }

        private void ViewCustomerInfoForm_Load(object sender, EventArgs e)
        {
            //create instance of CustomerUtility
            IGetCustomerInfo customerInfoUtil = DependencyInjectorUtility.GetCustomerInfo();
            customer = customerInfoUtil.GetCustomer(customerID); //create a Customer object based upon the customerID parameter that this form loads with (from DGV)

            //set text box text
            txtTitle.Text = customer.Title;
            txtFirstName.Text = customer.FirstName;
            txtLastName.Text = customer.LastName;
            txtMiddleName.Text = customer.MiddleName;
            txtSuffix.Text = customer.Suffix;

            txtCompany.Text = customer.CompanyName;
            txtSalesPerson.Text = customer.SalesPerson;
            txtPhone.Text = customer.Phone;
            txtEmailAddress.Text = customer.EmailAddress;

            address = customerInfoUtil.GetAddress(customerID); //get Address info using customerID
            if (!(address == null)) //if the address isn't null, set the address text box text
            {
                txtLine1.Text = address.AddressLine1;
                txtLine2.Text = address.AddressLine2;
                txtCity.Text = address.City;
                txtStateProvince.Text = address.StateProvince;
                txtCountryRegion.Text = address.CountryRegion;
                txtPostalCode.Text = address.PostalCode;
                txtAddressType.Text = address.AddressType;
            }

            customerAddress = customerInfoUtil.GetCustomerAddress(customerID); //get customerAddress object
            


        }

        private void btnCancel_Click(object sender, EventArgs e) //exit form
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e) //save any changes in the textboxes to the Customer object
        {
            //Save updated customer info to database
            IGetCustomerInfo customerInfoUtil = DependencyInjectorUtility.GetCustomerInfo();
            customer = customerInfoUtil.GetCustomer(customerID);

            customer.NameStyle = false;
            customer.FirstName = txtFirstName.Text;
            customer.LastName = txtLastName.Text;
            customer.PasswordHash = "TEST CUSTOMER";
            customer.PasswordSalt = "TEST CUSTOMER";

            if (!(String.IsNullOrWhiteSpace(txtTitle.Text))) { customer.Title = txtTitle.Text; }
            else { customer.Title = null; }
            if (!(String.IsNullOrWhiteSpace(txtMiddleName.Text))) { customer.MiddleName = txtMiddleName.Text; }
            else { customer.MiddleName = null; }
            if (!(String.IsNullOrWhiteSpace(txtSuffix.Text))) { customer.Suffix = txtSuffix.Text; }
            else { customer.Suffix = null; }
            if (!(String.IsNullOrWhiteSpace(txtCompany.Text))) { customer.CompanyName = txtCompany.Text; }
            else { customer.CompanyName = null; }
            if (!(String.IsNullOrWhiteSpace(txtSalesPerson.Text))) { customer.SalesPerson = txtSalesPerson.Text; }
            else { customer.SalesPerson = null; }
            if (!(String.IsNullOrWhiteSpace(txtEmailAddress.Text))) { customer.EmailAddress = txtEmailAddress.Text; }
            else { customer.EmailAddress = null; }
            if (!(String.IsNullOrWhiteSpace(txtPhone.Text))) { customer.Phone = txtPhone.Text; }
            else { customer.Phone = null; }

            customerInfoUtil.UpdateCustomer(customer);

            //if address above is not null, save any changes to the address fields to the database
            if (!(address == null))
            {
                address.AddressLine1 = txtLine1.Text;
                address.City = txtCity.Text;
                address.StateProvince = txtStateProvince.Text;
                address.CountryRegion = txtCountryRegion.Text;
                address.PostalCode = txtPostalCode.Text;

                if (!(String.IsNullOrWhiteSpace(txtLine2.Text))) { address.AddressLine2 = txtLine2.Text; }
                else { address.AddressLine2 = null; }

                customerInfoUtil.UpdateAddress(address);
            }

        }

        private void btnViewAddress_Click(object sender, EventArgs e)
        {
            if (!(address == null))
            {
                ViewAddressForm viewAddressForm = new ViewAddressForm(customer.CustomerID);
                DialogResult dr = viewAddressForm.ShowDialog();

            }
            else
            {
                MessageBox.Show("No address is tied to current customer");
            }
        }
    }
}
