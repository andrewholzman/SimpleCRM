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
    public partial class AddSalesOrderForm : Form
    {

        List<SalesOrderProductViewModel> productList = new List<SalesOrderProductViewModel>(); //create persistant list of ViewModel objects to display in the DGV
        List<SalesOrderDetail> soDetailList = new List<SalesOrderDetail>();
        Product soProduct = new Product();
        SalesOrderDetail soDetailToAdd = new SalesOrderDetail();
        SalesOrderProductViewModel soProductVM = null;
        double TAX_RATE = 0.07; //unsure how AdventureWorks calculates tax rates, setting to 7% for Hamilton County

        public AddSalesOrderForm()
        {
            InitializeComponent();
        }

        public void AddSalesOrderForm_Load(object sender, EventArgs e)
        {

        }
         
        private void btnSave_Click(object sender, EventArgs e)
        {
            //create Model class objects and instances of Utility classes
            SalesOrderHeader soHeader = new SalesOrderHeader();
            Address soAddress = new Address();
            int salesOrderIDToEnter = 0;

            IGetCustomerInfo customerInfo = DependencyInjectorUtility.GetCustomerInfo();
            IGetProductInfo productInfo = DependencyInjectorUtility.GetProductInfo();
            IGetSalesOrderInfo salesOrderInfo = DependencyInjectorUtility.GetSalesInfo();

            //set properties of the SalesOrderHeader object from their respective fields
            int customerIDAsInt;

            if (Int32.TryParse(txtCustomerID.Text, out customerIDAsInt)) { soHeader.CustomerID = customerIDAsInt; }
            else { MessageBox.Show("Please enter a valid customer ID"); return; }
            if (chkOrderOnlineFlag.Checked) { soHeader.OrderOnlineFlag = true; }
            else { soHeader.OrderOnlineFlag = false; }

            byte revisionNumber;
            if (!byte.TryParse(txtRevisionNumber.Text, out revisionNumber)) { }
            soHeader.RevisionNumber = revisionNumber;
            soHeader.Status = (byte)numStatus.Value;
            
            if(!(String.IsNullOrWhiteSpace(txtAccountNumber.Text))) { soHeader.AccountNumber = txtAccountNumber.Text; }
            else { soHeader.AccountNumber = null;  }
            if (!(String.IsNullOrWhiteSpace(txtPurchaseOrderNumber.Text))) { soHeader.PurchaseOrderNumber = txtPurchaseOrderNumber.Text; }
            else { soHeader.PurchaseOrderNumber = null; }
            if (!(String.IsNullOrWhiteSpace(txtCreditCardApprovalCode.Text))) { soHeader.CreditCardApprovalCode = txtCreditCardApprovalCode.Text; }
            else { soHeader.CreditCardApprovalCode = null; }

            soHeader.OrderDate = dtpOrderDate.Value;
            soHeader.DueDate = dtpDueDate.Value;
            if (dtpShipDate.Checked) { soHeader.ShipDate = dtpShipDate.Value; }
            else { soHeader.ShipDate = null;  }
            
            if (!(String.IsNullOrWhiteSpace(txtComment.Text))) { soHeader.Comment = txtComment.Text;  }
            else { soHeader.Comment = null;  }

            soAddress = customerInfo.GetAddress(customerIDAsInt);
            if (!(soAddress == null)) //check if the address returned by the GetAddress() function is not null and set the Bill/Ship id values
            {
                soHeader.BillToAddressID = soAddress.AddressID;
                soHeader.ShipToAddressID = soAddress.AddressID;
            }
            else
            {
                soHeader.BillToAddressID = null;
                soHeader.ShipToAddressID = null;
            }
            soHeader.ShipMethod = cbShipMethod.Text;
            double FREIGHT_RATE = 0;
            if (cbShipMethod.SelectedIndex == 0) //not sure how freight is calculated in adventureworks - could make this a switch/case statement if there were more than two options 
            {
                FREIGHT_RATE = 0.25; //if the first item is selected (AIR) set the rate at which freight is calculated to 0.25
            } else
            {
                FREIGHT_RATE = 0.20; //set to 0.20 for CARGO 
            }

            //Do work to calculate SubTotal, TaxAmt, TotalDue based upon entries in the dgvProductList
            double subTotal = 0;
            foreach (SalesOrderProductViewModel sopVM in productList) //add up linetotals and store in subtotal
            {
                subTotal = subTotal + (double)sopVM.LineTotal;
            }
            soHeader.SubTotal = (decimal)subTotal;
            soHeader.TaxAmt = (decimal)(subTotal * TAX_RATE); //calculate tax
            soHeader.Freight = (decimal)(subTotal * FREIGHT_RATE); //calculate freight


            //Preform DB inserts for SalesOrderHeader and SalesOrderDetail
            salesOrderIDToEnter = salesOrderInfo.AddSalesOrderHeader(soHeader);


            for (int i = 0; i < soDetailList.Count; i++)
            {
                soDetailList[i].SalesOrderID = salesOrderIDToEnter;
                salesOrderInfo.AddSalesOrderDetail(soDetailList[i]);
            }

            this.Close();
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {


            addProductToList();
           


        }

        private void addProductToList()
        {
            IGetProductInfo productInfo = DependencyInjectorUtility.GetProductInfo();

            //retrieve the product info fr the entered product ID
            int productIDAsInt;
            if (Int32.TryParse(txtProductID.Text, out productIDAsInt))
            {
                soProduct = productInfo.GetProduct(productIDAsInt);
                if (!(soProduct == null)) //ensure the entered product number is valid (actually tied to a product)
                {

                    soDetailToAdd.ProductID = soProduct.ProductID;

                }
                else
                {
                    MessageBox.Show("Please enter a valid product ID");
                    return;
                }
            }
            else { MessageBox.Show("Please enter a valid product ID"); }

            //soDetailToAdd.ProductID = soProduct.ProductID;
            soDetailToAdd.UnitPrice = soProduct.ListPrice;


            decimal discountAmount;
            if (!decimal.TryParse(txtDiscount.Text, out discountAmount))
            {
                MessageBox.Show("Must enter a valid decimal value for Discount Amount");

            }
            soDetailToAdd.UnitPriceDiscount = discountAmount;

            soDetailToAdd.OrderQty = (short)numQuantity.Value;

            //UnitPrice * (1 - UnitPriceDiscount) * OrderQty - DB Calculation for LineTotal
            soDetailToAdd.LineTotal = (soDetailToAdd.UnitPrice * (1 - soDetailToAdd.UnitPriceDiscount) * soDetailToAdd.OrderQty);
            soDetailList.Add(soDetailToAdd);

            soProductVM = new SalesOrderProductViewModel(soDetailToAdd);


            soProductVM = new SalesOrderProductViewModel(soDetailToAdd);
            productList.Add(soProductVM);



            dgvProductList.DataSource = null;
            dgvProductList.DataSource = productList;
        }


        private void btnLookUp_Click(object sender, EventArgs e)
        {
            FindProductsForm findProductsForm = new FindProductsForm();
            DialogResult dr = findProductsForm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
