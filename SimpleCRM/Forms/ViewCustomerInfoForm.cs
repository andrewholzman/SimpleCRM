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
        public ViewCustomerInfoForm(int customerID) //initialize with the customerID associated to the DGV Cell that was clicked
        {
            InitializeComponent();
            this.customerID = customerID;
        }

        private void ViewCustomerInfoForm_Load(object sender, EventArgs e)
        {
            //create instances of Model objects
            Customer customer;
            Address address;
            CustomerAddress customerAddress = new CustomerAddress();

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
            
            SetCustomer();
            //SetAddress();

        }

        private void SetCustomer()
        {
            //create new customer object to pass to updatecCustomer() method
            Customer customerToUpdate = new Customer();

            //set properties of non-null values to to their corresponding text boxes
            customerToUpdate.CustomerID = customerID;
            customerToUpdate.FirstName = txtFirstName.Text;
            customerToUpdate.LastName = txtLastName.Text;

            //check for nulls in nullable text boxes and assign properties
            if (!(string.IsNullOrWhiteSpace(txtTitle.Text)))
            {
                customerToUpdate.Title = txtTitle.Text;
            }
            else { customerToUpdate.Title = null; } //hanle null value (in this case Title)

            if (!(string.IsNullOrWhiteSpace(txtMiddleName.Text)))
            {
                customerToUpdate.MiddleName = txtMiddleName.Text;
            }
            else { customerToUpdate.MiddleName = null; }

            if (!(string.IsNullOrWhiteSpace(txtSuffix.Text)))
            {
                customerToUpdate.Suffix = txtSuffix.Text;
            }
            else { customerToUpdate.Suffix = null; }

            if (!(string.IsNullOrWhiteSpace(txtCompany.Text)))
            {
                customerToUpdate.CompanyName = txtCompany.Text;
            }
            else { customerToUpdate.CompanyName = null; }

            if (!(string.IsNullOrWhiteSpace(txtSalesPerson.Text)))
            {
                customerToUpdate.SalesPerson = txtSalesPerson.Text;
            }
            else { customerToUpdate.SalesPerson = null; }

            if (!(string.IsNullOrWhiteSpace(txtEmailAddress.Text)))
            {
                customerToUpdate.EmailAddress = txtEmailAddress.Text;
            }
            else { customerToUpdate.EmailAddress = null; }

            if (!(string.IsNullOrWhiteSpace(txtPhone.Text)))
            {
                customerToUpdate.Phone = txtPhone.Text;
            }
            else { customerToUpdate.Phone = null; }

            //create customer utility
            IGetCustomerInfo customerInfo = DependencyInjectorUtility.GetCustomerInfo();

            //Update 
            try
            {
                customerInfo.UpdateCustomer(customerToUpdate);
            }

            catch (Exception ex)
            {
                throw;
                //MessageBox.Show(ex.Message);    
            }

            this.Close();
        }

        //private void SetAddress()
        //{
        //    //create new customer object to pass to updatecCustomer() method
        //    Address addressToUpdate = new Address();

        //    //set properties of non-null values to to their corresponding text 
        //    addressToUpdate.AddressLine1 = txtLine1.Text;
        //    addressToUpdate.City = txtCity.Text;
        //    addressToUpdate.StateProvince = txtStateProvince.Text;
        //    addressToUpdate.CountryRegion = txtCountryRegion.Text;
        //    addressToUpdate.PostalCode = txtPostalCode.Text;
        //    addressToUpdate.AddressType = txtAddressType.Text;

        //    //check for nulls in nullable text boxes and assign properties
        //    if (!(string.IsNullOrWhiteSpace(txtTitle.Text)))
        //    {
        //        addressToUpdate.AddressLine2 = txtLine2.Text;
        //    }
        //    else { addressToUpdate.AddressLine2 = null; } //hanle null value (in this case Title)


        //    //create customer utility
        //    IGetCustomerInfo customerInfo = DependencyInjectorUtility.GetCustomerInfo();

        //    //Update 
        //    try
        //    { 
        //        customerInfo.UpdateAddress(addressToUpdate);
        //    }

        //    catch (Exception ex)
        //    {
        //        throw;
        //        //MessageBox.Show(ex.Message);    
        //    }

        //    this.Close();
        //}
        
    }
}
