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

        public ViewCustomerInfoForm(int customerID)
        {
            InitializeComponent();
            this.customerID = customerID;
        }

        private void ViewCustomerInfoForm_Load(object sender, EventArgs e)
        {
            Customer customer;
            Address address;

            IGetCustomerInfo customerInfoUtil = DependencyInjectorUtility.GetCustomerInfo();
            customer = customerInfoUtil.GetCustomer(customerID);

            txtFirstName.Text = customer.FirstName;
            txtLastName.Text = customer.LastName;
            txtMiddleName.Text = customer.MiddleName;
            txtSuffix.Text = customer.Suffix;

            txtCompany.Text = customer.CompanyName;
            txtSalesPerson.Text = customer.SalesPerson;
            txtPhone.Text = customer.Phone;
            txtEmailAddress.Text = customer.EmailAddress;

            address = customerInfoUtil.GetAddress(customerID);

            if (!(address == null))
            {
                txtLine1.Text = address.AddressLine1;
                txtLine2.Text = address.AddressLine2;
                txtCity.Text = address.City;
                txtStateProvince.Text = address.StateProvince;
                txtCountryRegion.Text = address.CountryRegion;
                txtPostalCode.Text = address.PostalCode;
            }

        }
    }
}
