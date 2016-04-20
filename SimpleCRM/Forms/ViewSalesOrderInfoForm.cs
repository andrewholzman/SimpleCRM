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

namespace SimpleCRM.Forms
{
    public partial class ViewSalesOrderInfoForm : Form
    {

        public int salesOrderID;
        public ViewSalesOrderInfoForm(int salesOrderID) //initialize with a parameter for salesOrderID
        {
            InitializeComponent();
            this.salesOrderID = salesOrderID;
        }

        private void ViewSalesOrderInfoForm_Load(object sender, EventArgs e)
        {
            
            //create new MOdel object instances
            Customer customer = new Customer();
            SalesOrder salesOrder;
            SalesOrderDates soDates;
            
            //create new utility objects
            IGetCustomerInfo customerInfoUtil = DependencyInjectorUtility.GetCustomerInfo();
            IGetSalesOrderInfo salesOrderInfoUtil = DependencyInjectorUtility.GetSalesInfo();
            IGetProductInfo productInfoUtil = DependencyInjectorUtility.GetProductInfo();

            //set properties for above Models using utility class methods
            customer.CustomerID = customerInfoUtil.GetCustomerID(salesOrderID);
            customer = customerInfoUtil.GetCustomer(customer.CustomerID);
            salesOrder = salesOrderInfoUtil.GetSalesOrder(salesOrderID);
            soDates = salesOrderInfoUtil.GetDates(salesOrderID);

            //display info on form
            txtSalesOrderNumber.Text = salesOrderID.ToString();
            txtTotalDue.Text = salesOrder.TotalDue.ToString();
            txtAccountNumber.Text = salesOrder.AccountNumber;

            lblCustomerName.Text = customer.FirstName + ' ' + customer.LastName;
            lblCompanyName.Text = customer.CompanyName;
            lblEmailAddress.Text = customer.EmailAddress;
            lblPhoneNumber.Text = customer.Phone;

            txtOrderDate.Text = soDates.OrderDate.ToString();
            txtDueDate.Text = soDates.DueDate.ToString();
            txtShipDate.Text = soDates.ShipDate.ToString();

            //display a list of products pulled from SalesOrderDetail table that match this SalesOrderID and load them into a dgv
            List<SalesOrderDetail> orderDetails = salesOrderInfoUtil.GetSalesOrderDetails(salesOrderID);
            List<ProductViewModel> pvCollection = new List<ProductViewModel>();
            foreach (SalesOrderDetail soToAdd in orderDetails)
            {
                ProductViewModel productVM = new ProductViewModel(soToAdd);
                pvCollection.Add(productVM);
            }

            //set datasource for dgv to the collection of SalesOrderDetails
            dgvProductInfo.DataSource = null;
            dgvProductInfo.DataSource = pvCollection;

        }
    }
}
