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
    public partial class AddCustomerForm : Form
    {
        public AddCustomerForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //create instances of Model objects
            Customer newCustomer = new Customer();
            Address newAddress = new Address();
            CustomerAddress newCustomerAddress = new CustomerAddress();

            IGetCustomerInfo customerInfoUtil = DependencyInjectorUtility.GetCustomerInfo(); //create instance of utility class

            //set new Customer object properties
            newCustomer.NameStyle = false;
            newCustomer.FirstName = txtFirstName.Text;
            newCustomer.LastName = txtLastName.Text;
            newCustomer.PasswordHash = "TEST";
            newCustomer.PasswordSalt = "TEST";

            if (!(String.IsNullOrWhiteSpace(txtTitle.Text))) { newCustomer.Title = txtTitle.Text; }
            else { newCustomer.Title = null; }
            if (!(String.IsNullOrWhiteSpace(txtMiddleName.Text))) { newCustomer.MiddleName = txtMiddleName.Text; }
            else { newCustomer.MiddleName = null; }
            if (!(txtSuffix.Text == "Suffix")) { newCustomer.Suffix = txtSuffix.Text; }
            else { newCustomer.Suffix = null; }
            if (!(String.IsNullOrWhiteSpace(txtCompany.Text))) { newCustomer.CompanyName = txtCompany.Text; }
            else { newCustomer.CompanyName = null; }
            if (!(String.IsNullOrWhiteSpace(txtSalesPerson.Text))) { newCustomer.SalesPerson = txtSalesPerson.Text; }
            else { newCustomer.SalesPerson = null; }
            if (!(String.IsNullOrWhiteSpace(txtEmailAddress.Text))) { newCustomer.EmailAddress = txtEmailAddress.Text; }
            else { newCustomer.EmailAddress = null; }
            if (!(String.IsNullOrWhiteSpace(txtPhone.Text))) { newCustomer.Phone = txtPhone.Text; }
            else { newCustomer.Phone = null; }

            //set new Address object properties
            newAddress.AddressLine1 = txtLine1.Text;
            newAddress.City = txtCity.Text;
            newAddress.StateProvince = txtStateProvince.Text;
            newAddress.CountryRegion = txtCountryRegion.Text;
            newAddress.PostalCode = txtPostalCode.Text;

            if (!(String.IsNullOrWhiteSpace(txtLine2.Text))) { newAddress.AddressLine2 = txtLine2.Text; }
            else { newAddress.AddressLine2 = null; }

            //set new CustomerAddress object properties - this is the only one entered on the form, rest will be pulled from DB
            newCustomerAddress.AddressType = txtAddressType.Text;

            //Add Customer and Address objects to their respective tables
            customerInfoUtil.AddCustomer(newCustomer);
            customerInfoUtil.AddAddress(newAddress);

            //Get CustomerID and AddressID from newly added rows, then add the object to CustomerAddress table
            newCustomerAddress.CustomerId = customerInfoUtil.GetCustomerID();
            newCustomerAddress.AddressID = customerInfoUtil.GetAddressID();
            customerInfoUtil.AddCustomerAddress(newCustomerAddress);

            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
